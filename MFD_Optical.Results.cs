using Microsoft.Win32;
using ChromaMeter;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CIGALHE.MFD.Optical
{
    public partial class MFD_Optical
    {
        private void ClearTestResults()
        {
            Invoke((Action)delegate ()
            {
                rtbTestResults.Clear();
            });
        }

        private void PostSectionHeading(string sectionHeading)
        {//Sets test heading
            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectedText = "\n\n\n\n";
                rtbTestResults.Focus();                                 //makes rtb scroll up to show the most recently added line
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = sectionHeading + "\n\n";
            });
        }

        private void PostUserPromptToTestResults(string prompt, bool doubleSpaced = false)
        {//Prints prompt 
            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = prompt + "\n" + (doubleSpaced ? "\n" : "");
            });
        }

        private void PostHeader(string header)
        {//Prints header
            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = ResultsHeaderIndent;
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Italic | FontStyle.Underline);
                rtbTestResults.SelectedText = header + "\n";
            });
        }

        private void PostCalculatedResultHeader(string description)
        {
            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = ResultsHeaderIndent;
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Italic | FontStyle.Underline);
                rtbTestResults.SelectedText = string.Format(CalculatedResultHeader, description) + "\n";
            });
        }

        private void PostOperatorResponse(DialogResult operatorResponse, DialogResult expectedResponse)
        {
            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = _passFailStatus == "Pass" ? Color.Green : Color.Red;
                rtbTestResults.SelectedText = string.Format(OperatorResponseFormat,
                    operatorResponse, expectedResponse, _unitsOfMeasure, _passFailStatus) + "\n";
            });
        }

        //private void PostMeasurement(string measurementFormat,
        //    string description, int testValue, int lowerLimit, int upperLimit)
        //{
        //    string results = string.Format(measurementFormat,
        //        description, testValue, lowerLimit, upperLimit, _unitsOfMeasure, _passFailStatus);
        //    PostMeasurement(results);
        //}

        private void PostMeasurement(string measurementFormat,
            string description, int testValue, int? lowerLimit, int? upperLimit)
        {//formats results and post them 
            string results;

            if (lowerLimit.HasValue)
            {
                if (upperLimit.HasValue)
                {
                    results =string.Format(measurementFormat,
                        description, testValue, lowerLimit, upperLimit, _unitsOfMeasure, _passFailStatus);
                }
                else
                {
                    results = string.Format(measurementFormat,
                        description, testValue, lowerLimit, _unitsOfMeasure, _passFailStatus);
                }
            }
            else
            {
                results = string.Format(measurementFormat,
                    description, testValue, upperLimit, _unitsOfMeasure, _passFailStatus);
            }

            PostMeasurement(results);
        }

        private void PostMeasurement(string measurementFormat,
            string description, double testValue, int? lowerLimit, int? upperLimit)
        {//formats results and post them 
            string results;

            if (lowerLimit.HasValue)
            {
                if (upperLimit.HasValue)
                {
                    results = string.Format(measurementFormat,
                        description, testValue, lowerLimit, upperLimit, _unitsOfMeasure, _passFailStatus);
                }
                else
                {
                    results = string.Format(measurementFormat,
                        description, testValue, lowerLimit, _unitsOfMeasure, _passFailStatus);
                }
            }
            else // no lower limit was supplied
            {
                if (upperLimit.HasValue)
                {
                    results = string.Format(measurementFormat,
                        description, testValue, upperLimit, _unitsOfMeasure, _passFailStatus);
                }
                else
                {
                    results = "ERROR: No lower or upper limit.";
                }
            }

            PostMeasurement(results);
        }

        private void PostMeasurement(string measurementFormat,
            string description, double testValue, double? lowerLimit, double? upperLimit)
        {//formats results and post them 
            string results;

            if (lowerLimit.HasValue)
            {
                if (upperLimit.HasValue)
                {
                    results = string.Format(measurementFormat,
                        description, testValue, lowerLimit, upperLimit, _unitsOfMeasure, _passFailStatus);
                }
                else
                {
                    results = string.Format(measurementFormat,
                        description, testValue, lowerLimit, _unitsOfMeasure, _passFailStatus);
                }
            }
            else // no lower limit was supplied
            {
                if (upperLimit.HasValue)
                {
                    results = string.Format(measurementFormat,
                        description, testValue, upperLimit, _unitsOfMeasure, _passFailStatus);
                }
                else
                {
                    results = "ERROR: No lower or upper limit.";
                }
            }

            PostMeasurement(results);
        }

        private void PostMeasurement(string resultsString)
        {//formats results and post them 
            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = _passFailStatus == "Pass" ? Color.Green : Color.Red;
                rtbTestResults.SelectedText = resultsString + "\n";
            });
        }

        private void PostSubTestPassFailFooter()
        {//Sets pass/fail based on tallies, and prints result
            string subTestStatus;

            if (_pfTallies[_testSection].Fails == 0)
            {
                subTestStatus = "PASS";
            }
            else
            {
                subTestStatus = "FAIL";
            }

            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectedText = "\n\n";
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                rtbTestResults.SelectionColor = subTestStatus == "PASS" ? Color.Green : Color.Red;
                rtbTestResults.SelectedText = "                                               TEST " + subTestStatus + "\n";
            });
        }

        private void PostBlankLine()
        {//Prints blank line
            PostBlankLines(numLines: 1);
        }

        private void PostBlankLines(int numLines)
        {//prints newlines specified
            Invoke((Action)delegate ()
            {
                for (int i = 0; i < numLines; i++)
                {
                    rtbTestResults.SelectedText = "\n";
                }
            });
        }

        private void PostLineOfText(string text, string colorName = "Blue", bool bold = false, bool underline = false)
        {//posts line of text 
            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10,
                    (bold ? FontStyle.Bold : FontStyle.Regular) | (underline ? FontStyle.Underline : FontStyle.Regular));
                rtbTestResults.SelectionColor = (Color)(new ColorConverter()).ConvertFromString(colorName);
                rtbTestResults.SelectedText = text + "\n";
            });
        }

        private void PostDateAndTime(DateTime? dateTime = null)
        {//Sets date and time of the test
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }
            PostLineOfText(string.Format("{0:yyyy-MM-dd} {0:HH:mm:ss}", dateTime), "Gray");
        }

        private void PostATRFooterPartialATPLine()
        {//formats and posts ATP footer 
            Color backgroundColor = Color.Red;

            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = "|";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                rtbTestResults.SelectionColor = Color.White;
                rtbTestResults.SelectionBackColor = backgroundColor;
                rtbTestResults.SelectedText = FooterPartialATPLine;

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectionBackColor = Color.White;
                rtbTestResults.SelectedText = "|\n";
            });
        }

        private void PostATRFooterTestStatusLine()
        {//formats and posts ATP status line
            string portionOfTestRun;
            if (_pfTallies.Count < NumberOfSubTests())
            {
                portionOfTestRun = "Selected Tests";
            }
            else
            {
                portionOfTestRun = "ATP";
            }

            string leftString = string.Format(FooterLeftHandFormat, portionOfTestRun + " Status");
            string rightString = string.Format(FooterRightHandFormat, _pfTotals.Fails == 0 ? "*** P A S S ***" : "*** F A I L ***");

            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = leftString;

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                rtbTestResults.SelectionColor = _pfTotals.Fails == 0 ? Color.Green : Color.Red;
                rtbTestResults.SelectedText = rightString;

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = "|\n";
            });
        }

        private void PostPassFailTally(string testSection, string testName, int numberOfFailures)
        {//formats and posts fail tally
            string pfStatus = numberOfFailures == 0 ? "Pass" : "Fail";

            string formattedString1 = string.Format(PassFailTallyFormat1, testSection, testName);
            string formattedString2 = string.Format(PassFailTallyFormat2, pfStatus);
            string formattedString3 = string.Format(PassFailTallyFormat3, numberOfFailures == 0 ? "" : numberOfFailures.ToString());

            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = formattedString1;

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = pfStatus == "Pass" ? Color.Green : Color.Red;
                rtbTestResults.SelectedText = formattedString2;

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = "|";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = pfStatus == "Pass" ? Color.Green : Color.Red;
                rtbTestResults.SelectedText = formattedString3;

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = "|\n";
            });
        }

        private void PostTaskDescription(string taskDescription)
        {//formats and posts task description
            Color shadedBackground = Color.LightGray;

            string formattedString = string.Format(TaskDescriptionFormat, taskDescription);

            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = "|";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectionBackColor = shadedBackground;
                rtbTestResults.SelectedText = formattedString;

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectionBackColor = Color.Transparent;
                rtbTestResults.SelectedText = "|";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectionBackColor = shadedBackground;
                rtbTestResults.SelectedText = "              ";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectionBackColor = Color.Transparent;
                rtbTestResults.SelectedText = "|";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectionBackColor = shadedBackground;
                rtbTestResults.SelectedText = "              ";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectionBackColor = Color.Transparent;
                rtbTestResults.SelectedText = "|\n";
            });
        }

        private void PostTaskToATRSummary(string task)
        {//prints ATR summary
            PostTaskDescription(task);
            PostLineOfText(ATPSummaryHorizBorder);
        }

        private int ExtractTaskNumber(string testNum)
        {// gets the task number 
            string[] tokens = testNum.Split('.');
            string taskNo = tokens[0];

            return Convert.ToInt32(taskNo);
        }

        private void PostHeaderFooterLineItem(string description, string info)
        {//formats and posts footer line item 
            string headerTableLine = string.Format(HeaderFooterLineItemFormat, description, info);

            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = headerTableLine;
            });
        }

        private void PostNineReadingsTable(TestColor testColor)
        {// formats and posts nine table readings
            string rowCellLabels;
            string rowReadings;

            PostBlankLine();
            PostLineOfText(ReadingsTableIndent + ReadingsTableHorizBorder);
            rowCellLabels = String.Format(ReadingsTableCellLabelsFormat, "P#1", "P#2", "P#3");
            PostLineOfText(ReadingsTableIndent + rowCellLabels);
            rowReadings = String.Format(ReadingsTableThreeReadingsFormat,
                _measurements[testColor]["#1"].Lv, _measurements[testColor]["#2"].Lv, _measurements[testColor]["#3"].Lv);
            PostLineOfText(ReadingsTableIndent + rowReadings);
            PostLineOfText(ReadingsTableIndent + ReadingsTableEmptyRow);
            PostLineOfText(ReadingsTableIndent + ReadingsTableHorizBorder);
            rowCellLabels = String.Format(ReadingsTableCellLabelsFormat, "P#4", "P#5", "P#6");
            PostLineOfText(ReadingsTableIndent + rowCellLabels);
            rowReadings = String.Format(ReadingsTableThreeReadingsFormat,
                _measurements[testColor]["#4"].Lv, _measurements[testColor]["#5"].Lv, _measurements[testColor]["#6"].Lv);
            PostLineOfText(ReadingsTableIndent + rowReadings);
            PostLineOfText(ReadingsTableIndent + ReadingsTableEmptyRow);
            PostLineOfText(ReadingsTableIndent + ReadingsTableHorizBorder);
            rowCellLabels = String.Format(ReadingsTableCellLabelsFormat, "P#7", "P#8", "P#9");
            PostLineOfText(ReadingsTableIndent + rowCellLabels);
            rowReadings = String.Format(ReadingsTableThreeReadingsFormat,
                _measurements[testColor]["#7"].Lv, _measurements[testColor]["#8"].Lv, _measurements[testColor]["#9"].Lv);
            PostLineOfText(ReadingsTableIndent + rowReadings);
            PostLineOfText(ReadingsTableIndent + ReadingsTableEmptyRow);
            PostLineOfText(ReadingsTableIndent + ReadingsTableHorizBorder);
        }

        private bool PostChromaticityTable_Day(string point)
        {// formats and posts chromaticity table readings (day)
            double colorRadius;
            bool colorPassed;
            bool pointPassed = true;

            PostLineOfText(ChromaTableIndent + ChromaTableHorizBorder);
            PostLineOfText(ChromaTableIndent + ChromaTableTitle);
            PostLineOfText(ChromaTableIndent + ChromaTableHorizBorder);
            PostLineOfText(ChromaTableIndent + ChromaTableHeadings1st);
            PostLineOfText(ChromaTableIndent + ChromaTableHeadings2nd);
            PostLineOfText(ChromaTableIndent + ChromaTableHorizBorder);

            // White, Day
            PostLineOfText(ChromaTableIndent + String.Format(ChromaTableWhiteFormat, "White",
                _measurements[TestColor.White_Day][point].UPrime, _measurements[TestColor.White_Day][point].VPrime));

            // Red, Day
            colorRadius = CalculateColorRadius(_measurements[TestColor.Red_Day][point], DayRedUPrime, DayRedVPrime);
            if ((colorPassed = RadiusPassed(colorRadius, ColorRadiusDayRedUpperLimit)) == false)
                pointPassed = false;
            PostLineOfText(ChromaTableIndent + String.Format(ChromaTableColorFormat, "Red", DayRedUPrime, DayRedVPrime, ColorRadiusDayRedUpperLimit,
                _measurements[TestColor.Red_Day][point].UPrime, _measurements[TestColor.Red_Day][point].VPrime, colorRadius, colorPassed ? "Pass" : "Fail"));

            // Green, Day
            colorRadius = CalculateColorRadius(_measurements[TestColor.Green_Day][point], DayGreenUPrime, DayGreenVPrime);
            if ((colorPassed = RadiusPassed(colorRadius, ColorRadiusDayGreenUpperLimit)) == false)
                pointPassed = false;
            PostLineOfText(ChromaTableIndent + String.Format(ChromaTableColorFormat, "Green", DayGreenUPrime, DayGreenVPrime, ColorRadiusDayGreenUpperLimit,
                _measurements[TestColor.Green_Day][point].UPrime, _measurements[TestColor.Green_Day][point].VPrime, colorRadius, colorPassed ? "Pass" : "Fail"));

            // Blue, Day
            colorRadius = CalculateColorRadius(_measurements[TestColor.Blue_Day][point], DayBlueUPrime, DayBlueVPrime);
            if ((colorPassed = RadiusPassed(colorRadius, ColorRadiusDayBlueUpperLimit)) == false)
                pointPassed = false;
            PostLineOfText(ChromaTableIndent + String.Format(ChromaTableColorFormat, "Blue", DayBlueUPrime, DayBlueVPrime, ColorRadiusDayBlueUpperLimit,
                _measurements[TestColor.Blue_Day][point].UPrime, _measurements[TestColor.Blue_Day][point].VPrime, colorRadius, colorPassed ? "Pass" : "Fail"));

            PostLineOfText(ChromaTableIndent + ChromaTableHorizBorder);

            return pointPassed;
        }

        private bool PostChromaticityTable_NVG(string point)
        {// formats and posts chromaticity table readings (NVG)
            double colorRadius;
            bool colorPassed;
            bool pointPassed = true;

            PostLineOfText(ChromaTableIndent + ChromaTableHorizBorder);
            PostLineOfText(ChromaTableIndent + ChromaTableTitle);
            PostLineOfText(ChromaTableIndent + ChromaTableHorizBorder);
            PostLineOfText(ChromaTableIndent + ChromaTableHeadings1st);
            PostLineOfText(ChromaTableIndent + ChromaTableHeadings2nd);
            PostLineOfText(ChromaTableIndent + ChromaTableHorizBorder);

            // Yellow, NVG
            colorRadius = CalculateColorRadius(_measurements[TestColor.Yellow_NVG][point], NVGYellowUPrime, NVGYellowVPrime);
            if ((colorPassed = RadiusPassed(colorRadius, ColorRadiusNVGYellowUpperLimit)) == false)
                pointPassed = false;
            PostLineOfText(ChromaTableIndent + String.Format(ChromaTableColorFormat, "Yellow", NVGYellowUPrime, NVGYellowVPrime, ColorRadiusNVGYellowUpperLimit,
                _measurements[TestColor.Yellow_NVG][point].UPrime, _measurements[TestColor.Yellow_NVG][point].VPrime, colorRadius, colorPassed ? "Pass" : "Fail"));

            // Red, NVG
            colorRadius = CalculateColorRadius(_measurements[TestColor.Red_NVG][point], NVGRedUPrime, NVGRedVPrime);
            if ((colorPassed = RadiusPassed(colorRadius, ColorRadiusNVGRedUpperLimit)) == false)
                pointPassed = false;
            PostLineOfText(ChromaTableIndent + String.Format(ChromaTableColorFormat, "Red", NVGRedUPrime, NVGRedVPrime, ColorRadiusNVGRedUpperLimit,
                _measurements[TestColor.Red_NVG][point].UPrime, _measurements[TestColor.Red_NVG][point].VPrime, colorRadius, colorPassed ? "Pass" : "Fail"));

            PostLineOfText(ChromaTableIndent + ChromaTableHorizBorder);

            return pointPassed;
        }

        private void PostCornerOfEnvelopeBrightness(LightReading whiteReading, string angleDescription)
        {//evaluates brightness and prints it 
            GradeResultToLowerLimitAndTallyPassFail(whiteReading.Lv, BrightnessDayNonNormalMaxLowerLimit);
            PostMeasurement(MeasurementLowerLimitDbl1Int, angleDescription, whiteReading.Lv,
                BrightnessDayNonNormalMaxLowerLimit, null);
        }

        private void PostATRFooter()
        {//posts all ATR footers
            PostATRHeaderFooterTitle();

            PostHeaderFooterOpticalTesterName();

            PostHeaderFooterTestProgram();

            PostHeaderFooterTestVersion();

            PostHeaderFooterUUTName();

            PostHeaderFooterUUTPartNumber();

            PostHeaderFooterUUTSerialNumber();

            PostHeaderFooterStartTime();

            PostHeaderFooterEndTime();

            PostHeaderFooterOperatorComment();

            PostATRFooterTestStatusLine();
            PostHeaderFooterHorizBorder();

            if (_pfTallies.Count < NumberOfSubTests())
            {
                PostATRFooterPartialATPLine();
                PostHeaderFooterHorizBorder();
            }

            PostHeaderFooterLineItem("Failed Tests", _pfTotals.Fails.ToString());
            PostHeaderFooterHorizBorder();

            PostHeaderFooterOperatorName();
        }

        private void PostATRHeader()
        {//posts all ATR headers
            PostBlankLine();
            PostATRHeaderFooterTitle();

            PostHeaderFooterOpticalTesterName();

            PostHeaderFooterLineItem("Tester PC", Environment.MachineName.ToString());
            PostHeaderFooterHorizBorder();

            string operatingSystem = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                "ProductName", null).ToString();
            string version = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                "ReleaseID", null).ToString();
            PostHeaderFooterLineItem("Operating System", operatingSystem + ", ver. " + version);
            PostHeaderFooterHorizBorder();

            PostHeaderFooterTestProgram();

            PostHeaderFooterTestVersion();

            PostHeaderFooterUUTName();

            PostHeaderFooterUUTPartNumber();

            PostHeaderFooterUUTSerialNumber();

            PostHeaderFooterOperatorName();

            PostHeaderFooterStartTime();

            PostHeaderFooterLineItem("Internal Software Components", "kmsecs200.dll");
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterOpticalTesterName()
        {// Posts optical testers name
            PostHeaderFooterLineItem("Tester Name", "CIGALHE MFD Optic UA, No. 1");
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterTestProgram()
        {// Posts test program
            string cmdLine = Environment.CommandLine.ToString().Trim('"', ' ');
            string[] cmdLineTokens = cmdLine.Split('\\');
            string testApp = cmdLineTokens[cmdLineTokens.Length - 1];
            PostHeaderFooterLineItem("Test Program", testApp);
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterTestVersion()
        {//post test version
            PostHeaderFooterLineItem("Test Version", TestVersion);
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterUUTName()
        {// post UUT name 
            PostHeaderFooterLineItem("UUT Name", "MFD");
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterUUTPartNumber()
        {// post part number
            PostHeaderFooterLineItem("UUT P/N", lblUUTPartNo.Text);
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterUUTSerialNumber()
        {//post serial number
            PostHeaderFooterLineItem("UUT S/N", lblUUTSerialNo.Text);
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterOperatorName()
        {//post operator name
            PostHeaderFooterLineItem("Operator Name", lblOperatorName.Text);
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterStartTime()
        {//post start time
            PostHeaderFooterLineItem("Start Time", string.Format("{0:yyyy-MM-dd} {0:HH:mm:ss}", _beginDateTime));
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterEndTime()
        {//post end time
            PostHeaderFooterLineItem("End Time", string.Format("{0:yyyy-MM-dd} {0:HH:mm:ss}", _endDateTime));
            PostHeaderFooterHorizBorder();
        }

        private void PostHeaderFooterOperatorComment()
        {//post operators comment(s)
            PostHeaderFooterLineItem("Operator Comment", _operatorComment);
            PostHeaderFooterHorizBorder();
        }

        private void PostATRHeaderFooterTitle()
        {//post footer title
            Color backgroundColor = Color.Blue;

            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                rtbTestResults.SelectionColor = Color.White;
                rtbTestResults.SelectionBackColor = backgroundColor;
                rtbTestResults.SelectedText = HeaderFooterTitle + "\n";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = HeaderFooterTitleSeparator + "\n";
            });
        }

        private void PostATRSummary()
        {//formats and post ATR summary
            PostATRSummaryColumnHeadings();

            int numTasks = testSelectionTree.Nodes[0].Nodes.Count;
            string[] tasks = new string[numTasks];
            int idx = 0;
            foreach (TreeNode node in testSelectionTree.Nodes[0].Nodes)
            {
                tasks[idx++] = node.Text;
            }

            // Post tallies for tests that were run
            int taskNum = 0;
            foreach (var testTally in _pfTallies)
            {
                int subtestTaskNum = ExtractTaskNumber(testTally.Key);

                // Post task heading, if not already posted
                if (taskNum != subtestTaskNum)
                {
                    taskNum = subtestTaskNum;
                    PostTaskToATRSummary(tasks[taskNum - 1]);
                }

                // Post subtest summary
                PostPassFailTally(testTally.Key, testTally.Value.Name, testTally.Value.Fails);
                PostLineOfText(ATPSummaryHorizBorder);
            }
        }

        private void PostATRSummaryColumnHeadings()
        {//posts ATR column headers
            Color backgroundColor = Color.Blue;

            Invoke((Action)delegate ()
            {
                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline);
                rtbTestResults.SelectionColor = Color.White;
                rtbTestResults.SelectionBackColor = backgroundColor;
                rtbTestResults.SelectedText = ATPSummaryTitle + "\n";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.White;
                rtbTestResults.SelectionBackColor = backgroundColor;
                rtbTestResults.SelectedText = ATPSummaryColumnHeadings + "\n";

                rtbTestResults.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                rtbTestResults.SelectionColor = Color.Blue;
                rtbTestResults.SelectedText = ATPSummaryHorizSeparator + "\n";
            });
        }

        private void PostHeaderFooterHorizBorder() => PostLineOfText(HeaderFooterHorizBorder);
        //postHeaderFooter calls PostLineOfText w/ HeaderFooter, encapsulating it (bsically a nested call)

        private string SaveTestResults()
        {//saves tets results to the directiry specified
            bool fullTest = (_numTestsRun == CountSubtestsInFullTest());

            // If no test info was entered, define default PN and SN for naming test results
            string uutPartNumber = lblUUTPartNo.Text == "" ? "UnknownPN" : lblUUTPartNo.Text;
            string uutSerialNumber = lblUUTSerialNo.Text == "" ? "----" : lblUUTSerialNo.Text;

            string testLogsDir = @"C:\CIGALHE\MFD\Logs";
            string testLogsPartNoDir = testLogsDir + $@"\{uutPartNumber}";
            string testLogsPlainTextDir = testLogsPartNoDir + @"\Plain Text";

            if (!Directory.Exists(testLogsPlainTextDir))
            {
                Directory.CreateDirectory(testLogsPlainTextDir);
            }

            DateTime dateTime = DateTime.Now;
            string dateString = string.Format("{0:yyyy-MM-dd}", dateTime);
            string timeString = string.Format("{0:HHmmss}", dateTime);

            string fileName = $"{uutPartNumber}_{uutSerialNumber}_" + dateString + "_" + timeString + (fullTest == true ? "" : "_partial");
            string rtfFullPathName = testLogsPartNoDir + "\\" + fileName + ".rtf";
            string txtFullPathName = testLogsPlainTextDir + "\\" + fileName + ".txt";

            Invoke((Action)delegate ()
            {
                // Save as RTF file
                rtbTestResults.SaveFile(rtfFullPathName);

                // Save as plain text file
                rtbTestResults.SaveFile(txtFullPathName, RichTextBoxStreamType.PlainText);
            });

            _resultsSaved = true;

            return rtfFullPathName;
        }
    }
}
