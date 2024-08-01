// Tests are defined in this file

using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS.Libraries.Forms.Prompts;
using ChromaMeter;
using XYPositionSystem;
using MFD_Optical;

// lblUUTPartNo.Text; is how to access the part number used

namespace CIGALHE.MFD.Optical
{
    public partial class MFD_Optical
    {
        private DateTime _beginDateTime, _endDateTime;
        private string _operatorComment;
        private SoundPlayer _progressSoundPlayer;

        // Section of test that is currently running
        private static string _task;
        private static string _testSection;             // for example, "3.1"
        private static string _testName;                // for example, "Contrast - Day"

        // List of pass/fail tallies for each test section run.
        // Key is the sub-test section (e.g. "3.1") and Value is a class containing
        // the sub-test name, num passes and num fails.
        private static SortedList<string, TestPassFail> _pfTallies;
        private static TestPassFail _pfTotals = new TestPassFail("", 0, 0);

        private static SortedList<TestColor, SortedList<string, LightReading>> _measurements;

        // Readings are added by Section 3.1 Contrast - Day,
        // and are used again in Section 3.2 Brightness Range - Day
        private List<LightReading> _nonNormalMaxWhiteReadings = null;
        private static string _passFailStatus;
        private static string _unitsOfMeasure;
        private int _numTestsSelected;
        private int _numTestsRun;
        private bool _resultsSaved = true;

        private static Power _supplementalLightState = Power.OFF;

        private void SetPartNumber()
        {
            SharedData.Instance.PartNumber = lblUUTPartNo.Text; // Update the singleton instance with the part number from the label
        }



        private Dictionary<string, List<string>> testPrerequisites = new Dictionary<string, List<string>>() 
        {//This dictionary sets the prereqs to each test 
            { "2.1. Scratches", new List<string> { "1.1. Power On" } },
            { "2.2. Blemishes", new List<string> { "1.1. Power On" } },
            { "2.3. Defective Pixels", new List<string> { "1.1. Power On" } },
            { "3.1. Contrast - Day", new List<string> { "1.1. Power On" } },
            { "3.2. Brightness Range - Day", new List<string> { "1.1. Power On", "3.1. Contrast - Day" } },
            { "3.3. Luminance Homogeneity - Day", new List<string> { "1.1. Power On" } },
            { "3.4. Color Coordinates & Uniformity - Day", new List<string> { "1.1. Power On" } },
            { "4.1. Brightness Range - NVG", new List<string> { "1.1. Power On" } },
            { "4.2. Luminance Homogeneity - NVG", new List<string> { "1.1. Power On" } },
            { "4.3. Color Coordinates - NVG", new List<string> { "1.1. Power On" } },
            { "4.4. NVG Compatibility", new List<string> { "1.1. Power On" } },
            { "4.5. Bezel Lighting", new List<string> { "1.1. Power On" } },
            { "4.6. Bezel Backlighting", new List<string> { "1.1. Power On", "4.5. Bezel Lighting" } },
            { "4.7. Power LED", new List<string> { "1.1. Power On" } },
            { "5.1. Power Off", new List<string> { "1.1. Power On" } }
        };

        // Run tests
        private async Task RunTestsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                if (rtbTestResults.Text.Length != 0)
                {
                    MessageBox.Show("The previous test results will be cleared.", "Clearing Test Results");
                    ClearTestResults();
                    await Task.Delay(600, cancellationToken).ConfigureAwait(false);
                    var result = MessageBox.Show("Click OK to run the new test.", "Start Test", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel) return;
                }

                EnterTestInformation();

                ACRO55._chromaMeterPosition = null;
                _pfTallies = new SortedList<string, TestPassFail>();

                _beginDateTime = DateTime.Now;
                PostATRHeader();

                _numTestsSelected = CountSelectedTests();
                _numTestsRun = 0;
                int taskIdx = 0;
                foreach (TreeNode taskNode in testSelectionTree.Nodes[0].Nodes)
                {
                    int testIdx = 0;
                    foreach (TreeNode testNode in taskNode.Nodes)
                    {
                        if (testNode.Checked)
                        {
                            // Ensure each test is awaited before moving to the next
                            await _subTests[taskIdx][testIdx](cancellationToken);
                            _numTestsRun++;
                            _resultsSaved = false;
                            await Task.Delay(600, cancellationToken).ConfigureAwait(false);
                        }
                        testIdx++;
                    }
                    taskIdx++;
                }
                _endDateTime = DateTime.Now;

                if (_numTestsRun > 0)
                {
                    PostBlankLines(3);
                    PostDateAndTime(_endDateTime);
                    PostBlankLine();
                    PostATRSummary();
                    PostBlankLines(3);
                    PostATRFooter();
                    string fullPathName = SaveTestResults();
                    Popup.Show($"Test results have been automatically named and saved as\n" +
                               $"        {Path.GetFileName(fullPathName)}\n\n" +
                               $"Location: {Path.GetDirectoryName(fullPathName)}",
                               title: "Saved");

                    Popup.Show("Complete the following:\n" +
                            "     1. Turn on the room lights\n" +
                            "     2. Open the door\n" +
                            "     3. Flip the Testing sign on the door\n\n",
                             title: "Room Clean-Up");

                    Popup.Show("Turn off the following three pieces of equipment\n" +
                            "in the order listed:\n" +
                            "     1. CS-200 Chroma Meter,\n" +
                            "     2. Blackbox Controller,\n" +
                            "     3. POWER SUPPLY to Blackbox Controller\n\n",
                             title: "Equipment Power-off");

                    if (_numTestsRun == CountSubtestsInFullTest())
                    {
                        SwitchSupplementalLight(Power.ON);
                        Popup.Show("Remove wedge from tilt table and set table to 0 degrees horizontal and vertical.\n\n" +
                                   "Turn off Topward Power Supply and remove banana plug cables.", title: "Test Finished");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Test run was canceled.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //------------------------------------------- Section 1.1 -------------------------------------------
        private async Task Test1_PowerOnAndColorPattern(CancellationToken cancellationToken)
        {//Prompts the user to preform all preliminary actions to begin test 
            //needs async to stop excecution of test/ thread after 
            SetUpTestSection("1. Power On", "1.1.", "Power On", cancellationToken);

            _unitsOfMeasure = "sec";

            PromptUserToPrepareRoom();
            SetUpTopwardPowerSupply();

            PromptUserToTurnOnBacklighting();

            PromptUserToPowerOnMFD();

            DateTime beginWait = DateTime.Now;
            Popup.Show("Wait for the MFD to cycle through various test patterns.\n\n" +
                       "ACTION:\n" +
                       "   As soon as the MFD displays three circular flight instruments\n" +
                       "   on a brown terrain image, click OK.",
                       title: "MFD Completed Power-Up");
            DateTime endWait = DateTime.Now;
            TimeSpan elapsedTime = endWait - beginWait;

            PostElapsedTimeResult(elapsedTime, 120);

            PromptUserToDisplayColorBars();

            PromptUserToSetDayMode();

            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }

        //------------------------------------------- Section 2.1 -------------------------------------------

        private async Task Test2_1_AssessScratches(CancellationToken cancellationToken)
        {//2.1 Prompts the user to look for scratches
            //needs async to stop excecution of the tests/ threads after 
            SetUpTestSection("2. Display Defects", "2.1.", "Scratches", cancellationToken);

            SetTiltTableNormalToUser();

            PromptUserToTurnOffBacklighting();

            PromptUserToViewFromDistance();

            ScratchesForm frmScratches = new ScratchesForm();
            FillOutScratchesForm(frmScratches);

            EvaluateScratches(frmScratches);

            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);  
        }

        //------------------------------------------- Section 2.2 -------------------------------------------

        private async Task Test2_2_AssessBlemishesAsync(CancellationToken cancellationToken)
        {//2.2 Test to look for blemishes
            //needs an await to stop execution of next test 
            SetUpTestSection("2. Display Defects", "2.2.", "Blemishes", cancellationToken);

            await AdjustUUTtoMediumBrightnessAsync(Mode.Day, cancellationToken);
            if (_supplementalLightState == Power.OFF) SwitchSupplementalLight(Power.ON);
            SetTiltTableNormalToUser();

            BlemishesForm blemishesForm = new BlemishesForm(); //creates blemishes form instance

            DialogResult dialogResult = Popup.Show("Inspect the display from a distance of 28 inches and all angles.\n\n" +
                                                  "Does the LCD have any of the following defects:\n" +
                                                  "      * Blemishes\n" +
                                                  "      * Air bubbles\n" +
                                                  "      * De-lamination\n" +
                                                  "      * Cracks\n" +
                                                  "      * Discoloration\n" +
                                                  "      * Extraneous matter",
                                                  "Inspect Display", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                FillOutBlemishesForm(blemishesForm);
            }
            else
            {
                blemishesForm.radYesSmudgeFree.Checked = true;
            }

            PostBlemishResults(blemishesForm);

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }

        //------------------------------------------- Section 2.3 -------------------------------------------

        private async Task Test2_3_AssessDefectivePixelsAsync(CancellationToken cancellationToken)
        {//2.3 test to look for defective pixels
            SetUpTestSection("2. Display Defects", "2.3.", "Defective Pixels", cancellationToken);

            await AdjustUUTtoMediumBrightnessAsync(Mode.Day, cancellationToken); //set brightness to medium

            SetTiltTableNormalToUser();
            if (_supplementalLightState == Power.ON) SwitchSupplementalLight(Power.OFF);

            AudibleAlert();
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Use WHITE and BLACK color patterns to show failed OFF and\n" +
                       "failed ON pixels.  (Other colors may be used as well.)\n\n" +
                       "Report the number of failed pixels on the next form.", title: "Examine LCD",
                       msgBoxButtons: MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All functions.png",
                       imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Use WHITE and BLACK color patterns to show failed OFF and\n" +
                       "failed ON pixels.  (Other colors may be used as well.)\n\n" +
                       "Report the number of failed pixels on the next form.", title: "Examine LCD",
                       msgBoxButtons: MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - Test Patterns.png",
                       imagePopupTitle: "CIGALHE MFD Bezel");
            }

            PostHeader(MaximumAllowedHeader);
            FailedPixelsForm frmFailedPixels = new FailedPixelsForm();
            FillOutFailedPixelsForm(frmFailedPixels);

            EvaluateDefectivePixels(frmFailedPixels);

            PostDefectivePixelResults(frmFailedPixels);

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }

        //------------------------------------------- Section 3.1 -------------------------------------------

        private async Task Test3_TestContrast_DayAsync(CancellationToken cancellationToken)
        {
            // Ensure _ChromaMeter and _XYTable are not null
            if (_ChromaMeter == null)
            {
                throw new InvalidOperationException("_ChromaMeter is not initialized. test3");
            }

            if (_XYTable == null)
            {
                throw new InvalidOperationException("_XYTable is not initialized.test3");
            }

            // Proceed with the test if both are initialized
            SetUpTestSection("3. Day Mode", "3.1.", "Contrast - Day", cancellationToken);

            SwitchSupplementalLight(Power.ON);
            await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken);

            List<KeyValuePair<string, int>> contrastRatios = new List<KeyValuePair<string, int>>();
            _nonNormalMaxWhiteReadings = new List<LightReading>();

            await TestContrastAtMultipleAnglesAsync(contrastRatios, cancellationToken);

