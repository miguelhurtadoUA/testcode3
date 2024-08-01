using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using CS.Libraries.File.Initialization;
using CS.Libraries.Forms.Prompts;
using ChromaMeter;
using XYPositionSystem;

namespace CIGALHE.MFD.Optical
{
    public partial class MFD_Optical : Form
    {
        const string TreeViewFontName = "Microsoft Sans Serif";

        private static string ImagesFolder
        {
            get
            {
                string imagesFolderPath;

                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    imagesFolderPath = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + "\\" + IMAGES_FOLDER + "\\";
                }
                else
                {
                    imagesFolderPath = "..\\..\\" + IMAGES_FOLDER + "\\";
                }

                return imagesFolderPath;
            }
        }

        private static Version TestAppVersion
        {
            get
            {
                Version testAppVersion;

                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    // Published and deployed
                    testAppVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                }
                else
                {
                    // Debug mode
                    testAppVersion = Assembly.GetExecutingAssembly().GetName().Version;
                }

                return testAppVersion;
            }
        }

        private static string TestVersion
        {
            get
            {
                string strPatch = TestAppVersion.Build > 0 ? $".{TestAppVersion.Build}" : "";
                return $"{TestAppVersion.Major}.{TestAppVersion.Minor}" + strPatch;
            }
        }


        // Class variables
        INI_File _IniFile;
        CS200    _ChromaMeter;
        ACRO55   _XYTable;
        ColorCorrection _ColorCorrection;
        CalibrateACRO55 _CalibrationForm;
        TiltTableAngle  _tiltTableAngle;
        bool _uutMediumBrightness = false;
        bool _topwardPowerSupplyInitialized;
        Font _treeViewBoldFont = new Font(TreeViewFontName, 9F, FontStyle.Bold);
        Font _treeViewRegularFont = new Font(TreeViewFontName, 9F, FontStyle.Regular);
        Action[][] _subTests;

        public MFD_Optical()
        {
            try
            {
                _IniFile = new INI_File(INIFILE);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show($"File, '{Path.GetFileName(e.FileName)}', could not be found.\n\n" +
                    $"Expected location: {Path.GetDirectoryName(e.FileName).Replace(" ", "")}\n\n\n" +
                    "Clicking OK will close app.", caption: "File Not Found");
                Environment.Exit(0);
            }

            _ColorCorrection = new ColorCorrection(_IniFile);
            _tiltTableAngle = TiltTableAngle.Other;
            _uutMediumBrightness = false;
            _topwardPowerSupplyInitialized = false;
            _ChromaMeter = new CS200();

            InitializeComponent();

            _subTests = new Action [][]
            {
                new Action[] { new Action(Test1_PowerOnAndColorPattern) },//CHANGE RENFERNCES HERE
                new Action[] { new Action(Test2_1_AssessScratches), new Action(Test2_2_AssessBlemishes), new Action(Test2_3_AssessDefectivePixels) },
                new Action[] { new Action(Test3_TestContrast_Day), new Action(Test4_TestBrightnessRange_Day),
                               new Action(Test5_TestLuminanceHomogeneity_Day), new Action(Test6_TestColorCoordinatesAndUniformity_Day) },
                new Action[] { new Action(Test7_TestBrightnessRange_NVG), new Action(Test8_TestLuminanceHomogeneity_NVG),
                               new Action(Test9_TestColorCoordinates_NVG), new Action(Test10_TestNVGCompatibility),
                               new Action(Test11_TestBezelLighting),new Action(Test12_BezelBacklightingTest), new Action(Test13_TestPowerLED) },
                new Action[] { new Action(Test14_TestPowerOff) }
            };

            rtbTestResults.SelectionIndent = 15;
            this.KeyDown += new KeyEventHandler(MFD_Optical_KeyDown);
        }

        private async void MFD_Optical_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                await RunTests();
            }
        }

        private void MFD_OpticalForm_Load(object sender, System.EventArgs e)
        {
            _ChromaMeter.ConnectUSB();                                          // Comment out this line when no hardware is connected
            _ChromaMeter.RemoteMode(CS200.Setting.On);                          // Comment out this line when no hardware is connected
            _ChromaMeter.Backlighting(CS200.Setting.Off);                       // Comment out this line when no hardware is connected
            _ChromaMeter.SetMeasurementSpeed(CS200.MeasurementSpeed.Auto);      // Comment out this line when no hardware is connected
            _XYTable = new ACRO55(INIFILE);
            _XYTable.Show();                                                    // Comment out this line when no hardware is connected
            _XYTable.Visible = false;                                           // Comment out this line when no hardware is connected

            TreeNode root = testSelectionTree.Nodes[0];
            root.NodeFont = _treeViewBoldFont;
            root.Checked = true;
            testSelectionTree.ExpandAll();

            lblSoftwareVersion.Text = TestVersion;
        }

        private void MFD_OpticalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_resultsSaved)
                PromptUserToSaveResults();

            _ChromaMeter.RemoteMode(CS200.Setting.Off);     // Comment out this line when no hardware is connected
            _ChromaMeter.DisconnectUSB();                   // Comment out this line when no hardware is connected
            _XYTable.CloseSerialPort();                     // Comment out this line when no hardware is connected
        }

        private void MFD_OpticalForm_Shown(object sender, EventArgs e)
        {
            Popup.Show("On the chroma meter, verify that the focus adjustment ring is set to approximately 0.55 m.\n\n" +
                       "This is set by looking down through the CS-200 chroma meter at the lit display of the MFD\n" +
                       "and turning the focus adjustment ring until the LCD pixels are in focus.\n\n" +
                       "          (Click blue Help button at upper right to see picture of focus adjustment ring.)",
                        title: "Chroma Meter Focus", msgBoxButtons: MessageBoxButtons.OK,
                        imageFile: ImagesFolder + "Focus adj ring.png",
                        imagePopupTitle: "Focus Adjustment Ring");

            Popup.Show("Verify that the chroma meter VIEW ANGLE selector is set to 1\u00B0.\n\n" +
                       "          (Click blue Help button at upper right to see picture of VIEW ANGLE selector.)",
                        title: "View Angle Selector", msgBoxButtons: MessageBoxButtons.OK,
                        imageFile: ImagesFolder + "View Angle Selector.png",
                        imagePopupTitle: "VIEW ANGLE Selector");

            _task = "";
            _testSection = "";
            _testName = "";
            UpdateTestNameAndStatusFields("Ready");
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            await RunTests();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnterTestInformation()
        {
            TestInfoForm frmTestInfo = new TestInfoForm(this);
            DialogResult dialogResult = frmTestInfo.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                lblOperatorName.Text = frmTestInfo.txtUserName.Text.Trim();
                lblUUTPartNo.Text = frmTestInfo.cmboPartNo.Text;
                lblUUTSerialNo.Text = frmTestInfo.txtSerialNo.Text.Trim();
                _operatorComment = frmTestInfo.txtComments.Text.Trim();
            }
        }

        private void treeSelectedTests_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.testSelectionTree.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.treeSelectedTests_AfterCheck);

            testSelectionTree.BeginUpdate();
            SetAllChildCheckboxesTheSame(e.Node);
            UpdateParentNodesCheckboxes(e.Node);
            testSelectionTree.EndUpdate();

            if (AtLeastOneNodeChecked())
            {
                btnRun.Enabled = true;
                btnRun.Focus();
            }
            else
            {
                btnRun.Enabled = false;
                btnExit.Focus();
            }

            this.testSelectionTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeSelectedTests_AfterCheck);
        }

        private bool AtLeastOneNodeChecked()
        {
            foreach (TreeNode taskNode in testSelectionTree.Nodes[0].Nodes)
            {
                foreach (TreeNode testNode in taskNode.Nodes)
                {
                    if(testNode.Checked) return true;
                }
            }
            return false;
        }

        private int NumberOfSubTests()
        {
            int numberOfTests = 0;

            foreach (TreeNode taskNode in testSelectionTree.Nodes[0].Nodes)
            {
                foreach (TreeNode testNode in taskNode.Nodes)
                {
                    numberOfTests++;
                }
            }

            return numberOfTests;
        }

        private void SetAllChildCheckboxesTheSame(TreeNode parentNode)
        {
            parentNode.NodeFont = parentNode.Checked ? _treeViewBoldFont : _treeViewRegularFont;

            foreach (TreeNode childNode in parentNode.Nodes)
            {
                childNode.Checked = parentNode.Checked;
                SetAllChildCheckboxesTheSame(childNode);
            }
        }

        private void UpdateFailuresField(string cleared = null)
        {
            Invoke((Action)delegate ()
            {
                lblFailures.Font = new Font(DefaultFont, FontStyle.Bold);
                lblFailures.ForeColor = _pfTotals.Fails == 0 ? Color.Green : Color.Red;
                if (cleared == null)
                    lblFailures.Text = _pfTotals.Fails.ToString();
                else
                    lblFailures.Text = cleared;
            });
        }

        private void UpdateParentNodesCheckboxes(TreeNode childNode)
        {
            TreeNode parentNode = childNode.Parent;
            if (parentNode == null)
            {
                return;
            }

            if (childNode.Checked == false)
            {
                parentNode.Checked = false;
                parentNode.NodeFont = _treeViewRegularFont;
                UpdateParentNodesCheckboxes(parentNode);
            }
            else
            {
                int numCheckedNodes = 0;
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.Checked)
                    {
                        numCheckedNodes++;
                    }
                }
                if (numCheckedNodes == parentNode.Nodes.Count)
                {
                    parentNode.Checked = true;
                    parentNode.NodeFont = _treeViewBoldFont;
                    UpdateParentNodesCheckboxes(parentNode);
                }
            }
        }

        private void UpdateTestNameAndStatusFields(string status)
        {//Sets test status
            Invoke((Action)delegate ()
            {
                lblTaskName.Text = _task;
                lblTestName.Text = _testSection + " " + _testName;
                lblStatus.Text = status;
            });
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //***************************************************************
        // Menu -- File
        //***************************************************************

        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveTestResults();
        }


        //***************************************************************
        // Menu -- Tests
        //***************************************************************

        private async void mnuFullTest_Click(object sender, System.EventArgs e)
        {
            mnuFullTest.Enabled = false;
            await RunTests();
            mnuFullTest.Enabled = true;
        }

        private void mnuPowerOn_Click(object sender, System.EventArgs e)
        {
            Thread opticalTestThread = new Thread(Test1_PowerOnAndColorPattern); 
            opticalTestThread.Start();
            Thread.Sleep(500);
        }

        private void mnuEnterTestInfo_Click(object sender, EventArgs e)
        {
            EnterTestInformation();
        }


        //***************************************************************
        // Menu -- Utilities
        //***************************************************************

        private void mnuClearResults_Click(object sender, EventArgs e)
        {
            if (!_resultsSaved)
                PromptUserToSaveResults();

            ClearTestResults();

            _testSection = "";
            _testName = "";
            UpdateTestNameAndStatusFields("Ready");
            _pfTotals.Fails = 0;
            UpdateFailuresField("");

            // Set this to 'true' to prevent prompt-to-save if the app
            //    is exited before running another test
            _resultsSaved = true;
        }

        private void mnuACRO55Home_Click(object sender, EventArgs e)
        {
            ACRO55.KillAlarmLock();
            ACRO55.GoToHomePosition();
        }

        private void mnuACRO55ClearAlarm_Click(object sender, EventArgs e)
        {
            ACRO55.KillAlarmLock();
        }

        private void mnuACRO55ShowDialog_Click(object sender, EventArgs e)
        {
            _XYTable.Visible = true;
        }

        private void mnuACRO55Calibrate_Click(object sender, EventArgs e)
        {
            _CalibrationForm = new CalibrateACRO55();
            _CalibrationForm.Show();
        }

        private void mnuCS200Connect_Click(object sender, EventArgs e)
        {
            _ChromaMeter.ConnectUSB();
        }

        private void mnuCS200Disconnect_Click(object sender, EventArgs e)
        {
            _ChromaMeter.DisconnectUSB();
        }

        private void enableRemoteModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChromaMeter.RemoteMode(CS200.Setting.On);
        }

        private void disableRemoteModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChromaMeter.RemoteMode(CS200.Setting.Off);
        }

        private void setMediumBrightnessDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdjustUUTBrightnessAndPostValue("White", Mode.Day);
        }

        private void setMediumBrightnessNVGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdjustUUTBrightnessAndPostValue("White", Mode.NVG);
        }


        //***************************************************************
        // Menu -- Test Development  (menu normally hidden:
        //                            Enabled = false,  Visible = false)
        //***************************************************************

        private void mnuHeadersAndData_Click(object sender, EventArgs e)
        {
            _pfTallies = new System.Collections.Generic.SortedList<string, TestPassFail>();
            _passFailStatus = "Pass";

            _testSection = "3.1";
            _testName = "Contrast - Day";
            PostSectionHeading("Section " + _testSection + "    " + _testName);
            PostDateAndTime();
            PostBlankLine();
            _unitsOfMeasure = "---";
            PostCalculatedResultHeader("Contrast");
            PostMeasurement(MeasurementFormatInt, "H: 45, V: 30 deg.",  50, ContrastRatioLowerLimit, ContrastRatioUpperLimit);
            PostMeasurement(MeasurementFormatInt, "H: 45, V:-10 deg.", 214, ContrastRatioLowerLimit, ContrastRatioUpperLimit);

            _testSection = "3.2";
            _testName = "Brightness Range - Day";
            PostSectionHeading("Section " + _testSection + "    " + _testName);
            PostDateAndTime();
            PostBlankLine();
            _unitsOfMeasure = "fL";
            PostLineOfText($"   Maximum - Center-of-Display, Normal Incidence:\n", bold: true);
            PostHeader(LowerLimitOnlyHeader);
            PostMeasurement(MeasurementLowerLimitDbl1Int, " ", 348.2, BrightnessDayNormalMaxLowerLimit, null);
            PostBlankLines(numLines: 2);
            PostLineOfText($"   Minimum - Center-of-Display, Normal Incidence:\n", bold: true);
            PostHeader(MeasurementHeader);
            PostMeasurement(MeasurementFormatDbl3, " ", 0.03, BrightnessDayNormalMinLowerLimit, BrightnessDayNormalMinUpperLimit);
            PostBlankLines(numLines: 2);
            PostLineOfText("   Maximum - Corners of Viewing Envelope:\n", bold: true);
            PostHeader(LowerLimitOnlyHeader);
            PostMeasurement(MeasurementLowerLimitDbl1Int, "H: 45, V: 30 deg.", 179.1, BrightnessDayNonNormalMaxLowerLimit, null);
            PostMeasurement(MeasurementLowerLimitDbl1Int, "H: 45, V:-10 deg.", 204.1, BrightnessDayNonNormalMaxLowerLimit, null);

            _testSection = "3.3";
            _testName = "Luminance Homogeneity - Day";
            PostSectionHeading("Section " + _testSection + "    " + _testName);
            PostDateAndTime();
            PostBlankLine();
            _unitsOfMeasure = "fL";
            PostHeader(MeasurementHeader);
            PostMeasurement(MeasurementFormatDbl1Int, "White Test Pattern", 100.7, BrightnessDayNormalMedLowerLimit, BrightnessDayNormalMedUpperLimit);
            double luminanceMin = 86.9, luminanceMax = 100.7;
            string minPoint = "#8", maxPoint = "#5";
            double luminanceAverage = 92.2;
            PostBlankLines(numLines: 2);
            PostLineOfText(ReadingsTableIndent + $"Average Brightness : {luminanceAverage:f1} fL");
            PostLineOfText(ReadingsTableIndent + $"Minimum Brightness, found at point {minPoint} : {luminanceMin:f1} fL");
            PostLineOfText(ReadingsTableIndent + $"Maximum Brightness, found at point {maxPoint} : {luminanceMax:f1} fL");
            PostBlankLines(numLines: 2);
            PostHeader(MeasurementHeader);
            double Hf = luminanceMin / luminanceMax;        // calculate luminance homogeneity
            GradeResultAndTallyPassFail(Hf, LuminanceHomogeneityLowerLimit, LuminanceHomogeneityUpperLimit, includeLimits: "[)");
            _unitsOfMeasure = "---";
            PostMeasurement(MeasurementFormatDbl2, "Homogeneity", Hf, LuminanceHomogeneityLowerLimit, LuminanceHomogeneityUpperLimit);

            _testSection = "3.4";
            _testName = "Color Coordinates & Uniformity - Day";
            PostSectionHeading("Section " + _testSection + "    " + _testName);
            PostDateAndTime();
            PostBlankLine();
            _unitsOfMeasure = "---";
            string testPoint = "#5";
            bool bPassed = true;
            SetPassFailStatusAndTallyPassFail(bPassed);
            string pfStatus = bPassed ? "Pass" : "Fail";
            string textColor = bPassed ? "Green" : "Red";
            PostBlankLine();
            PostHeader(ReceivedExpectedHeader);
            PostLineOfText(String.Format(ChromaPointStatusFormat, $"Point {testPoint}", pfStatus, "Pass", pfStatus), colorName: textColor);

            _testSection = "4.1";
            _testName = "Brightness Range - NVG";
            PostSectionHeading("Section " + _testSection + "    " + _testName);
            PostDateAndTime();
            PostBlankLine();
            _unitsOfMeasure = "fL";
            PostLineOfText($"   Maximum - Center-of-Display, Normal Incidence:\n", bold: true);
            PostHeader(MeasurementHeader);
            GradeResultAndTallyPassFail(5.61, BrightnessNVGMaxLowerLimit, BrightnessNVGMaxUpperLimit);
            PostMeasurement(MeasurementFormatDbl2Int, " ", 5.61, BrightnessNVGMaxLowerLimit, BrightnessNVGMaxUpperLimit);
            PostBlankLines(numLines: 2);
            PostLineOfText($"   Minimum - Center-of-Display, Normal Incidence:\n", bold: true);
            PostHeader(MeasurementHeader);
            GradeResultAndTallyPassFail(0.003, BrightnessNVGMinLowerLimit, BrightnessNVGMinUpperLimit, includeLimits: "[)");
            PostMeasurement(MeasurementFormatDbl3, " ", 0.003, BrightnessNVGMinLowerLimit, BrightnessNVGMinUpperLimit);
        }

        private void mnuPrompts_Click(object sender, EventArgs e)
        {
            string prompt1, prompt2;

            Popup.Show("Set MFD to display WHITE, in Day mode and maximum brightness (BRT = 127).",
                        title: "Display White", MessageBoxButtons.OK,
                        imageFile: ImagesFolder + "MFD Bezel Buttons - All Functions.png",
                        imagePopupTitle: "CIGALHE MFD Bezel");

            prompt1 = "1. Click the Help icon to the right, above, to display a picture of the MFD bezel.\n" +
                             "2. On the UUT, press the Mode button, S19, repeatedly to toggle through Day, Night and NVG modes.\n";
            prompt2 = "Did the Power LED change in brightness each time S19 was pressed?";
            Popup.Show(prompt1 + "\n" + prompt2, title: "Power LED", MessageBoxButtons.YesNo,
                       imageFile: ImagesFolder + "MFD Bezel Buttons - Change Mode.png",
                       imagePopupTitle: "CIGALHE MFD Bezel");

            prompt1 = "Click the Help icon to display a picture of the MFD bezel.\n";
            prompt2 = "Are all bezel legends illuminated uniformly?";
            Popup.Show(prompt1 + "\n" + prompt2, title: "Bezel Legends", MessageBoxButtons.YesNo,
                       imageFile: ImagesFolder + "MFD Bezel Buttons - Legends.png",
                       imagePopupTitle: "CIGALHE MFD Bezel");
        }

        private void mnuAdjBrightnessPopup_Click(object sender, EventArgs e)
        {
            AdjustUUTBrightnessAndPostValue("White", Mode.Day);
        }


        //****************************************************************

        private void PromptUserToSaveResults()
        {
            DialogResult dialogResult = Popup.Show("Do you want to save the test results?", "Unsaved Test Results",
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SaveTestResults();
            }
        }
    }
}