            PostContrastResults(contrastRatios);

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }


        //------------------------------------------- Section 3.2 -------------------------------------------

        private async Task Test4_TestBrightnessRange_DayAsync(CancellationToken cancellationToken)
        {// Test for the brightness of Day setting 
            if (_nonNormalMaxWhiteReadings == null)
            {
                DialogResult dialogResult = Popup.Show("Section 3.1 'Contrast - Day' test needs to be run before this test.\n\n" +
                                                       "Do you want to run the Contrast - Day test?", "Run Contrast - Day Test First?",
                                                       MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    await Test3_TestContrast_DayAsync(cancellationToken);
                }
                else
                {
                    _nonNormalMaxWhiteReadings = new List<LightReading>()
                    {
                        new LightReading(0, 0, 0), new LightReading(0, 0, 0),
                        new LightReading(0, 0, 0), new LightReading(0, 0, 0),
                    };
                }
            }

            SetUpTestSection("3. Day Mode", "3.2.", "Brightness Range - Day", cancellationToken);

            if (_supplementalLightState == Power.OFF) SwitchSupplementalLight(Power.ON);
            SetTiltTableNormal();//set the table normal to the chromameter
            await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken); //moves chromameter to the center of the viewing spot

            _unitsOfMeasure = "fL";

            await TestBrightnessAsync("Maximum", "maximum brightness (LUM = 127)", false, cancellationToken);
            _uutMediumBrightness = false;
            PostBlankLines(numLines: 2);

            await TestBrightnessAsync("Minimum", "minimum brightness (LUM = 1)", true, cancellationToken);
            _uutMediumBrightness = false;

            PostCornerBrightnessResults();

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }

        //------------------------------------------- Section 3.3 -------------------------------------------

        internal async Task Test5_TestLuminanceHomogeneity_DayAsync(CancellationToken cancellationToken)
        {//test for the luminance homogeneity (day)
            SetUpTestSection("3. Day Mode", "3.3.", "Luminance Homogeneity - Day", cancellationToken);

            await AdjustUUTtoMediumBrightnessAsync(Mode.Day, cancellationToken);
            AudibleAlert();
            TurnOffLightAndCoverMonitor();
            LightReading whiteReading = await Task.Run(() => _ChromaMeter.TakeMeasurement(), cancellationToken); 
            PostHeader(MeasurementHeader);
            GradeResultAndTallyPassFail(whiteReading.Lv, BrightnessDayNormalMedLowerLimit,
                BrightnessDayNormalMedUpperLimit);// checks if values are within range
            _unitsOfMeasure = "fL";
            PostMeasurement(MeasurementFormatDbl1Int, "White Test Pattern", whiteReading.Lv,
                BrightnessDayNormalMedLowerLimit, BrightnessDayNormalMedUpperLimit);

            await TakeLightReadingsFromNinePositionsAsync(TestColor.White_Day, cancellationToken); //takes light reading at 9 positions for white(day)
            PostBlankLine(); //needed not in helper methods
            PostNineReadingsTable(TestColor.White_Day);

            PostLuminanceResults();

            await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken); //moves chromameter to center of the display
            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }

        //------------------------------------------- Section 3.4 -------------------------------------------

        internal async Task Test6_TestColorCoordinatesAndUniformity_DayAsync(CancellationToken cancellationToken)
        {// test for color coordinates and uniformity 
            SetUpTestSection("3. Day Mode", "3.4.", "Color Coordinates & Uniformity - Day", cancellationToken);

            SetTiltTableNormal(); // sets the table normal to the chromameter

            _unitsOfMeasure = "---";
            _measurements = new SortedList<TestColor, SortedList<string, LightReading>>();

            await TestColorCoordinatesAtMultipleSpots_DayAsync(cancellationToken);

            await PostChromaUniformityResultsAsync(cancellationToken);

            await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken); // moves chromameter to center of display
            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);

        }

        //------------------------------------------- Section 4.1 -------------------------------------------

        internal async Task Test7_TestBrightnessRange_NVGAsync(CancellationToken cancellationToken)
        {
            SetUpTestSection("4. NVG Mode", "4.1.", "Brightness Range - NVG", cancellationToken);

            SetTiltTableNormal();//set the table normal to the chromameter

            _unitsOfMeasure = "fL";

            LightReading whiteReading;
            PostLineOfText("   Maximum - Center-of-Display, Normal Incidence:\n", bold: true);

            PromptUserToDisplayWhiteNVG();
            whiteReading = await Task.Run(() => _ChromaMeter.TakeMeasurement(), cancellationToken);
            ValidateWhiteReading(whiteReading);

            PostHeader(MeasurementHeader);
            GradeResultAndTallyPassFail(whiteReading.Lv, BrightnessNVGMaxLowerLimit, BrightnessNVGMaxUpperLimit);
            PostMeasurement(MeasurementFormatDbl2Int, " ", whiteReading.Lv, BrightnessNVGMaxLowerLimit, BrightnessNVGMaxUpperLimit);

             await TestBrightnessNVGAsync(cancellationToken);

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }


        //------------------------------------------- Section 4.2 -------------------------------------------
        // This test is identical to Section 3.3 except for NVG instead of Day in two places

        internal async Task Test8_TestLuminanceHomogeneity_NVGAsync(CancellationToken cancellationToken)
        {//test for luminance homogenity in NVG mode
            SetUpTestSection("4. NVG Mode", "4.2.", "Luminance Homogeneity - NVG", cancellationToken);
            PostLineOfText("NVG Mode, White Test Pattern, Maximum Brightness");

            SetTiltTableNormal();// sets table normal to chromameter
            await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken);//moves chromameter to center of display

            AudibleAlert();
            PromptUserToDisplayWhiteNVG();
            await TakeLightReadingsFromNinePositionsAsync(TestColor.White_Day, cancellationToken); // takes 9 readings of luminance in NVG mode, should not beep when taking measurements
            PostNineReadingsTable(TestColor.White_Day); //prints results 
            PostLuminanceResults();

            await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken); //sets chromameter to the center of the display
            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);

        }

        //------------------------------------------- Section 4.3 -------------------------------------------

        internal async Task Test9_TestColorCoordinates_NVGAsync(CancellationToken cancellationToken)
        {// test for the color coordinates in NVG mode
            SetUpTestSection("4. NVG Mode", "4.3.", "Color Coordinates - NVG", cancellationToken);

            SetTiltTableNormal(); //sets table normal to the chromameter

            // Color Coordinates
            _unitsOfMeasure = "---";
            _measurements = new SortedList<TestColor, SortedList<string, LightReading>>();

            string testPoint = "#5";
            await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken); //sets chromameter to the center of the display
            await TestColorCoordinatesAtOneSpotAsync_NVG(testPoint, cancellationToken);// takes meausrements of red and yellow in NVG mode and prints results (pass/fail)

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }

        //------------------------------------------- Section 4.4 -------------------------------------------

        internal async Task Test10_TestNVGCompatibilityAsync(CancellationToken cancellationToken)
        { //test for NVG compatibility
            SetUpTestSection("4. NVG Mode", "4.4.", "NVG Compatibility", cancellationToken);

            _unitsOfMeasure = "---";
            string prompt;
            DialogResult expectedResponse = DialogResult.Yes;
            DialogResult operatorResponse;

            await AdjustUUTtoMediumBrightnessAsync(Mode.NVG, cancellationToken); // sets brightness to medium

            await Task.Delay(600, cancellationToken);

            Popup.Show("Verify bezel backlighting voltage is 28 V and adjust if necessary.\n",
                        title: "Maximum Bezel Backlighting");

            await Task.Delay(600, cancellationToken);
            if (_supplementalLightState == Power.OFF) SwitchSupplementalLight(Power.ON);
            await Task.Delay(600, cancellationToken);
            SetTiltTableNormalToUser();
            await Task.Delay(600, cancellationToken);
            if (_supplementalLightState == Power.ON) SwitchSupplementalLight(Power.OFF);

            AudibleAlert();
            Popup.Show("Use night vision goggles or monocular to verify NO dazzling and light leakage around the bezel.\n\n" +
                       "  (Cover PC monitor while observing the bezel.)",
                        title: "Light Leakage Check");
            prompt = "Is the bezel free from dazzling and light leakage?";
            PostBlankLines(numLines: 2);
            PostUserPromptToTestResults("   " + prompt, doubleSpaced: true);
            operatorResponse = Popup.Show(prompt, "Light Leakage", MessageBoxButtons.YesNo);
            PostHeader(ReceivedExpectedHeader);
            GradeResultAndTallyPassFail(operatorResponse, expectedResponse); // assesses if the bezel had any light leakage, pass/fail
            PostOperatorResponse(operatorResponse, expectedResponse);

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }


        //------------------------------------------- Section 4.5 -------------------------------------------

        internal async Task Test11_TestBezelLightingAsync(CancellationToken cancellationToken)
        { 
            SetUpTestSection("4. NVG Mode", "4.5.", "Bezel Lighting", cancellationToken);

            _unitsOfMeasure = "---";

            if (_tiltTableAngle != TiltTableAngle.NormalToUser)
            {
                SwitchSupplementalLight(Power.ON);
                SetTiltTableNormalToUser();
            }
            if (_supplementalLightState == Power.ON) SwitchSupplementalLight(Power.OFF);

            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                await Task.Run(() => Popup.Show("Set MFD to display WHITE, in NVG mode and minimum brightness (LUM = 1).\n\n" +
                                          "(Temporarily cover PC monitor to help see minimum brightness.)",
                                           title: "White - NVG Mode",
                                           MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                                           imagePopupTitle: "ROSE MFD Bezel"), cancellationToken);
                _uutMediumBrightness = false;
            }
            else
            {
                await Task.Run(() => Popup.Show("Set MFD to display WHITE, in NVG mode and minimum brightness (LUM = 1).\n\n" +
                                           "(Temporarily cover PC monitor to help see minimum brightness.)",
                                            title: "White - NVG Mode",
                                            MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                                            imagePopupTitle: "CIGALHE MFD Bezel"), cancellationToken);
            }
            _uutMediumBrightness = false;

            PromptUserToAdjustBezelBacklighting();

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }


        //------------------------------------------- Section 4.6 -------------------------------------------
        //Test 12
        internal async Task Test12_BezelBacklightingTestAsync(CancellationToken cancellationToken)
        { 
            SetUpTestSection("4. NVG Mode", "4.6", "Bezel Backlighting", cancellationToken);
            if (_tiltTableAngle != TiltTableAngle.NormalToUser)
            {
                SwitchSupplementalLight(Power.ON);
                SetTiltTableNormalToUser();
            }
            if (_supplementalLightState == Power.ON) SwitchSupplementalLight(Power.OFF);

            //bezel backlighting test
            // Show a popup to the user instructing them to verify and adjust the bezel backlighting voltage

            await Task.Run(() => Popup.Show("Verify bezel backlighting voltage is 28 V and adjust if necessary.\n",
                               title: "Maximum Bezel Backlighting"), cancellationToken);

            DecreaseBezelBacklighting();
            CheckBacklightingDecreaseUniformity();

            IncreaseBezelBacklighting();
            CheckBacklightingIncreaseUniformity();

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }

        //------------------------------------------- Section 4.7 -------------------------------------------

        internal async Task Test13_TestPowerLEDAsync(CancellationToken cancellationToken)
        { 
            SetUpTestSection("4. NVG Mode", "4.7.", "Power LED", cancellationToken);

            if (_tiltTableAngle != TiltTableAngle.NormalToUser)
            {
                SwitchSupplementalLight(Power.ON);
                SetTiltTableNormalToUser();
            }
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                await Task.Run(() => Popup.Show("Set MFD to display BLACK, in NVG mode.\n\n" +
                                           "(When running the full test, one press of bezel button S23 will do it.)",
                                            title: "Black - NVG Mode", msgBoxButtons: MessageBoxButtons.OK,
                                            imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                                            imagePopupTitle: "ROSE MFD Bezel"), cancellationToken);
            }
            else
            {
                await Task.Run(() => Popup.Show("Set MFD to display BLACK, in NVG mode.\n\n" +
                                          "(When running the full test, one press of bezel button S23 will do it.)",
                                           title: "Black - NVG Mode", msgBoxButtons: MessageBoxButtons.OK,
                                           imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                                           imagePopupTitle: "CIGALHE MFD Bezel"), cancellationToken);
            }
               
            if (_supplementalLightState == Power.ON) SwitchSupplementalLight(Power.OFF);

            _unitsOfMeasure = "---";
            string prompt1, prompt2, prompt3;
            DialogResult operatorResponse;
            DialogResult expectedResponse = DialogResult.Yes;
            await Task.Delay(600, cancellationToken);

            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                prompt1 = "1. Click the Help icon (above right) to display a picture of the MFD bezel.\n" +
                     "2. On the MFD bezel, press the Mode button (S19) repeatedly to toggle through Day, Night and NVG modes.";
                prompt2 = "Did the Power LED change in brightness each time S19 was pressed?";
                PostUserPromptToTestResults("   " + prompt2, doubleSpaced: true);
                operatorResponse = await Task.Run(() => Popup.Show(prompt1 + "\n\n" + prompt2, "Power LED", MessageBoxButtons.YesNo,
                                                             imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                                                             imagePopupTitle: "ROSE MFD Bezel"), cancellationToken);
            }
            else
            {
                prompt1 = "1. Click the Help icon (above right) to display a picture of the MFD bezel.\n" +
                          "2. On the MFD bezel, press the Mode button (S19) repeatedly to toggle through Day, Night and NVG modes.";
                prompt2 = "Did the Power LED change in brightness each time S19 was pressed?";
                PostUserPromptToTestResults("   " + prompt2, doubleSpaced: true);
                operatorResponse = await Task.Run(() => Popup.Show(prompt1 + "\n\n" + prompt2, "Power LED", MessageBoxButtons.YesNo,
                                                              imageFile: ImagesFolder + "MFD Bezel Buttons - Change Mode.png",
                                                              imagePopupTitle: "CIGALHE MFD Bezel"), cancellationToken);
            }
            PostHeader(ReceivedExpectedHeader);
            GradeResultAndTallyPassFail(operatorResponse, expectedResponse); //checks if the response is the expected response (pass/fail)
            PostOperatorResponse(operatorResponse, expectedResponse); // prints result

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }


        //------------------------------------------- Section 5.1 -------------------------------------------

        internal async Task Test14_TestPowerOffAsync(CancellationToken cancellationToken)
        { 
            SetUpTestSection("5. Power Off", "5.1.", "Power Off", cancellationToken);

            _unitsOfMeasure = "---";
            DialogResult expectedResponse = DialogResult.Yes;
            DialogResult operatorResponse;

            TurnOffMFDPowerSupply();

            await Task.Run(() => Popup.Show("On the Topward 3306D Power Supply, turn the VOLTAGE knob all the way counterclockwise (minimum).\n",
                                            title: "Minimize Bezel Backlighting Voltage"), cancellationToken);

            string prompt = "Did the MFD display and bezel buttons backlighting turn off?";
            PostUserPromptToTestResults("   " + prompt, doubleSpaced: true);
            operatorResponse = await Task.Run(() => Popup.Show(prompt, "Power Off MFD", MessageBoxButtons.YesNo), cancellationToken);
            PostHeader(ReceivedExpectedHeader);
            GradeResultAndTallyPassFail(operatorResponse, expectedResponse); //checks if the response is the expected response (pass/fail)
            PostOperatorResponse(operatorResponse, expectedResponse); //prints result

            AudibleAlert();
            PostSubTestPassFailFooter();
            UpdateTestNameAndStatusFields("Finished");
            await Task.Delay(600, cancellationToken);
        }


        /*************************************************************************************************************/

        private void PromptUserToPrepareRoom()
        {
            // Turn on the supplemental light source
            SwitchSupplementalLight(Power.ON);
            Thread.Sleep(600);
            Popup.Show("Hang test-in-progress sign on the outside of the dark room door.\n" +
                       "Close the door and turn off the room lights.", title: "Room Lights");
        }

        private void PromptUserToTurnOnBacklighting()
        {
            // Show a popup to the user instructing them to turn on the bezel backlighting using the power supply
            Popup.Show("On the Topward 3306D Power Supply, turn the VOLTAGE knob clockwise until the displayed voltage is 26 V to 28 V.\n",
                       title: "Turn ON Bezel Backlighting");
        }

        private void PromptUserToPowerOnMFD()
        {
            // Show a popup with an image, instructing the user to turn on the MFD power supply
            PopupWithPicture.Show("Turn on the MFD Power Supply and\n\n" +
                                  "         IMMEDIATELY DISMISS THIS PROMPT.",
                                  title: "Power On MFD",
                                  pictureFile: ImagesFolder + "MFD Power Supply -- Power ON.png");
        }

        private void PostElapsedTimeResult(TimeSpan elapsedTime, int upperLimit)
        {
            // Post the prompt and results of the elapsed time measurement to the test results
            string prompt = "The MFD displayed three flight instruments on a terrain image within 120 seconds.";
            PostUserPromptToTestResults("   " + prompt, doubleSpaced: true);
            PostHeader(UpperLimitOnlyHeader);

            // Grade the result and tally pass/fail
            GradeResultAndTallyPassFail(elapsedTime.TotalSeconds, 0, upperLimit);

            // Post the measurement result
            PostMeasurement(MeasurementUpperLimitInt, "", (int)elapsedTime.TotalSeconds, null, upperLimit);
        }

        private void PromptUserToDisplayColorBars()
        { // Show a popup to the user instructing them to display the color bar pattern on the MFD
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Simultaneously press S24 and S7 bezel buttons to display color bar pattern on MFD.\n\n" +
                      "          (Click the blue Help button at upper right to view bezel diagram.)",
                       title: "Display Color Bars", msgBoxButtons: MessageBoxButtons.OK,
                       imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png", 
                       imagePopupTitle: "ROSE MFD Bezel");
                Thread.Sleep(600);
            }
            else
            {
                Popup.Show("Simultaneously press S24 and S7 bezel buttons to display color bar pattern on MFD.\n\n" +
                      "          (Click the blue Help button at upper right to view bezel diagram.)",
                       title: "Display Color Bars", msgBoxButtons: MessageBoxButtons.OK,
                       imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                       imagePopupTitle: "CIGALHE MFD Bezel");
                Thread.Sleep(600);
            }
           
        }

        private void PromptUserToSetDayMode()
        {
            // Show a popup to the user instructing them to set the MFD to Day mode
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to Day mode by pressing bezel button S19 until the Power On LED\n" +
                      "in the upper left corner of the bezel is brightest.\n\n" +
                      "          (Click the blue Help button at upper right to view bezel diagram.)",
                       title: "IMPORTANT - Set Day Mode", msgBoxButtons: MessageBoxButtons.OK,
                       imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                       imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to Day mode by pressing bezel button S19 until the Power On LED\n" +
                                       "in the upper left corner of the bezel is brightest.\n\n" +
                                       "          (Click the blue Help button at upper right to view bezel diagram.)",
                                        title: "IMPORTANT - Set Day Mode", msgBoxButtons: MessageBoxButtons.OK,
                                        imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                                        imagePopupTitle: "CIGALHE MFD Bezel");
            }
                
        }

        private void PromptUserToTurnOffBacklighting()
        {
            // Show a popup to the user instructing them to turn off the LCD backlighting
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to Day mode and BLACK test pattern.\n\n" +
                       "Press and hold LUM\u2212 bezel button until LCD backlighting is off.\n" +
                       "(LUM = 0).", title: "LCD Backlighting Off",
                        msgBoxButtons: MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                        imagePopupTitle: "ROSE MFD Bezel"); 
            }
            else
            {
                Popup.Show("Set MFD to Day mode and BLACK test pattern.\n\n" +
                       "Press and hold LUM\u2212 bezel button until LCD backlighting is off.\n" +
                       "(LUM = 0).", title: "LCD Backlighting Off",
                        msgBoxButtons: MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                        imagePopupTitle: "CIGALHE MFD Bezel");
            }
            _uutMediumBrightness = false;

            // Turn on the supplemental light source if it is off
            if (_supplementalLightState == Power.OFF) SwitchSupplementalLight(Power.ON);
        }

        private void PromptUserToViewFromDistance()
        {
            // Show a popup to the user instructing them to view the UUT from a specified distance
            Popup.Show("For these tests, view the UUT from a distance of approximately\n" +
                       "28 inches.", "Viewing Distance");
        }

        private void EvaluateScratches(ScratchesForm frmScratches)
        {
            // Calculate the total lengths of medium and heavy scratches
            int mediumScratchesLength = AddUpLengthsOfScratches(frmScratches.txtMediumScratchesLengths.Text);
            int heavyScratchesLength = AddUpLengthsOfScratches(frmScratches.txtHeavyScratchesLengths.Text);
            _unitsOfMeasure = "mm";

            // Post the user prompt and results of the scratches evaluation
            PostUserPromptToTestResults("   Total lengths of scratches:", doubleSpaced: true);
            PostHeader(ScratchesLengthsHeader);
            GradeResultAndTallyPassFail(heavyScratchesLength, 0, HeavyScratchesTotalLengthMaximum, includeLimits: "[]");
            PostMeasurement(ScratchesLengthsFormat, "> 0.25 mm wide", heavyScratchesLength, null, HeavyScratchesTotalLengthMaximum);
            GradeResultAndTallyPassFail(mediumScratchesLength, 0, MediumScratchesTotalLengthMaximum, includeLimits: "[]");
            PostMeasurement(ScratchesLengthsFormat, "0.1 to 0.25 mm wide", mediumScratchesLength, null, MediumScratchesTotalLengthMaximum);

            // Reset units of measure
            _unitsOfMeasure = "---";

            // Post additional user prompts and results for fine scratches
            PostBlankLines(numLines: 2);
            PostUserPromptToTestResults("   Is the display free of concentrations of fine scratches (< 0.1 mm wide)");
            PostUserPromptToTestResults("      that would appear as smudges?", doubleSpaced: true);
            PostHeader(ReceivedExpectedHeader);

            // Determine if the display is free of smudges and post the result
            DialogResult operatorResponse = frmScratches.radYesSmudges.Checked ? DialogResult.Yes : DialogResult.No;
            GradeResultAndTallyPassFail(operatorResponse, expectedResponse: DialogResult.Yes);
            PostOperatorResponse(operatorResponse, expectedResponse: DialogResult.Yes);
        }

        private void EvaluateDefectivePixels(FailedPixelsForm frmFailedPixels)
        {
            // Set units of measure to pixels
            _unitsOfMeasure = "pixels";

            // Grade and post results for stuck OFF pixels
            GradeResultAndTallyPassFail(frmFailedPixels.numStuckOFF.Value, 0, PixelsStuckOffMaximum, includeLimits: "[]");
            PostMeasurement(FailedPixelCountsFormat, "Failed OFF", decimal.ToInt32(frmFailedPixels.numStuckOFF.Value),
                null, PixelsStuckOffMaximum);

            // Grade and post results for stuck ON pixels
            GradeResultAndTallyPassFail(frmFailedPixels.numStuckON.Value, 0, PixelsStuckOnMaximum, includeLimits: "[]");
            PostMeasurement(FailedPixelCountsFormat, "Failed ON", decimal.ToInt32(frmFailedPixels.numStuckON.Value),
                null, PixelsStuckOnMaximum);

            // Set units of measure to clusters
            _unitsOfMeasure = "clusters";

            // Grade and post results for 2-pixel failures
            GradeResultAndTallyPassFail(frmFailedPixels.num2PixelFailures.Value, 0, Failed2PixelClustersMaximum, includeLimits: "[]");
            PostMeasurement(FailedPixelCountsFormat, "2 failed pixels", decimal.ToInt32(frmFailedPixels.num2PixelFailures.Value),
                null, Failed2PixelClustersMaximum);

            // Grade and post results for 3-5 pixel failures
            GradeResultAndTallyPassFail(frmFailedPixels.num3To5PixelFailures.Value, 0, Failed3To5PixelClusterMaximum, includeLimits: "[]");
            PostMeasurement(FailedPixelCountsFormat, "3-5 failed pixels", decimal.ToInt32(frmFailedPixels.num3To5PixelFailures.Value),
                null, Failed3To5PixelClusterMaximum);

            // Post results for failed pixels proximity
            PostFailedPixelsProximityResults(frmFailedPixels);
        }

        private void PostDefectivePixelResults(FailedPixelsForm frmFailedPixels)
        {
            bool bPassed;
            string pfStatus;
            string pfReceived;
            string textColor;

            // Set units of measure to pixels
            _unitsOfMeasure = "pixels";

            // Determine pass/fail status for single pixel failures and post result
            bPassed = frmFailedPixels.radNoSinglesNearOthers.Checked;
            SetPassFailStatusAndTallyPassFail(bPassed);
            pfReceived = bPassed ? "No" : "Yes";
            pfStatus = bPassed ? "Pass" : "Fail";
            textColor = bPassed ? "Green" : "Red";
            PostLineOfText(String.Format(FailedNearEachOtherFormat,
                "Failed within 1 cm", pfReceived, "No", _unitsOfMeasure, pfStatus), colorName: textColor);

            // Set units of measure to clusters
            _unitsOfMeasure = "clusters";

            // Determine pass/fail status for cluster pixel failures and post result
            bPassed = frmFailedPixels.radNoClustersNearOthers.Checked;
            SetPassFailStatusAndTallyPassFail(bPassed);
            pfReceived = bPassed ? "No" : "Yes";
            pfStatus = bPassed ? "Pass" : "Fail";
            textColor = bPassed ? "Green" : "Red";
            PostLineOfText(String.Format(FailedNearEachOtherFormat,
                "Failed within 3 cm", pfReceived, "No", _unitsOfMeasure, pfStatus), colorName: textColor);
        }

        private void PostFailedPixelsProximityResults(FailedPixelsForm frmFailedPixels)
        {
            // Post blank lines and header for received/expected results
            PostBlankLines(numLines: 2);
            PostHeader(ReceivedExpectedHeader);

            bool bPassed;
            string pfStatus;
            string pfReceived;
            string textColor;

            // Set units of measure to pixels
            _unitsOfMeasure = "pixels";

            // Determine pass/fail status for single pixel failures and post result
            bPassed = frmFailedPixels.radNoSinglesNearOthers.Checked;
            SetPassFailStatusAndTallyPassFail(bPassed);
            pfReceived = bPassed ? "No" : "Yes";
            pfStatus = bPassed ? "Pass" : "Fail";
            textColor = bPassed ? "Green" : "Red";
            PostLineOfText(String.Format(FailedNearEachOtherFormat,
                "Failed within 1 cm", pfReceived, "No", _unitsOfMeasure, pfStatus), colorName: textColor);

            // Set units of measure to clusters
            _unitsOfMeasure = "clusters";

            // Determine pass/fail status for cluster pixel failures and post result
            bPassed = frmFailedPixels.radNoClustersNearOthers.Checked;
            SetPassFailStatusAndTallyPassFail(bPassed);
            pfReceived = bPassed ? "No" : "Yes";
            pfStatus = bPassed ? "Pass" : "Fail";
            textColor = bPassed ? "Green" : "Red";
            PostLineOfText(String.Format(FailedNearEachOtherFormat,
                "Failed within 3 cm", pfReceived, "No", _unitsOfMeasure, pfStatus), colorName: textColor);
        }

        private async Task TestContrastAtMultipleAnglesAsync(List<KeyValuePair<string, int>> contrastRatios, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await TestContrastAtOneAngleAsync("+45", "+30", contrastRatios, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            await TestContrastAtOneAngleAsync("+45", "-10", contrastRatios, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            await TestContrastAtOneAngleAsync("-45", "-10", contrastRatios, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            await TestContrastAtOneAngleAsync("-45", "+30", contrastRatios, cancellationToken);
        }

        private void PostContrastResults(List<KeyValuePair<string, int>> contrastRatios)
        {
            // Post blank lines and header for contrast results
            PostBlankLines(numLines: 2);
            PostCalculatedResultHeader("Contrast");

            // Set units of measure to none
            _unitsOfMeasure = "---";

            // Grade and post results for each contrast ratio
            foreach (var contrast in contrastRatios)
            {
                if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
                {
                    GradeResultAndTallyPassFail(contrast.Value, ContrastRatioLowerLimit, ContrastRatioUpperLimitRose);
                    PostMeasurement(MeasurementFormatInt, contrast.Key, contrast.Value, ContrastRatioLowerLimit, ContrastRatioUpperLimitRose);
                }
                else
                {
                    GradeResultAndTallyPassFail(contrast.Value, ContrastRatioLowerLimit, ContrastRatioUpperLimit);
                    PostMeasurement(MeasurementFormatInt, contrast.Key, contrast.Value, ContrastRatioLowerLimit, ContrastRatioUpperLimit);
                }
            }
        }

        private async Task TestBrightnessAsync(string level, string description, bool playProgressSound, CancellationToken cancellationToken )
        {
            // Test the center brightness at the specified level and description
            await TestCenterBrightnessAsync(level, description, playProgressSound, cancellationToken);

            // Set medium brightness flag to false
            _uutMediumBrightness = false;
        }

        private void PostCornerBrightnessResults()
        {
            // Post blank lines and header for corner brightness results
            PostBlankLines(numLines: 2);
            PostLineOfText("   Maximum - Corners of Viewing Envelope:\n", bold: true);
            PostHeader(LowerLimitOnlyHeader);

            // Post brightness results for each corner of the viewing envelope
            PostCornerOfEnvelopeBrightness(_nonNormalMaxWhiteReadings[0], "H:+45, V:+30 deg.");
            PostCornerOfEnvelopeBrightness(_nonNormalMaxWhiteReadings[1], "H:+45, V:-10 deg.");
            PostCornerOfEnvelopeBrightness(_nonNormalMaxWhiteReadings[2], "H:-45, V:-10 deg.");
            PostCornerOfEnvelopeBrightness(_nonNormalMaxWhiteReadings[3], "H:-45, V:+30 deg.");
        }

        private void PostLuminanceResults()
        {
            double luminanceMin = 999, luminanceMax = 0;
            double luminanceAverage = 0;
            double sum = 0;
            string minPoint = "", maxPoint = "";

            // Calculate the minimum, maximum, and average luminance
            foreach (var measurement in _measurements[TestColor.White_Day])
            {
                if (measurement.Value.Lv < luminanceMin)
                {
                    luminanceMin = measurement.Value.Lv;
                    minPoint = measurement.Key;
                }
                if (measurement.Value.Lv > luminanceMax)
                {
                    luminanceMax = measurement.Value.Lv;
                    maxPoint = measurement.Key;
                }

                sum += measurement.Value.Lv;
            }
            luminanceAverage = sum / _measurements[TestColor.White_Day].Count;

            // Post the luminance results
            PostBlankLine();
            PostLineOfText(ReadingsTableIndent + $"Average Brightness : {luminanceAverage:f2} fL");
            PostLineOfText(ReadingsTableIndent + $"Minimum Brightness, found at point {minPoint} : {luminanceMin:f2} fL");
            PostLineOfText(ReadingsTableIndent + $"Maximum Brightness, found at point {maxPoint} : {luminanceMax:f2} fL");

            // Post blank lines and header for homogeneity results
            PostBlankLines(numLines: 2);
            PostHeader(MeasurementHeader);

            // Calculate and post homogeneity results
            double Hf = luminanceMin / luminanceMax;
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                GradeResultAndTallyPassFail(Hf, LuminanceHomogeneityLowerLimitRose, LuminanceHomogeneityUpperLimit, includeLimits: "[]");
                _unitsOfMeasure = "---";
                PostMeasurement(MeasurementFormatDbl2, "Homogeneity", Hf, LuminanceHomogeneityLowerLimit, LuminanceHomogeneityUpperLimit);
            }
            else
            {
                GradeResultAndTallyPassFail(Hf, LuminanceHomogeneityLowerLimit, LuminanceHomogeneityUpperLimit, includeLimits: "[)");
                _unitsOfMeasure = "---";
                PostMeasurement(MeasurementFormatDbl2, "Homogeneity", Hf, LuminanceHomogeneityLowerLimit, LuminanceHomogeneityUpperLimit);
            }
        }

        private async Task TestColorCoordinatesAtMultipleSpots_DayAsync(CancellationToken cancellationToken)
        {
            // Test color coordinates at multiple spots in Day mode
            if(lblUUTPartNo.Text == " MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#5", position: _XYTable.LCD_middleCenterViewingSpot, cancellationToken);
                PostBlankLine();
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#3", position: _XYTable.LCD_topRightViewingSpot_Rose, cancellationToken);
                PostBlankLine();
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#1", position: _XYTable.LCD_topLeftViewingSpot_Rose, cancellationToken);
                PostBlankLine();
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#7", position: _XYTable.LCD_bottomLeftViewingSpot_Rose, cancellationToken);
                PostBlankLine();
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#9", position: _XYTable.LCD_bottomRightViewingSpot_Rose, cancellationToken);
            }
            else
            {
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#5", position: _XYTable.LCD_middleCenterViewingSpot, cancellationToken);
                PostBlankLine();
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#3", position: _XYTable.LCD_topRightViewingSpot, cancellationToken);
                PostBlankLine();
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#1", position: _XYTable.LCD_topLeftViewingSpot, cancellationToken);
                PostBlankLine();
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#7", position: _XYTable.LCD_bottomLeftViewingSpot, cancellationToken);
                PostBlankLine();
                await TestColorCoordinatesAtOneSpotAsync_Day(testPoint: "#9", position: _XYTable.LCD_bottomRightViewingSpot, cancellationToken);
            }
            
        }

        private async Task PostChromaUniformityResultsAsync(CancellationToken cancellationToken)
        {

            // Post blank lines and header for chroma uniformity results
            PostLineOfText("\n\n\nCheck Chroma Uniformity:\n", bold: true, underline: true);
            PostHeader(MeasurementHeader);

            // Test and post chroma uniformity results for each color in Day mode
            await TestChromaUniformityAsync(TestColor.White_Day, ChromaUniformityWhiteLowerLimit, ChromaUniformityWhiteUpperLimit, cancellationToken);
            await TestChromaUniformityAsync(TestColor.Red_Day, ChromaUniformityRedLowerLimit, ChromaUniformityRedUpperLimit, cancellationToken);
            await TestChromaUniformityAsync(TestColor.Green_Day, ChromaUniformityGreenLowerLimit, ChromaUniformityGreenUpperLimit, cancellationToken);
            await TestChromaUniformityAsync(TestColor.Blue_Day, ChromaUniformityBlueLowerLimit, ChromaUniformityBlueUpperLimit, cancellationToken);
        }

        private void PromptUserToDisplayWhiteNVG()
        {
            // Show a popup to the user instructing them to display white in NVG mode at maximum brightness
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to display WHITE, in NVG mode and maximum brightness (LUM = 127).", "Display White",
                      MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                      imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to display WHITE, in NVG mode and maximum brightness (LUM = 127).", "Display White",
                       MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                       imagePopupTitle: "CIGALHE MFD Bezel");
            }
            // Set medium brightness flag to false
            _uutMediumBrightness = false;

            // Turn off the light and cover the monitor
            AudibleAlert();
            TurnOffLightAndCoverMonitor();
        }

        private void ValidateWhiteReading(LightReading whiteReading)
        {
            // If the white reading is too bright, show an alert and take a new measurement
            if (whiteReading.Lv > 2 * BrightnessNVGMaxUpperLimit)
            {

                Popup.Show("Display is too bright.  Check that Display is in NVG mode, then set to maximum brightness.", "Not in NVG Mode");
                TurnOffLightAndCoverMonitor();
                whiteReading = _ChromaMeter.TakeMeasurement();
            }
        }

        private async Task TestBrightnessNVGAsync(CancellationToken cancellationToken)
        {
            PostLineOfText("\n\n" + "   Minimum - Center-of-Display, Normal Incidence:\n", bold: true);

            // Show a popup to the user instructing them to display white in NVG mode at minimum brightness
            AudibleAlert();
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to display WHITE, in NVG mode and minimum brightness (LUM = 1).\n\n" +
                       "(Temporarily cover PC monitor to help see minimum brightness.)",
                       title: "White - NVG Mode",
                       MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                       imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to display WHITE, in NVG mode and minimum brightness (LUM = 1).\n\n" +
                       "(Temporarily cover PC monitor to help see minimum brightness.)",
                       title: "White - NVG Mode",
                       MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                       imagePopupTitle: "CIGALHE MFD Bezel");
            }
            // Set medium brightness flag to false
            _uutMediumBrightness = false;

            // Turn off the light and cover the monitor, then take a new measurement
            AudibleAlert();
            TurnOffLightAndCoverMonitor("NOTE: The following measurement can take up to 60 seconds.");
            await TakeLightReadingWithConditionalProgressSoundAsync(TestColor.White_NVG, "#5", true, cancellationToken);

            // Retrieve the light reading from the measurements
            LightReading whiteReading = _measurements[TestColor.White_NVG]["#5"];

            // Post the measurement result and grade the result
            PostHeader(MeasurementHeader);
            GradeResultAndTallyPassFail(whiteReading.Lv, BrightnessNVGMinLowerLimit, BrightnessNVGMinUpperLimit, includeLimits: "[)");
            PostMeasurement(MeasurementFormatDbl3, " ", whiteReading.Lv, BrightnessNVGMinLowerLimit, BrightnessNVGMinUpperLimit);
        }


        private void DecreaseBezelBacklighting()
        {
            Popup.Show("Slowly lower the voltage until the bezel button backlighting turns off (below 10 V).\n\n" +
                       "    (Cover PC monitor while observing the bezel and press Enter key when done.)",
                       title: "Decrease Bezel Backlighting", disableButton: true);
            Thread.Sleep(600);
        }

        private void CheckBacklightingDecreaseUniformity()
        {
            string prompt = "Did the backlighting of the bezel buttons DECREASE uniformly from full brightness to none?";
            PostUserPromptToTestResults("   " + "Did bezel backlighting decrease uniformly from full brightness to none?", doubleSpaced: true);
            DialogResult operatorResponse = Popup.Show(prompt, "Backlighting: Full Brightness-to-Off", MessageBoxButtons.YesNo);
            DialogResult expectedResponse = DialogResult.Yes;

            PostHeader(ReceivedExpectedHeader);
            GradeResultAndTallyPassFail(operatorResponse, expectedResponse);
            PostOperatorResponse(operatorResponse, expectedResponse);
            PostBlankLines(numLines: 2);
            Thread.Sleep(600);
        }

        private void IncreaseBezelBacklighting()
        {
            Popup.Show("Now, slowly increase the voltage up to 28 V while observing the bezel button backlighting.\n\n" +
                       "    (Cover PC monitor while observing the bezel and press Enter key when done.)",
                       title: "Increase Bezel Backlighting", disableButton: true);
            Thread.Sleep(600);
        }

        private void CheckBacklightingIncreaseUniformity()
        {
            string prompt = "Did the backlighting of the bezel buttons INCREASE uniformly from none to full brightness?";
            PostUserPromptToTestResults("   " + "Did bezel backlighting increase uniformly from none to full brightness?", doubleSpaced: true);
            DialogResult operatorResponse = Popup.Show(prompt, "Backlighting: Off-to-Full Brightness", MessageBoxButtons.YesNo);
            DialogResult expectedResponse = DialogResult.Yes;

            PostHeader(ReceivedExpectedHeader);
            GradeResultAndTallyPassFail(operatorResponse, expectedResponse);
            PostOperatorResponse(operatorResponse, expectedResponse);
        }

        private void PostBlemishResults(BlemishesForm blemishesForm)
        {
            _unitsOfMeasure = "each";

            // Post user prompt and results for counts of blemishes
            PostUserPromptToTestResults("   Counts of blemishes:", doubleSpaced: true);
            PostHeader(MaximumAllowedHeader);
            GradeResultAndTallyPassFail(blemishesForm.numLargeBlemishes.Value, 0, LargeBlemishesMaximum, includeLimits: "[]");
            PostMeasurement(BlemishesCountsFormat, "> 0.50 mm", Decimal.ToInt32(blemishesForm.numLargeBlemishes.Value),
                null, LargeBlemishesMaximum);
            GradeResultAndTallyPassFail(blemishesForm.numMediumBlemishes.Value, 0, MediumBlemishesMaximum, includeLimits: "[]");
            PostMeasurement(BlemishesCountsFormat, "0.15 to 0.50 mm", Decimal.ToInt32(blemishesForm.numMediumBlemishes.Value),
                null, MediumBlemishesMaximum);
            _unitsOfMeasure = "---";

            // Post additional user prompts and results for small blemishes
            PostBlankLines(numLines: 2);
            PostUserPromptToTestResults("   Is the display free of concentrations of small blemishes (< 0.15 mm)");
            PostUserPromptToTestResults("      that would appear as smudges?", doubleSpaced: true);
            PostHeader(ReceivedExpectedHeader);

            // Determine if the display is free of smudges and post the result
            DialogResult operatorResponse = blemishesForm.radYesSmudgeFree.Checked ? DialogResult.Yes : DialogResult.No;
            GradeResultAndTallyPassFail(operatorResponse, expectedResponse: DialogResult.Yes);
            PostOperatorResponse(operatorResponse, expectedResponse: DialogResult.Yes);
        }

        private void PromptUserToAdjustBezelBacklighting()
        {
            Popup.Show("Verify bezel backlighting voltage is 28 V and adjust if necessary.\n",
                       title: "Maximum Bezel Backlighting");

            string prompt1, prompt2, prompt3;
            DialogResult expectedResponse = DialogResult.Yes;
            DialogResult operatorResponse;
            Thread.Sleep(600);

            // Show a popup to the user with instructions for examining bezel legends
            prompt1 = "Click the Help icon (above right) to see an image of bezel legends to examine.";
            prompt2 = "Are all bezel legends illuminated uniformly?";
            prompt3 = "  (Cover PC monitor while observing the bezel.)";
            PostUserPromptToTestResults("   " + prompt2, doubleSpaced: true);
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                operatorResponse = Popup.Show(prompt1 + "\n\n" + prompt2 + "\n\n" + prompt3,
                                          title: "Bezel Legends", MessageBoxButtons.YesNo,
                                          imageFile: ImagesFolder + "ROSE Bezel Buttons - Legends.png",
                                          imagePopupTitle: "Bezel Legends");

            }
            else
            {
                operatorResponse = Popup.Show(prompt1 + "\n\n" + prompt2 + "\n\n" + prompt3,
                                          title: "Bezel Legends", MessageBoxButtons.YesNo,
                                          imageFile: ImagesFolder + "MFD Bezel Buttons - Legends.png",
                                          imagePopupTitle: "Bezel Legends");
            }
            

            // Post header and result for bezel legends examination
            PostHeader(ReceivedExpectedHeader);
            GradeResultAndTallyPassFail(operatorResponse, expectedResponse);
            PostOperatorResponse(operatorResponse, expectedResponse);
            PostBlankLines(numLines: 2);
            Thread.Sleep(600);

            // Show a popup to the user asking if the bezel is free of scratches or light leakages
            string prompt = "Is the Bezel free of scratches or light leakages?";
            PostUserPromptToTestResults("   " + prompt, doubleSpaced: true);
            operatorResponse = Popup.Show(prompt, "Bezel Scratches/Light Leakages", MessageBoxButtons.YesNo);

            // Post header and result for bezel scratches/light leakages examination
            PostHeader(ReceivedExpectedHeader);
            GradeResultAndTallyPassFail(operatorResponse, expectedResponse);
            PostOperatorResponse(operatorResponse, expectedResponse);
            PostBlankLines(numLines: 2);
            Thread.Sleep(600);
        }

        private void SetUpTestSection(string task, string section, string testName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested(); 

            // Sets the task, section, and test name
            _task = task;
            _testSection = section;
            _testName = testName;

            // Remove any existing pass/fail tallies for the test section
            _pfTallies.Remove(_testSection);

            // Update the test name and status fields to "Running"
            UpdateTestNameAndStatusFields("Running");

            // Post the section heading, date and time, and a blank line
            PostSectionHeading("Section " + _testSection + "    " + _testName);
            PostDateAndTime();
            PostBlankLine();
        }

        private int AddUpLengthsOfScratches(string strScratchesLengths)
        {//Initializes An array with measurements, adds up the entries in 
         //the array to return the total length of scratches 
            char[] separators = new char[] { ',', ' ' };
            string[] aryScratchesLengths = strScratchesLengths.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int totalScratchesLength = 0;
            foreach (var scratchLength in aryScratchesLengths)
            {
                totalScratchesLength += Convert.ToInt32(scratchLength);
            }

            return totalScratchesLength;
        }

        private double AdjustBrightness(double lowerLimit, double upperLimit)
        {//returns parsed brightness value
            double Lv = 0;

            UUTBrightnessForm frmUUTBrightness = new UUTBrightnessForm(_ChromaMeter, lowerLimit, upperLimit);
            frmUUTBrightness.ShowDialog();
            Double.TryParse(frmUUTBrightness.lblBrightnessValue.Text, out Lv);

            return Lv;
        }

        private async Task AdjustUUTtoMediumBrightnessAsync(Mode mode, CancellationToken cancellationToken = default)
        {
            if (_uutMediumBrightness == false)
            {
                string strMode = mode.ToString();

                if (_supplementalLightState == Power.OFF) SwitchSupplementalLight(Power.ON);
                SetTiltTableNormal();

                await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken).ConfigureAwait(false);

                if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
                {
                    Popup.Show($"Set MFD to display WHITE, in {strMode} mode and medium brightness (approximate).",
                           title: $"White - {strMode} Mode",
                           MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                           imagePopupTitle: "ROSE MFD Bezel");
                }
                else
                {
                    Popup.Show($"Set MFD to display WHITE, in {strMode} mode and medium brightness (approximate).",
                           title: $"White - {strMode} Mode",
                           MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                           imagePopupTitle: "CIGALHE MFD Bezel");
                }
                if (_supplementalLightState == Power.ON) SwitchSupplementalLight(Power.OFF);
                AdjustUUTBrightnessAndPostValue("White", mode);
                _uutMediumBrightness = true;
            }
        }

        private void AdjustUUTBrightnessAndPostValue(string color, Mode mode)
        {// adjusts brightness and ensures it is within specified limits for the mode
            double lowerLimit, upperLimit;

            if (mode == Mode.Day) //determine brightness limits based on mode
            {
                lowerLimit = BrightnessDayNormalMedLowerLimit;
                upperLimit = BrightnessDayNormalMedUpperLimit;
            }
            else if (mode == Mode.NVG) // determine brightness limits based on mode
            {
                lowerLimit = BrightnessNVGMedLowerLimit;
                upperLimit = BrightnessNVGMedUpperLimit;
            }
            else //mode == Mode.Night
            {
                // Need to throw an exception here
                // instead of assigning zeroes
                lowerLimit = 0;
                upperLimit = 0;
            }

            DialogResult userRetry;
            bool brightnessInSpec;
            double Lv;
            do
            {
                userRetry = DialogResult.No;
                Lv = AdjustBrightness(lowerLimit, upperLimit);
                brightnessInSpec = (lowerLimit < Lv) && (Lv < upperLimit); // checks if adjusted brightness is within specs
                if (brightnessInSpec == false)
                {
                    userRetry = Popup.Show($"Brightness is {Lv}, should be between {lowerLimit} " +
                                           $"and {upperLimit}\n\n" +
                                            "Do you want to try readjusting it?",
                                            "Incorrect Brightness", MessageBoxButtons.YesNo);
                }
            } while (userRetry == DialogResult.Yes);

            if (brightnessInSpec)
            {
                PostLineOfText($"   MFD brightness set to {Lv} fL.");
            }
            else
            {
                PostHeader(MeasurementHeader);
                GradeResultAndTallyPassFail(Lv, lowerLimit, upperLimit);
                _unitsOfMeasure = "fL";
                if (lowerLimit < 1.0)
                {
                    PostMeasurement(MeasurementFormatDbl2, $"{color} Test Pattern", Lv,
                        lowerLimit, upperLimit);
                }
                else
                {
                    PostMeasurement(MeasurementFormatDbl1Int, $"{color} Test Pattern", Lv,
                        Convert.ToInt32(lowerLimit), Convert.ToInt32(upperLimit));
                }

                PostBlankLines(numLines: 2);
            }
        }

        private static void AudibleAlert()
        {
            Console.Beep(800, 700); Console.Beep(800, 700);
        }

        private double CalculateColorDistance(LightReading lightReadingOne, LightReading lightReadingTwo)
        {//returns color distance 
            return CalculateColorDistance(lightReadingOne.UPrime, lightReadingOne.VPrime,
                lightReadingTwo.UPrime, lightReadingTwo.VPrime);
        }

        private double CalculateColorDistance(double uPrime1, double vPrime1, double uPrime2, double vPrime2)
        {//calculates the color distance 
            double uPrimeDelta, vPrimeDelta, colorDistance;

            uPrimeDelta = uPrime1 - uPrime2;
            vPrimeDelta = vPrime1 - vPrime2;
            colorDistance = Math.Sqrt((uPrimeDelta * uPrimeDelta) + (vPrimeDelta * vPrimeDelta));

            return colorDistance;
        }

        private double CalculateColorRadius(LightReading lightReading, double targetUPrime, double targetVPrime)
        {//returns color radius
            return CalculateColorDistance(lightReading.UPrime, lightReading.VPrime,
                targetUPrime, targetVPrime);
        }

        private int CountSelectedTests()
        {//returns the number of tests checked
            int numTestsSelected = 0;

            int taskIdx = 0;
            foreach (TreeNode taskNode in testSelectionTree.Nodes[0].Nodes)
            {
                int testIdx = 0;
                foreach (TreeNode testNode in taskNode.Nodes)
                {
                    if (testNode.Checked) //checks if each test for each task is checked 
                    {
                        numTestsSelected++;
                    }
                    testIdx++;
                }
                taskIdx++;
            }

            return numTestsSelected;
        }

        private int CountSubtestsInFullTest()
        {//calculates how many tests there are for each task
            int subtestsCount = 0;

            foreach (TreeNode taskNode in testSelectionTree.Nodes[0].Nodes)
            {
                foreach (TreeNode testNode in taskNode.Nodes)
                {
                    subtestsCount++;
                }
            }

            return subtestsCount;
        }

        private void FillOutScratchesForm(ScratchesForm frmScratches)
        {//Prompts the user to fill out fields and checks if all were completed
            bool allFieldsCompleted;

            do
            {
                frmScratches.ShowDialog();

                allFieldsCompleted = frmScratches.chkBacklightingOff.Checked &&
                                     frmScratches.chkAuxLightOn.Checked &&
                                     frmScratches.txtMediumScratchesLengths.Text != "" &&
                                     frmScratches.txtHeavyScratchesLengths.Text != "" &&
                                     (frmScratches.radNoSmudges.Checked || frmScratches.radYesSmudges.Checked);

                if (!allFieldsCompleted)
                {
                    Popup.Show("Must check or enter a value in each field.", "Complete All Fields");
                }

            } while (!allFieldsCompleted);
        }

        private void FillOutBlemishesForm(BlemishesForm blemishesForm)
        {//prompts user to fill out fields and checks if all were completed
            bool allFieldsCompleted;

            do
            {
                blemishesForm.ShowDialog();

                allFieldsCompleted = blemishesForm.radNoSmudgeFree.Checked || blemishesForm.radYesSmudgeFree.Checked;

                if (!allFieldsCompleted)
                {
                    Popup.Show("Must check or enter a value in each field.", "Complete All Fields");
                }

            } while (!allFieldsCompleted);
        }

        private void FillOutFailedPixelsForm(FailedPixelsForm failedPixelsForm)
        {//prompts user to fill out fields and checks if all were completed
            bool allFieldsCompleted;

            do
            {
                failedPixelsForm.ShowDialog();

                allFieldsCompleted = (failedPixelsForm.radNoSinglesNearOthers.Checked || failedPixelsForm.radYesSinglesNearOthers.Checked) &&
                                     (failedPixelsForm.radNoClustersNearOthers.Checked || failedPixelsForm.radYesClustersNearOthers.Checked);

                if (!allFieldsCompleted)
                {
                    Popup.Show("Must check or enter a value in each field.", "Complete All Fields");
                }

            } while (!allFieldsCompleted);
        }

        private string GetColorName(TestColor testColor)
        {//gets name of color
            string colorAndMode = testColor.ToString();
            string color = colorAndMode.Substring(0, colorAndMode.Length - 4);  // strip off "_Day" or "_NVG"
            string colorName = color.Substring(0, 1).ToUpper() + color.Substring(1).ToLower();

            return colorName;
        }

        private void GradeResultAndTallyPassFail(DialogResult operatorResponse, DialogResult expectedResponse)
        {//calls to get tallies for passes and fails
            bool bTestPassed = (operatorResponse == expectedResponse);

            SetPassFailStatusAndTallyPassFail(bTestPassed);
        }

        private void GradeResultToLowerLimitAndTallyPassFail<T, U>(T testValue, U lowerLimit, string includeLimits = "(")
        {
            double value = Convert.ToDouble(testValue);
            double lowLimit = Convert.ToDouble(lowerLimit);

            bool bTestPassed = false;

            switch (includeLimits)
            {
                case "(":
                    bTestPassed = (lowLimit < value);
                    break;
                case "[":
                    bTestPassed = (lowLimit <= value);
                    break;
                default:
                    break;
            }

            SetPassFailStatusAndTallyPassFail(bTestPassed);
        }

        private void GradeResultToUpperLimitAndTallyPassFail<T, U>(T testValue, U upperLimit, string includeLimits = ")") //method never called
        {//checks if value is within the specified range of upper limit , exclusive and inclusive 
            double value = Convert.ToDouble(testValue);
            double uprLimit = Convert.ToDouble(upperLimit);

            bool bTestPassed = false;

            switch (includeLimits)
            {
                case ")": // exclusive case
                    bTestPassed = (value < uprLimit);
                    break;
                case "]": //inclsive case
                    bTestPassed = (value <= uprLimit);
                    break;
                default:
                    break;
            }

            SetPassFailStatusAndTallyPassFail(bTestPassed);
        }

        private void GradeResultAndTallyPassFail<T, U>(T testValue, U lowerLimit, U upperLimit, string includeLimits = "()")
        {//Checks if test value is within the specified range of lower and upper limit
            double value = Convert.ToDouble(testValue);
            double lowLimit = Convert.ToDouble(lowerLimit);
            double highLimit = Convert.ToDouble(upperLimit);

            bool bTestPassed = false; //btest measures brightness

            switch (includeLimits)
            {
                case "()": //exclusive of both limits
                    bTestPassed = (lowLimit < value) && (value < highLimit);
                    break;
                case "[)": // inclusive of lower limit, exclusive of upper limit
                    bTestPassed = (lowLimit <= value) && (value < highLimit);
                    break;
                case "(]": // inclusive of upper limit, exlusive of lower limit
                    bTestPassed = (lowLimit < value) && (value <= highLimit);
                    break;
                case "[]": // inclusive of both limits
                    bTestPassed = (lowLimit <= value) && (value <= highLimit);
                    break;
                default:
                    break;
            }

            SetPassFailStatusAndTallyPassFail(bTestPassed);
        }

        private bool RadiusPassed(double radius, double upperLimit)
        {//checks if the radius is bigger than the upper limit
            return (radius < upperLimit);
        }

        private void SetPassFailStatusAndTallyPassFail(bool testPassed)
        {//Tallies how many tests passed/failed for a section
            if (testPassed)
            {
                _passFailStatus = "Pass";
                if (_pfTallies.ContainsKey(_testSection))
                {
                    _pfTallies[_testSection].Passes += 1;
                }
                else
                {
                    _pfTallies.Add(_testSection, new TestPassFail(_testName, 1, 0));
                }
                _pfTotals.Passes += 1;
            }
            else
            {
                _passFailStatus = "Fail";
                if (_pfTallies.ContainsKey(_testSection))
                {
                    _pfTallies[_testSection].Fails += 1;
                }
                else
                {
                    _pfTallies.Add(_testSection, new TestPassFail(_testName, 0, 1));
                }
                _pfTotals.Fails += 1;
            }

            UpdateFailuresField();
        }

        private void SetTiltTableNormal()
        {//prompts user to set the tilt table normal to the chromameter
            if (_tiltTableAngle != TiltTableAngle.Normal)
            {
                Popup.Show(PopupPromptTiltTableNormal, PopupTitleTiltTableNormal);
                _tiltTableAngle = TiltTableAngle.Normal;
            }
        }

        private void SetTiltTableNormalToUser()
        { //prompts user to add wedge 
            if (_tiltTableAngle != TiltTableAngle.NormalToUser)
            {
                Popup.Show(PopupPromptTiltTableNormalToUser, title: PopupTitleTiltTableNormalToUser,
                           msgBoxButtons: MessageBoxButtons.OK,
                           imageFile: ImagesFolder + "TiltTableNormalToUserWedgeInstructions.png",
                           imagePopupTitle: PopupTitleTiltTableNormalToUser);
                _tiltTableAngle = TiltTableAngle.NormalToUser;
            }
        }

        private void SetUpTopwardPowerSupply()
        {//Prompts the user to set up the power supply
            if (!_topwardPowerSupplyInitialized)
            {
                PopupWithPicture.Show("Setup 1.\n------------\n" +
                                      "DISCONNECT the red and black banana plugs from the Topward 3306D power supply.",
                                      title: "Disconnect Bezel Power Supply",
                                      pictureFile: ImagesFolder + "Topward 3306D.png");

                PopupWithPicture.Show("Setup 2.\n------------\n" +
                                      "With the Topward 3306D power supply turned OFF,\n" +
                                      "   -- Turn the CURRENT knob all the way counterclockwise (minimum).\n" +
                                      "   -- Turn the VOLTAGE knob all the way counterclockwise (minimum).\n",
                                      title: "Turn Knobs Counterclockwise",
                                      pictureFile: ImagesFolder + "Topward 3306D -- knob pointers.png");

                Popup.Show("Setup 3.\n-----------\n" +
                           "Ensure that nothing is connected to the + and \u2212 terminals of the Topward power supply,\n" +
                           "then turn ON the power supply.", title: "Turn ON Power Supply");

                PopupWithPicture.Show("Setup 4.\n------------\n" +
                                      "Turn the CURRENT knob clockwise until the green CV light turns on.\n",
                                      title: "Constant Voltage Light", pictureFile: ImagesFolder + "Topward 3306D -- CV light pointer.png");

                Popup.Show("Setup 5.\n-----------\n" +
                           "Turn the VOLTAGE knob clockwise until the displayed voltage is close to 28 V\n" +
                           "and finish adjusting to 28.0 V with the FINE voltage adjustment knob.", title: "Adjust Voltage");

                Popup.Show("Setup 6.\n-----------\n" +
                           "Turn the CURRENT knob all the way counterclockwise (minimum).\n",
                           title: "Set Minimum Current");

                PopupWithPicture.Show("Setup 7.\n------------\n" +
                                      "Install a 20 AWG or thicker jumper wire between the + and \u2212 terminals\n" +
                                      "of the power supply.", title: "Install Shorting Jumper",
                                      pictureFile: ImagesFolder + "Topward 3306D -- shorting jumper.png");

                Popup.Show("Setup 8.\n-----------\n" +
                           "Turn the CURRENT knob clockwise until the current readout is 0.2 A.\n" +
                           "(You might have to overshoot that value and then adjust back down to it.)\n", title: "Adjust Current Limit");

                Popup.Show("Setup 9.\n-----------\n" +
                           "Remove the shorting wire from the + and \u2212 terminals.\n", title: "Remove Shorting Jumper");

                Popup.Show("Setup 10.\n-------------\n" +
                           "Turn the VOLTAGE knob all the way counterclockwise (minimum).\n", title: "Minimize Voltage");

                PopupWithPicture.Show("Setup 11.\n--------------\n" +
                                      "Plug the red and black banana plugs of the Optical Test harness (MFG-TF0399)\n" +
                                      "into the + and \u2212 terminals of the Topward power supply.\n\n" +
                                      "DOUBLE CHECK POLARITY OF CONNECTIONS", title: "Connect Harness",
                                      pictureFile: ImagesFolder + "Topward 3306D -- harness connections.png");

                _topwardPowerSupplyInitialized = true;
            }
        }

        private static void SwitchSupplementalLight(Power onOffState)
        {//Prompts user to turn supplemental light on/off
            AudibleAlert();
            Popup.Show("Turn " + onOffState + " supplemental light source.", title: "Supplementary Lighting");
            _supplementalLightState = onOffState;
        }

        private async Task TakeLightReadingAsync(TestColor testColor, string point, CancellationToken cancellationToken)
        {
            LightReading lightReading = await Task.Run(() => _ChromaMeter.TakeMeasurement(), cancellationToken);

            // Color correct non-white/black readings
            if (testColor != TestColor.White_Day && testColor != TestColor.Black_Day)
                lightReading = _ColorCorrection.AdjustColor(testColor, lightReading);

            if (_measurements.ContainsKey(testColor))
            {
                _measurements[testColor].Add(point, lightReading);
            }
            else
            {
                var _pointsMeasurements = new SortedList<string, LightReading>();
                _pointsMeasurements.Add(point, lightReading);
                _measurements.Add(testColor, _pointsMeasurements);
            }
        }

        private async Task TakeLightReadingsFromNinePositionsAsync(TestColor testColor, CancellationToken cancellationToken)
        {
            _measurements = new SortedList<TestColor, SortedList<string, LightReading>>();

            if(lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#5", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_middleRightViewingSpot_Rose, cancellationToken);
                await TakeLightReadingAsync(testColor, "#6", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_topRightViewingSpot_Rose, cancellationToken);
                await TakeLightReadingAsync(testColor, "#3", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_topCenterViewingSpot_Rose, cancellationToken);
                await TakeLightReadingAsync(testColor, "#2", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_topLeftViewingSpot_Rose, cancellationToken);
                await TakeLightReadingAsync(testColor, "#1", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_middleLeftViewingSpot_Rose, cancellationToken);
                await TakeLightReadingAsync(testColor, "#4", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_bottomLeftViewingSpot_Rose, cancellationToken);
                await TakeLightReadingAsync(testColor, "#7", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_bottomCenterViewingSpot_Rose, cancellationToken);
                await TakeLightReadingAsync(testColor, "#8", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_bottomRightViewingSpot_Rose, cancellationToken);
                await TakeLightReadingAsync(testColor, "#9", cancellationToken);
            }
            else
            {
                await MoveToPositionWithSoundAsync(_XYTable.LCD_middleCenterViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#5", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_middleRightViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#6", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_topRightViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#3", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_topCenterViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#2", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_topLeftViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#1", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_middleLeftViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#4", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_bottomLeftViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#7", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_bottomCenterViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#8", cancellationToken);

                await MoveToPositionWithSoundAsync(_XYTable.LCD_bottomRightViewingSpot, cancellationToken);
                await TakeLightReadingAsync(testColor, "#9", cancellationToken);
            }
        }

        private async Task TestCenterBrightnessAsync(string brightnessLevel, string brightnessDescription, bool playProgressSound, CancellationToken cancellationToken)
        {
            PostLineOfText($"   {brightnessLevel} - Center-of-Display, Normal Incidence:\n", bold: true);
            AudibleAlert();
            Popup.Show($"Set MFD to display WHITE, in Day mode and {brightnessDescription}.", "Display White");
            string alert = brightnessLevel == "Minimum" ? "NOTE: The following measurement can take up to 60 seconds." : "";
            AudibleAlert();
            TurnOffLightAndCoverMonitor(alert);

            // Use the new method with conditional progress sound
            await TakeLightReadingWithConditionalProgressSoundAsync(TestColor.White_Day, "Center", playProgressSound, cancellationToken);

            // Assuming whiteReading is obtained inside TakeLightReadingWithConditionalProgressSoundAsync and you process it here
            LightReading whiteReading = _measurements[TestColor.White_Day]["Center"];

            switch (brightnessLevel)
            {
                case "Maximum":
                    {
                        PostHeader(MeasurementHeader);
                        if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
                        {
                            GradeResultAndTallyPassFail(whiteReading.Lv, BrightnessDayNormalMaxLowerLimit, BrightnessDayNormalMaxUpperLimit, includeLimits: "[)"); //Rose Upper& lower limit grading
                            PostMeasurement(MeasurementFormatDbl3, " ", whiteReading.Lv, BrightnessDayNormalMaxLowerLimit, BrightnessDayNormalMaxUpperLimit);
                        }
                        else
                        {
                            GradeResultToLowerLimitAndTallyPassFail((int)whiteReading.Lv, BrightnessDayNormalMaxLowerLimit);
                            PostMeasurement(MeasurementLowerLimitDbl1Int, " ", whiteReading.Lv, BrightnessDayNormalMaxLowerLimit, null);
                        }
                    }
                    break;
                case "Minimum":
                    {
                        PostHeader(MeasurementHeader);
                        GradeResultAndTallyPassFail(whiteReading.Lv, BrightnessDayNormalMinLowerLimit, BrightnessDayNormalMinUpperLimit, includeLimits: "[)");
                        PostMeasurement(MeasurementFormatDbl3, " ", whiteReading.Lv, BrightnessDayNormalMinLowerLimit, BrightnessDayNormalMinUpperLimit);
                    }
                    break;
                default:
                    break;
            }
        }

        private async Task TestChromaUniformityAsync(TestColor testColor, double lowerLimit, double upperLimit, CancellationToken cancellationToken)
        {
            double colorDistance, maxColorDistance = 0.0;
            double chromaUniformityLowerLimit = 0.0, chromaUniformityUpperLimit = 0.0;

            switch (testColor) // sets chroma limits based on color
            {
                case TestColor.White_Day:
                    chromaUniformityLowerLimit = ChromaUniformityWhiteLowerLimit;
                    chromaUniformityUpperLimit = ChromaUniformityWhiteUpperLimit;
                    break;
                case TestColor.Red_Day:
                    chromaUniformityLowerLimit = ChromaUniformityRedLowerLimit;
                    chromaUniformityUpperLimit = ChromaUniformityRedUpperLimit;
                    break;
                case TestColor.Green_Day:
                    chromaUniformityLowerLimit = ChromaUniformityGreenLowerLimit;
                    chromaUniformityUpperLimit = ChromaUniformityGreenUpperLimit;
                    break;
                case TestColor.Blue_Day:
                    chromaUniformityLowerLimit = ChromaUniformityBlueLowerLimit;
                    chromaUniformityUpperLimit = ChromaUniformityBlueUpperLimit;
                    break;
                default:
                    break;
            }

            LightReading[] lightReadings = new LightReading[5];
            int n = 0;
            foreach (var measurement in _measurements[testColor])
            {
                lightReadings[n++] = measurement.Value; // iterates through measurements for each testColor and stores in lightReadings
            }

            await Task.Run(() =>
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = i + 1; j < 5; j++)
                    {
                        colorDistance = CalculateColorDistance(lightReadings[i], lightReadings[j]);
                        if (colorDistance > maxColorDistance) maxColorDistance = colorDistance;
                    }
                }
            }, cancellationToken); // calculates the distance between two color readings

            GradeResultAndTallyPassFail(maxColorDistance, chromaUniformityLowerLimit, chromaUniformityUpperLimit, includeLimits: "[)");
            string colorName = GetColorName(testColor);
            PostMeasurement(MeasurementFormatDbl3, "dRadius " + colorName, maxColorDistance,
                chromaUniformityLowerLimit, chromaUniformityUpperLimit);
        }


        private async Task TestContrastAtOneAngleAsync(string horizAngle, string vertAngle, List<KeyValuePair<string, int>> contrastRatios, CancellationToken cancellationToken)
        {
            // Ensure _ChromaMeter and _XYTable are not null
            if (_ChromaMeter == null)
            {
                throw new InvalidOperationException("_ChromaMeter is not initialized.testContras");
            }

            if (_XYTable == null)
            {
                throw new InvalidOperationException("_XYTable is not initialized. TestContrast");
            }

            LightReading whiteReading;
            LightReading blackReading;
            int contrastRatio;

            PostLineOfText($"   View center of MFD from horizontal {horizAngle} degrees, vertical {vertAngle} degrees");
            AudibleAlert();
            Popup.Show($"Set tilt table: horizontal {horizAngle} degrees, vertical {vertAngle} degrees .", PopupTitleTiltTable);
            _tiltTableAngle = TiltTableAngle.Other;
            AudibleAlert();
            if (lblUUTPartNo.Text == "MB1690A-20")
            {
                Popup.Show("Set MFD to display WHITE, in Day mode and maximum brightness (LUM = 127).", "Display White",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                        imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to display WHITE, in Day mode and maximum brightness (LUM = 127).", "Display White",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                        imagePopupTitle: "CIGALHE MFD Bezel");
            }
            _uutMediumBrightness = false;
            AudibleAlert();
            TurnOffLightAndCoverMonitor();
            whiteReading = await Task.Run(() => _ChromaMeter.TakeMeasurement(), cancellationToken);
            AudibleAlert();
            _nonNormalMaxWhiteReadings.Add(whiteReading);    // Save for use later in Section 7.4 Brightness Range - Day
            PostLineOfText($"      White test pattern, measured brightness: {whiteReading.Lv}");

            if (lblUUTPartNo.Text == "MB1690A-20")
            {
                Popup.Show("Set MFD to display BLACK, in Day mode and maximum brightness (LUM = 127).", "Display Black",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                        imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to display BLACK, in Day mode and maximum brightness (LUM = 127).", "Display Black",
                       MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                       imagePopupTitle: "CIGALHE MFD Bezel");
            }

            string alert = vertAngle == "-10" ? "NOTE: The following measurement can take up to 60 seconds." : ""; // play progress sound
            AudibleAlert();
            TurnOffLightAndCoverMonitor(alert);

            // Call the method to take the measurement
            await TakeLightReadingWithConditionalProgressSoundAsync(TestColor.Black_Day, "Black", alert != "", cancellationToken);

            // Retrieve the measurement from the dictionary
            blackReading = _measurements[TestColor.Black_Day]["Black"];

            AudibleAlert();
            PostLineOfText($"      Black test pattern, measured brightness: {blackReading.Lv}");
            contrastRatio = Convert.ToInt32(whiteReading.Lv / blackReading.Lv);
            contrastRatios.Add(new KeyValuePair<string, int>($"H:{horizAngle,3}, V:{vertAngle,3} deg.", contrastRatio));
        }




        private async Task TestColorCoordinatesAtOneSpotAsync_Day(string testPoint, CancellationToken cancellationToken)
        {
            bool bPassed;
            string pfStatus;
            string textColor;

            PostLineOfText(String.Format($"\n\nColor Coordinates DAY mode - Point {testPoint}\n"), bold: true, underline: true);

            AudibleAlert();
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to display WHITE, in Day mode and maximum brightness (LUM = 127).", "Display White",
                       MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                       imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to display WHITE, in Day mode and maximum brightness (LUM = 127).", "Display White",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                        imagePopupTitle: "CIGALHE MFD Bezel");
            }
            _uutMediumBrightness = false;
            AudibleAlert();
            TurnOffLightAndCoverMonitor();
            await TakeLightReadingAsync(TestColor.White_Day, testPoint, cancellationToken);
            AudibleAlert();

            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to display RED, in Day mode and maximum brightness (LUM = 127).", "Display Red",
                       MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                       imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to display RED, in Day mode and maximum brightness (LUM = 127).", "Display Red",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                        imagePopupTitle: "CIGALHE MFD Bezel");
            }
            _uutMediumBrightness = false;
            AudibleAlert();
            TurnOffLightAndCoverMonitor();
            await TakeLightReadingAsync(TestColor.Red_Day, testPoint, cancellationToken);
            AudibleAlert();
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to display GREEN, in Day mode and maximum brightness (LUM = 127).", "Display Green",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                        imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            { 
                Popup.Show("Set MFD to display GREEN, in Day mode and maximum brightness (LUM = 127).", "Display Green",
                       MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                       imagePopupTitle: "CIGALHE MFD Bezel");
            }
               

            _uutMediumBrightness = false;
            AudibleAlert();
            TurnOffLightAndCoverMonitor();
            await TakeLightReadingAsync(TestColor.Green_Day, testPoint, cancellationToken);
            AudibleAlert();

            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to display BLUE, in Day mode and maximum brightness (LUM = 127).", "Display Blue",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                        imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to display BLUE, in Day mode and maximum brightness (LUM = 127).", "Display Blue",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                        imagePopupTitle: "CIGALHE MFD Bezel");
            }
                
            _uutMediumBrightness = false;
            AudibleAlert();
            TurnOffLightAndCoverMonitor();
            await TakeLightReadingAsync(TestColor.Blue_Day, testPoint, cancellationToken);


            bPassed = PostChromaticityTable_Day(testPoint);
            SetPassFailStatusAndTallyPassFail(bPassed);
            pfStatus = bPassed ? "Pass" : "Fail";
            textColor = bPassed ? "Green" : "Red";
            PostBlankLine();
            PostHeader(ReceivedExpectedHeader);
            PostLineOfText(String.Format(ChromaPointStatusFormat, $"Point {testPoint}", pfStatus, "Pass", pfStatus), colorName: textColor);
        }

        private async Task TestColorCoordinatesAtOneSpotAsync_Day(string testPoint, XYPosition position, CancellationToken cancellationToken)
        {
            await MoveToPositionWithSoundAsync(position, cancellationToken);
            await TestColorCoordinatesAtOneSpotAsync_Day(testPoint, cancellationToken);
        }

        private async Task TestColorCoordinatesAtOneSpotAsync_NVG(string testPoint, CancellationToken cancellationToken)
        {//tests the chromacity of red and yellow in NVG mode
            bool bPassed;
            string pfStatus;
            string textColor;

            PostLineOfText(String.Format($"\n\nColor Coordinates NVG mode - Point {testPoint}\n"), bold: true, underline: true);

            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to display YELLOW, in NVG mode and maximum brightness (LUM = 127).", "Display Yellow",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                        imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to display YELLOW, in NVG mode and maximum brightness (LUM = 127).", "Display Yellow",
                       MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                       imagePopupTitle: "CIGALHE MFD Bezel");
            }
               
            _uutMediumBrightness = false;
            AudibleAlert();
            TurnOffLightAndCoverMonitor();
            await TakeLightReadingAsync(TestColor.Yellow_NVG, testPoint, cancellationToken);
            AudibleAlert();
            if (lblUUTPartNo.Text == "MB1690A-20" || lblUUTPartNo.Text == "MB1690A-10")
            {
                Popup.Show("Set MFD to display RED, in NVG mode and maximum brightness (LUM = 127).", "Display Red",
                       MessageBoxButtons.OK, imageFile: ImagesFolder + "ROSE Bezel Buttons - All Functions.png",
                       imagePopupTitle: "ROSE MFD Bezel");
            }
            else
            {
                Popup.Show("Set MFD to display RED, in NVG mode and maximum brightness (LUM = 127).", "Display Red",
                        MessageBoxButtons.OK, imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                        imagePopupTitle: "CIGALHE MFD Bezel");
            }
            _uutMediumBrightness = false;
            AudibleAlert();
            TurnOffLightAndCoverMonitor("NOTE: The following measurement can take up to 60 seconds."); //play progress sound
            await TakeLightReadingWithConditionalProgressSoundAsync(TestColor.Red_NVG, testPoint,true);
            AudibleAlert();

            bPassed = PostChromaticityTable_NVG(testPoint);
            SetPassFailStatusAndTallyPassFail(bPassed);
            pfStatus = bPassed ? "Pass" : "Fail";
            textColor = bPassed ? "Green" : "Red";
            PostBlankLine();
            PostHeader(ReceivedExpectedHeader);
            PostLineOfText(String.Format(ChromaPointStatusFormat, $"Point {testPoint}", pfStatus, "Pass", pfStatus), colorName: textColor);
        }

        private static void TurnOffMFDPowerSupply()
        {
            PopupWithPicture.Show("Turn OFF the MFD POWER SUPPLY rocker switch.", title: "Turn Off MFD Power",
                                   pictureFile: ImagesFolder + "MFD Power Supply -- Power OFF.png");
        }

        private static void TurnOffLightAndCoverMonitor(string alert = "")
        {
            string prompt = "Turn OFF supplemental light source.\n\n" +
                            "Cover PC monitor, then press Enter key.";

            if (alert != "")
            {
                prompt = alert + "\n\n" + prompt;
            }

            Popup.Show(prompt, title: "Dark Ambient", disableButton: true);

            _supplementalLightState = Power.OFF;
        }

        private async Task MoveToPositionWithSoundAsync(XYPosition position, CancellationToken cancellationToken)
        {
            using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var soundTask = Task.Run(() => PlaySoundLoop("Bird_in_Rain.wav", cts.Token), cts.Token);

                // Move the chromameter to the specified position
                await Task.Run(() => _XYTable.MoveToPosition(position, cts.Token), cts.Token);

                // Cancel the sound task and wait for it to acknowledge the cancellation
                cts.Cancel();

                try
                {
                    if (!soundTask.Wait(TimeSpan.FromSeconds(10)))
                    {
                        throw new OperationCanceledException("Sound task did not complete within the expected time frame.");
                    }
                }
                catch (OperationCanceledException)
                {
                    // Handle the cancellation exception if necessary
                }
            }
        }


        private async Task TakeLightReadingWithConditionalProgressSoundAsync(TestColor testColor, string point, bool playProgressSound = false, CancellationToken cancellationToken = default)
        {
            if (_ChromaMeter == null)
            {
                throw new InvalidOperationException("_ChromaMeter is not initialized.");
            }

            using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                Task soundTask = Task.CompletedTask;
                if (playProgressSound)
                {
                    soundTask = Task.Run(() => PlaySoundLoop("Bird_in_Rain.wav", cts.Token), cts.Token);
                }

                try
                {
                    Task<LightReading> measurementTask = Task.Run(() => _ChromaMeter.TakeMeasurement(), cts.Token);
                    Task timeoutTask = Task.Delay(TimeSpan.FromMinutes(2), cts.Token);

                    Task completedTask = await Task.WhenAny(measurementTask, timeoutTask);

                    if (completedTask == timeoutTask)
                    {
                        cts.Cancel();
                        throw new TimeoutException("The chromameter measurement timed out after 2 minutes.");
                    }

                    LightReading lightReading = await measurementTask;

                    if (playProgressSound)
                    {
                        _progressSoundPlayer?.Stop(); // Stop the sound immediately
                        cts.Cancel();
                        if (!soundTask.Wait(TimeSpan.FromSeconds(5)))
                        {
                            throw new OperationCanceledException("Sound task did not complete within the expected time frame.");
                        }
                    }

                    // Color correct non-white/black readings
                    if (testColor != TestColor.White_Day && testColor != TestColor.Black_Day)
                        lightReading = _ColorCorrection.AdjustColor(testColor, lightReading);

                    if (_measurements.ContainsKey(testColor))
                    {
                        _measurements[testColor].Add(point, lightReading);
                    }
                    else
                    {
                        var _pointsMeasurements = new SortedList<string, LightReading>();
                        _pointsMeasurements.Add(point, lightReading);
                        _measurements.Add(testColor, _pointsMeasurements);
                    }
                }
                catch (TimeoutException tex)
                {
                    MessageBox.Show($"A timeout occurred: {tex.Message}", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (InvalidOperationException ioex)
                {
                    MessageBox.Show($"An invalid operation occurred: {ioex.Message}", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Handle any other exceptions
                    MessageBox.Show($"An error occurred: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Ensure the sound task is cancelled and awaited even if an exception occurs
                    if (playProgressSound)
                    {
                        cts.Cancel();
                        try
                        {
                            if (!soundTask.Wait(TimeSpan.FromSeconds(10)))
                            {
                                throw new OperationCanceledException("Sound task did not complete within the expected time frame.");
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            // Handle the cancellation exception if necessary
                        }
                    }
                }
            }
        }


        private void PlaySoundLoop(string soundFile, CancellationToken token)
        {
            if (File.Exists(soundFile))
            {
                _progressSoundPlayer = new SoundPlayer(soundFile);
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        _progressSoundPlayer.PlaySync();

                        // Check for cancellation after each loop
                        if (token.IsCancellationRequested)
                        {
                            _progressSoundPlayer.Stop();
                            break;
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Handle the cancellation exception if necessary
                }
                finally
                {
                    _progressSoundPlayer.Stop(); // Ensure the sound stops if the token is canceled
                }
            }
            else
            {
                MessageBox.Show($"Sound file {soundFile} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
