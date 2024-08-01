using System.Windows.Forms;

namespace CIGALHE.MFD.Optical
{
    partial class MFD_Optical
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.1. Power On");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("1. Power On", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("2.1. Scratches");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("2.2. Blemishes");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("2.3. Defective Pixels");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("2. Display Defects", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("3.1. Contrast - Day");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("3.2. Brightness Range - Day");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("3.3. Luminance Homogeneity - Day");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("3.4. Color Coordinates & Uniformity - Day");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("3. Day Mode", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("4.1. Brightness Range - NVG");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("4.2. Luminance Homogeneity - NVG");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("4.3. Color Coordinates - NVG");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("4.4. NVG Compatibility");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("4.5. Bezel Lighting");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("4.6. Bezel Backlighting");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("4.7. Power LED");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("4. NVG Mode", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("5.1. Power Off");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("5. Power Off", new System.Windows.Forms.TreeNode[] {
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("MFD_Optical Tests", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode6,
            treeNode11,
            treeNode19,
            treeNode21});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRunTests = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFullTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSubTests = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPowerOn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.scratchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blemishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defectivePixelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessRangeDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luminanceHomogeneityDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorCoordinatesUniformityDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nVGModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessRangeNVGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luminanceHomogeneityNVGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorCoordinatesNVGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nVGCompatibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bezelLightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bezelBacklightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerLEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEnterTestInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.umnuUtilities = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearResults = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuACRO55 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuACRO55Home = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuACRO55ClearAlarm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuACRO55ShowDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuACRO55Calibrate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCS200 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCS200Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCS200Disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.enableRemoteModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableRemoteModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.setMediumBrightnessDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMediumBrightnessNVGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testDevelopmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHeadersAndData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrompts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdjBrightnessPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbTestResults = new System.Windows.Forms.RichTextBox();
            this.hdgUUT = new System.Windows.Forms.Label();
            this.lblSWVer = new System.Windows.Forms.Label();
            this.panel010 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnUUTPower = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblF1 = new System.Windows.Forms.Label();
            this.lblF3 = new System.Windows.Forms.Label();
            this.lblF8 = new System.Windows.Forms.Label();
            this.lblF9 = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.hdgStatus = new System.Windows.Forms.Label();
            this.hdgFailures = new System.Windows.Forms.Label();
            this.hdgTaskName = new System.Windows.Forms.Label();
            this.hdgTestName = new System.Windows.Forms.Label();
            this.hdgLoops = new System.Windows.Forms.Label();
            this.hdgEstTime = new System.Windows.Forms.Label();
            this.lblEstimatedTime = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel031 = new System.Windows.Forms.Panel();
            this.lblReady = new System.Windows.Forms.Label();
            this.panel032 = new System.Windows.Forms.Panel();
            this.btnAbort = new System.Windows.Forms.Button();
            this.panel030 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.lblTestName = new System.Windows.Forms.Label();
            this.panel020 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.testSelectionTree = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUUTPartNo = new System.Windows.Forms.Label();
            this.lblSoftwareVersion = new System.Windows.Forms.Label();
            this.hdgOperator = new System.Windows.Forms.Label();
            this.hdgSN = new System.Windows.Forms.Label();
            this.lblUUTSerialNo = new System.Windows.Forms.Label();
            this.lblOperatorName = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblFailures = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel010.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel031.SuspendLayout();
            this.panel032.SuspendLayout();
            this.panel030.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel020.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Beige;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuRunTests,
            this.umnuUtilities,
            this.testDevelopmentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1059, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSave});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(98, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuRunTests
            // 
            this.mnuRunTests.BackColor = System.Drawing.Color.Beige;
            this.mnuRunTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFullTest,
            this.toolStripSeparator1,
            this.mnuSubTests,
            this.toolStripMenuItem1,
            this.mnuEnterTestInfo});
            this.mnuRunTests.Name = "mnuRunTests";
            this.mnuRunTests.Size = new System.Drawing.Size(44, 20);
            this.mnuRunTests.Text = "Tests";
            // 
            // mnuFullTest
            // 
            this.mnuFullTest.Name = "mnuFullTest";
            this.mnuFullTest.Size = new System.Drawing.Size(148, 22);
            this.mnuFullTest.Text = "Full Test";
            this.mnuFullTest.Click += new System.EventHandler(this.mnuFullTest_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuSubTests
            // 
            this.mnuSubTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPowerOn,
            this.toolStripMenuItem3,
            this.dayModeToolStripMenuItem,
            this.nVGModeToolStripMenuItem,
            this.powerOffToolStripMenuItem});
            this.mnuSubTests.Enabled = false;
            this.mnuSubTests.Name = "mnuSubTests";
            this.mnuSubTests.Size = new System.Drawing.Size(148, 22);
            this.mnuSubTests.Text = "Sub Tests";
            // 
            // mnuPowerOn
            // 
            this.mnuPowerOn.Name = "mnuPowerOn";
            this.mnuPowerOn.Size = new System.Drawing.Size(166, 22);
            this.mnuPowerOn.Text = "1. Power On";
            this.mnuPowerOn.Click += new System.EventHandler(this.mnuPowerOn_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scratchesToolStripMenuItem,
            this.blemishesToolStripMenuItem,
            this.defectivePixelsToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem3.Text = "2. Display Defects";
            // 
            // scratchesToolStripMenuItem
            // 
            this.scratchesToolStripMenuItem.Name = "scratchesToolStripMenuItem";
            this.scratchesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.scratchesToolStripMenuItem.Text = "2.1. Scratches";
            // 
            // blemishesToolStripMenuItem
            // 
            this.blemishesToolStripMenuItem.Name = "blemishesToolStripMenuItem";
            this.blemishesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.blemishesToolStripMenuItem.Text = "2.2. Blemishes";
            // 
            // defectivePixelsToolStripMenuItem
            // 
            this.defectivePixelsToolStripMenuItem.Name = "defectivePixelsToolStripMenuItem";
            this.defectivePixelsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.defectivePixelsToolStripMenuItem.Text = "2.3. Defective Pixels";
            // 
            // dayModeToolStripMenuItem
            // 
            this.dayModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contrastDayToolStripMenuItem,
            this.brightnessRangeDayToolStripMenuItem,
            this.luminanceHomogeneityDayToolStripMenuItem,
            this.colorCoordinatesUniformityDayToolStripMenuItem});
            this.dayModeToolStripMenuItem.Name = "dayModeToolStripMenuItem";
            this.dayModeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.dayModeToolStripMenuItem.Text = "3. Day Mode";
            // 
            // contrastDayToolStripMenuItem
            // 
            this.contrastDayToolStripMenuItem.Name = "contrastDayToolStripMenuItem";
            this.contrastDayToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.contrastDayToolStripMenuItem.Text = "3.1. Contrast - Day";
            // 
            // brightnessRangeDayToolStripMenuItem
            // 
            this.brightnessRangeDayToolStripMenuItem.Name = "brightnessRangeDayToolStripMenuItem";
            this.brightnessRangeDayToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.brightnessRangeDayToolStripMenuItem.Text = "3.2. Brightness Range -  Day";
            // 
            // luminanceHomogeneityDayToolStripMenuItem
            // 
            this.luminanceHomogeneityDayToolStripMenuItem.Name = "luminanceHomogeneityDayToolStripMenuItem";
            this.luminanceHomogeneityDayToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.luminanceHomogeneityDayToolStripMenuItem.Text = "3.3. Luminance Homogeneity - Day";
            // 
            // colorCoordinatesUniformityDayToolStripMenuItem
            // 
            this.colorCoordinatesUniformityDayToolStripMenuItem.Name = "colorCoordinatesUniformityDayToolStripMenuItem";
            this.colorCoordinatesUniformityDayToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.colorCoordinatesUniformityDayToolStripMenuItem.Text = "3.4. Color Coordinates & Uniformity - Day";
            // 
            // nVGModeToolStripMenuItem
            // 
            this.nVGModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brightnessRangeNVGToolStripMenuItem,
            this.luminanceHomogeneityNVGToolStripMenuItem,
            this.colorCoordinatesNVGToolStripMenuItem,
            this.nVGCompatibilityToolStripMenuItem,
            this.bezelLightingToolStripMenuItem,
            this.bezelBacklightingToolStripMenuItem,
            this.powerLEDToolStripMenuItem});
            this.nVGModeToolStripMenuItem.Name = "nVGModeToolStripMenuItem";
            this.nVGModeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.nVGModeToolStripMenuItem.Text = "4. NVG Mode";
            // 
            // brightnessRangeNVGToolStripMenuItem
            // 
            this.brightnessRangeNVGToolStripMenuItem.Name = "brightnessRangeNVGToolStripMenuItem";
            this.brightnessRangeNVGToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.brightnessRangeNVGToolStripMenuItem.Text = "4.1. Brightness Range - NVG";
            // 
            // luminanceHomogeneityNVGToolStripMenuItem
            // 
            this.luminanceHomogeneityNVGToolStripMenuItem.Name = "luminanceHomogeneityNVGToolStripMenuItem";
            this.luminanceHomogeneityNVGToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.luminanceHomogeneityNVGToolStripMenuItem.Text = "4.2. Luminance Homogeneity - NVG";
            // 
            // colorCoordinatesNVGToolStripMenuItem
            // 
            this.colorCoordinatesNVGToolStripMenuItem.Name = "colorCoordinatesNVGToolStripMenuItem";
            this.colorCoordinatesNVGToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.colorCoordinatesNVGToolStripMenuItem.Text = "4.3. Color Coordinates - NVG";
            // 
            // nVGCompatibilityToolStripMenuItem
            // 
            this.nVGCompatibilityToolStripMenuItem.Name = "nVGCompatibilityToolStripMenuItem";
            this.nVGCompatibilityToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.nVGCompatibilityToolStripMenuItem.Text = "4.4. NVG Compatibility";
            // 
            // bezelLightingToolStripMenuItem
            // 
            this.bezelLightingToolStripMenuItem.Name = "bezelLightingToolStripMenuItem";
            this.bezelLightingToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.bezelLightingToolStripMenuItem.Text = "4.5. Bezel Lighting";
            // 
            //Bezel Backlighting
            //
            this.bezelBacklightingToolStripMenuItem.Name = "bezelBacklightingToolStripMenuItem";
            this.bezelBacklightingToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.bezelBacklightingToolStripMenuItem.Text = "4.6. Bezel Backlighting";
            //
            // powerLEDToolStripMenuItem
            // 
            this.powerLEDToolStripMenuItem.Name = "powerLEDToolStripMenuItem";
            this.powerLEDToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.powerLEDToolStripMenuItem.Text = "4.7. Power LED";
            // 
            // powerOffToolStripMenuItem
            // 
            this.powerOffToolStripMenuItem.Name = "powerOffToolStripMenuItem";
            this.powerOffToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.powerOffToolStripMenuItem.Text = "5. Power Off";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuEnterTestInfo
            // 
            this.mnuEnterTestInfo.Name = "mnuEnterTestInfo";
            this.mnuEnterTestInfo.Size = new System.Drawing.Size(148, 22);
            this.mnuEnterTestInfo.Text = "Enter Test Info";
            this.mnuEnterTestInfo.Click += new System.EventHandler(this.mnuEnterTestInfo_Click);
            // 
            // umnuUtilities
            // 
            this.umnuUtilities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClearResults,
            this.toolStripSeparator2,
            this.mnuACRO55,
            this.toolStripMenuItem2,
            this.mnuCS200});
            this.umnuUtilities.Name = "umnuUtilities";
            this.umnuUtilities.Size = new System.Drawing.Size(58, 20);
            this.umnuUtilities.Text = "Utilities";
            // 
            // mnuClearResults
            // 
            this.mnuClearResults.Name = "mnuClearResults";
            this.mnuClearResults.Size = new System.Drawing.Size(141, 22);
            this.mnuClearResults.Text = "Clear Results";
            this.mnuClearResults.Click += new System.EventHandler(this.mnuClearResults_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // mnuACRO55
            // 
            this.mnuACRO55.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuACRO55Home,
            this.mnuACRO55ClearAlarm,
            this.mnuACRO55ShowDialog,
            this.mnuACRO55Calibrate});
            this.mnuACRO55.Name = "mnuACRO55";
            this.mnuACRO55.Size = new System.Drawing.Size(141, 22);
            this.mnuACRO55.Text = "ACRO55";
            // 
            // mnuACRO55Home
            // 
            this.mnuACRO55Home.Name = "mnuACRO55Home";
            this.mnuACRO55Home.Size = new System.Drawing.Size(185, 22);
            this.mnuACRO55Home.Text = "Home";
            this.mnuACRO55Home.Click += new System.EventHandler(this.mnuACRO55Home_Click);
            // 
            // mnuACRO55ClearAlarm
            // 
            this.mnuACRO55ClearAlarm.Name = "mnuACRO55ClearAlarm";
            this.mnuACRO55ClearAlarm.Size = new System.Drawing.Size(185, 22);
            this.mnuACRO55ClearAlarm.Text = "Clear Alarm";
            this.mnuACRO55ClearAlarm.Click += new System.EventHandler(this.mnuACRO55ClearAlarm_Click);
            // 
            // mnuACRO55ShowDialog
            // 
            this.mnuACRO55ShowDialog.Name = "mnuACRO55ShowDialog";
            this.mnuACRO55ShowDialog.Size = new System.Drawing.Size(185, 22);
            this.mnuACRO55ShowDialog.Text = "Show Dialog";
            this.mnuACRO55ShowDialog.Click += new System.EventHandler(this.mnuACRO55ShowDialog_Click);
            // 
            // mnuACRO55Calibrate
            // 
            this.mnuACRO55Calibrate.Name = "mnuACRO55Calibrate";
            this.mnuACRO55Calibrate.Size = new System.Drawing.Size(185, 22);
            this.mnuACRO55Calibrate.Text = "Calibrate X-Y to MFD";
            this.mnuACRO55Calibrate.Click += new System.EventHandler(this.mnuACRO55Calibrate_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 6);
            // 
            // mnuCS200
            // 
            this.mnuCS200.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCS200Connect,
            this.mnuCS200Disconnect,
            this.toolStripSeparator3,
            this.enableRemoteModeToolStripMenuItem,
            this.disableRemoteModeToolStripMenuItem,
            this.toolStripSeparator4,
            this.setMediumBrightnessDayToolStripMenuItem,
            this.setMediumBrightnessNVGToolStripMenuItem});
            this.mnuCS200.Name = "mnuCS200";
            this.mnuCS200.Size = new System.Drawing.Size(141, 22);
            this.mnuCS200.Text = "CS-200";
            // 
            // mnuCS200Connect
            // 
            this.mnuCS200Connect.Name = "mnuCS200Connect";
            this.mnuCS200Connect.Size = new System.Drawing.Size(247, 22);
            this.mnuCS200Connect.Text = "Connect USB Communication";
            this.mnuCS200Connect.Click += new System.EventHandler(this.mnuCS200Connect_Click);
            // 
            // mnuCS200Disconnect
            // 
            this.mnuCS200Disconnect.Name = "mnuCS200Disconnect";
            this.mnuCS200Disconnect.Size = new System.Drawing.Size(247, 22);
            this.mnuCS200Disconnect.Text = "Disconnect USB Communication";
            this.mnuCS200Disconnect.Click += new System.EventHandler(this.mnuCS200Disconnect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(244, 6);
            // 
            // enableRemoteModeToolStripMenuItem
            // 
            this.enableRemoteModeToolStripMenuItem.Name = "enableRemoteModeToolStripMenuItem";
            this.enableRemoteModeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.enableRemoteModeToolStripMenuItem.Text = "Enable Remote Mode";
            this.enableRemoteModeToolStripMenuItem.Click += new System.EventHandler(this.enableRemoteModeToolStripMenuItem_Click);
            // 
            // disableRemoteModeToolStripMenuItem
            // 
            this.disableRemoteModeToolStripMenuItem.Name = "disableRemoteModeToolStripMenuItem";
            this.disableRemoteModeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.disableRemoteModeToolStripMenuItem.Text = "Disable Remote Mode";
            this.disableRemoteModeToolStripMenuItem.Click += new System.EventHandler(this.disableRemoteModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(244, 6);
            // 
            // setMediumBrightnessDayToolStripMenuItem
            // 
            this.setMediumBrightnessDayToolStripMenuItem.Name = "setMediumBrightnessDayToolStripMenuItem";
            this.setMediumBrightnessDayToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.setMediumBrightnessDayToolStripMenuItem.Text = "Set Medium Brightness - Day";
            this.setMediumBrightnessDayToolStripMenuItem.Click += new System.EventHandler(this.setMediumBrightnessDayToolStripMenuItem_Click);
            // 
            // setMediumBrightnessNVGToolStripMenuItem
            // 
            this.setMediumBrightnessNVGToolStripMenuItem.Name = "setMediumBrightnessNVGToolStripMenuItem";
            this.setMediumBrightnessNVGToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.setMediumBrightnessNVGToolStripMenuItem.Text = "Set Medium Brightness - NVG";
            this.setMediumBrightnessNVGToolStripMenuItem.Click += new System.EventHandler(this.setMediumBrightnessNVGToolStripMenuItem_Click);
            // 
            // testDevelopmentToolStripMenuItem
            // 
            this.testDevelopmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeadersAndData,
            this.mnuPrompts,
            this.mnuAdjBrightnessPopup});
            this.testDevelopmentToolStripMenuItem.Enabled = false;
            this.testDevelopmentToolStripMenuItem.Name = "testDevelopmentToolStripMenuItem";
            this.testDevelopmentToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.testDevelopmentToolStripMenuItem.Text = "Test Development";
            this.testDevelopmentToolStripMenuItem.Visible = false;
            // 
            // mnuHeadersAndData
            // 
            this.mnuHeadersAndData.Name = "mnuHeadersAndData";
            this.mnuHeadersAndData.Size = new System.Drawing.Size(204, 22);
            this.mnuHeadersAndData.Text = "Headers and Data";
            this.mnuHeadersAndData.Click += new System.EventHandler(this.mnuHeadersAndData_Click);
            // 
            // mnuPrompts
            // 
            this.mnuPrompts.Name = "mnuPrompts";
            this.mnuPrompts.Size = new System.Drawing.Size(204, 22);
            this.mnuPrompts.Text = "Prompts";
            this.mnuPrompts.Click += new System.EventHandler(this.mnuPrompts_Click);
            // 
            // mnuAdjBrightnessPopup
            // 
            this.mnuAdjBrightnessPopup.Name = "mnuAdjBrightnessPopup";
            this.mnuAdjBrightnessPopup.Size = new System.Drawing.Size(204, 22);
            this.mnuAdjBrightnessPopup.Text = "Adjust Brightness Popup";
            this.mnuAdjBrightnessPopup.Click += new System.EventHandler(this.mnuAdjBrightnessPopup_Click);
            // 
            // rtbTestResults
            // 
            this.rtbTestResults.BackColor = System.Drawing.Color.LightYellow;
            this.rtbTestResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTestResults.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTestResults.Location = new System.Drawing.Point(0, 0);
            this.rtbTestResults.Name = "rtbTestResults";
            this.rtbTestResults.ReadOnly = true;
            this.rtbTestResults.Size = new System.Drawing.Size(727, 532);
            this.rtbTestResults.TabIndex = 4;
            this.rtbTestResults.Text = "";
            // 
            // hdgUUT
            // 
            this.hdgUUT.Dock = System.Windows.Forms.DockStyle.Top;
            this.hdgUUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdgUUT.Location = new System.Drawing.Point(6, 3);
            this.hdgUUT.Name = "hdgUUT";
            this.hdgUUT.Size = new System.Drawing.Size(43, 21);
            this.hdgUUT.TabIndex = 0;
            this.hdgUUT.Text = "UUT :";
            this.hdgUUT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSWVer
            // 
            this.lblSWVer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSWVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSWVer.Location = new System.Drawing.Point(730, 3);
            this.lblSWVer.Name = "lblSWVer";
            this.lblSWVer.Size = new System.Drawing.Size(113, 21);
            this.lblSWVer.TabIndex = 0;
            this.lblSWVer.Text = "Software Version :";
            this.lblSWVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel010
            // 
            this.panel010.BackColor = System.Drawing.Color.Beige;
            this.panel010.Controls.Add(this.groupBox6);
            this.panel010.Controls.Add(this.groupBox5);
            this.panel010.Controls.Add(this.groupBox4);
            this.panel010.Controls.Add(this.groupBox3);
            this.panel010.Controls.Add(this.groupBox2);
            this.panel010.Controls.Add(this.groupBox1);
            this.panel010.Location = new System.Drawing.Point(0, 59);
            this.panel010.Name = "panel010";
            this.panel010.Size = new System.Drawing.Size(1058, 71);
            this.panel010.TabIndex = 7;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Beige;
            this.groupBox6.Controls.Add(this.btnUUTPower);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(961, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(87, 62);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "UUT Power";
            this.groupBox6.Visible = false;
            // 
            // btnUUTPower
            // 
            this.btnUUTPower.BackColor = System.Drawing.Color.Red;
            this.btnUUTPower.Enabled = false;
            this.btnUUTPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUUTPower.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUUTPower.Location = new System.Drawing.Point(9, 16);
            this.btnUUTPower.Name = "btnUUTPower";
            this.btnUUTPower.Size = new System.Drawing.Size(70, 40);
            this.btnUUTPower.TabIndex = 0;
            this.btnUUTPower.Text = "Off";
            this.btnUUTPower.UseVisualStyleBackColor = false;
            this.btnUUTPower.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Beige;
            this.groupBox5.Controls.Add(this.btnExit);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.DarkMagenta;
            this.groupBox5.Location = new System.Drawing.Point(770, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(102, 63);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Exit";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Beige;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExit.Location = new System.Drawing.Point(6, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 25);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Beige;
            this.groupBox4.Controls.Add(this.comboBox3);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.DarkMagenta;
            this.groupBox4.Location = new System.Drawing.Point(648, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(116, 63);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "View";
            this.groupBox4.Visible = false;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.Beige;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(7, 20);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(104, 21);
            this.comboBox3.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Beige;
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DarkMagenta;
            this.groupBox3.Location = new System.Drawing.Point(526, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(116, 63);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            this.groupBox3.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.Beige;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(7, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(104, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Beige;
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkMagenta;
            this.groupBox2.Location = new System.Drawing.Point(404, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(116, 63);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "On Fail";
            this.groupBox2.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Beige;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Beige;
            this.groupBox1.Controls.Add(this.lblF1);
            this.groupBox1.Controls.Add(this.lblF3);
            this.groupBox1.Controls.Add(this.lblF8);
            this.groupBox1.Controls.Add(this.lblF9);
            this.groupBox1.Controls.Add(this.btnHelp);
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.btnLoop);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // lblF1
            // 
            this.lblF1.AutoSize = true;
            this.lblF1.Enabled = false;
            this.lblF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblF1.Location = new System.Drawing.Point(332, 44);
            this.lblF1.Name = "lblF1";
            this.lblF1.Size = new System.Drawing.Size(19, 13);
            this.lblF1.TabIndex = 3;
            this.lblF1.Text = "F1";
            // 
            // lblF3
            // 
            this.lblF3.AutoSize = true;
            this.lblF3.Enabled = false;
            this.lblF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblF3.Location = new System.Drawing.Point(236, 44);
            this.lblF3.Name = "lblF3";
            this.lblF3.Size = new System.Drawing.Size(19, 13);
            this.lblF3.TabIndex = 6;
            this.lblF3.Text = "F3";
            this.lblF3.Visible = false;
            // 
            // lblF8
            // 
            this.lblF8.AutoSize = true;
            this.lblF8.Enabled = false;
            this.lblF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblF8.Location = new System.Drawing.Point(140, 44);
            this.lblF8.Name = "lblF8";
            this.lblF8.Size = new System.Drawing.Size(19, 13);
            this.lblF8.TabIndex = 5;
            this.lblF8.Text = "F8";
            this.lblF8.Visible = false;
            // 
            // lblF9
            // 
            this.lblF9.AutoSize = true;
            this.lblF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblF9.Location = new System.Drawing.Point(44, 44);
            this.lblF9.Name = "lblF9";
            this.lblF9.Size = new System.Drawing.Size(21, 13);
            this.lblF9.TabIndex = 4;
            this.lblF9.Text = "F9";
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Beige;
            this.btnHelp.Enabled = false;
            this.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHelp.Location = new System.Drawing.Point(296, 16);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(90, 25);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Beige;
            this.btnPause.Enabled = false;
            this.btnPause.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPause.Location = new System.Drawing.Point(200, 16);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(90, 25);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Visible = false;
            // 
            // btnLoop
            // 
            this.btnLoop.BackColor = System.Drawing.Color.Beige;
            this.btnLoop.Enabled = false;
            this.btnLoop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoop.Location = new System.Drawing.Point(104, 16);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(90, 25);
            this.btnLoop.TabIndex = 1;
            this.btnLoop.Text = "Loop";
            this.btnLoop.UseVisualStyleBackColor = false;
            this.btnLoop.Visible = false;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.Beige;
            this.btnRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRun.Location = new System.Drawing.Point(8, 16);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(90, 25);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // hdgStatus
            // 
            this.hdgStatus.AutoSize = true;
            this.hdgStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.hdgStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdgStatus.Location = new System.Drawing.Point(373, 3);
            this.hdgStatus.Name = "hdgStatus";
            this.hdgStatus.Size = new System.Drawing.Size(51, 21);
            this.hdgStatus.TabIndex = 1;
            this.hdgStatus.Text = "Status :";
            this.hdgStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hdgFailures
            // 
            this.hdgFailures.AutoSize = true;
            this.hdgFailures.Dock = System.Windows.Forms.DockStyle.Left;
            this.hdgFailures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdgFailures.Location = new System.Drawing.Point(773, 3);
            this.hdgFailures.Name = "hdgFailures";
            this.hdgFailures.Size = new System.Drawing.Size(59, 21);
            this.hdgFailures.TabIndex = 1;
            this.hdgFailures.Text = "Failures :";
            this.hdgFailures.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hdgTaskName
            // 
            this.hdgTaskName.Dock = System.Windows.Forms.DockStyle.Top;
            this.hdgTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdgTaskName.Location = new System.Drawing.Point(6, 3);
            this.hdgTaskName.Name = "hdgTaskName";
            this.hdgTaskName.Size = new System.Drawing.Size(80, 21);
            this.hdgTaskName.TabIndex = 0;
            this.hdgTaskName.Text = "Task Name :";
            this.hdgTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hdgTestName
            // 
            this.hdgTestName.AutoSize = true;
            this.hdgTestName.Dock = System.Windows.Forms.DockStyle.Left;
            this.hdgTestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdgTestName.Location = new System.Drawing.Point(348, 3);
            this.hdgTestName.Name = "hdgTestName";
            this.hdgTestName.Size = new System.Drawing.Size(76, 21);
            this.hdgTestName.TabIndex = 0;
            this.hdgTestName.Text = "Test Name :";
            this.hdgTestName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hdgLoops
            // 
            this.hdgLoops.Dock = System.Windows.Forms.DockStyle.Left;
            this.hdgLoops.Enabled = false;
            this.hdgLoops.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdgLoops.Location = new System.Drawing.Point(691, 3);
            this.hdgLoops.Name = "hdgLoops";
            this.hdgLoops.Size = new System.Drawing.Size(115, 21);
            this.hdgLoops.TabIndex = 0;
            this.hdgLoops.Text = "Successful Loops :";
            this.hdgLoops.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hdgLoops.Visible = false;
            // 
            // hdgEstTime
            // 
            this.hdgEstTime.AutoSize = true;
            this.hdgEstTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.hdgEstTime.Enabled = false;
            this.hdgEstTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdgEstTime.Location = new System.Drawing.Point(861, 3);
            this.hdgEstTime.Name = "hdgEstTime";
            this.hdgEstTime.Size = new System.Drawing.Size(129, 21);
            this.hdgEstTime.TabIndex = 0;
            this.hdgEstTime.Text = "ATP Estimated Time :";
            this.hdgEstTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hdgEstTime.Visible = false;
            // 
            // lblEstimatedTime
            // 
            this.lblEstimatedTime.AutoSize = true;
            this.lblEstimatedTime.BackColor = System.Drawing.Color.Beige;
            this.lblEstimatedTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEstimatedTime.Enabled = false;
            this.lblEstimatedTime.Location = new System.Drawing.Point(1003, 3);
            this.lblEstimatedTime.Name = "lblEstimatedTime";
            this.lblEstimatedTime.Size = new System.Drawing.Size(38, 21);
            this.lblEstimatedTime.TabIndex = 11;
            this.lblEstimatedTime.Text = "NONE";
            this.lblEstimatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEstimatedTime.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Beige;
            this.groupBox7.Controls.Add(this.progressBar1);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(0, 665);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(877, 53);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(864, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // panel031
            // 
            this.panel031.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel031.Controls.Add(this.lblReady);
            this.panel031.Location = new System.Drawing.Point(883, 6);
            this.panel031.Name = "panel031";
            this.panel031.Size = new System.Drawing.Size(87, 47);
            this.panel031.TabIndex = 12;
            // 
            // lblReady
            // 
            this.lblReady.AutoSize = true;
            this.lblReady.BackColor = System.Drawing.Color.LawnGreen;
            this.lblReady.Enabled = false;
            this.lblReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReady.Location = new System.Drawing.Point(9, 15);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(60, 16);
            this.lblReady.TabIndex = 0;
            this.lblReady.Text = "READY";
            this.lblReady.Visible = false;
            // 
            // panel032
            // 
            this.panel032.BackColor = System.Drawing.Color.Beige;
            this.panel032.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel032.Controls.Add(this.btnAbort);
            this.panel032.Location = new System.Drawing.Point(969, 6);
            this.panel032.Name = "panel032";
            this.panel032.Size = new System.Drawing.Size(87, 47);
            this.panel032.TabIndex = 13;
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.Beige;
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.Location = new System.Drawing.Point(5, 6);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 34);
            this.btnAbort.TabIndex = 0;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // panel030
            // 
            this.panel030.BackColor = System.Drawing.Color.Beige;
            this.panel030.Controls.Add(this.panel032);
            this.panel030.Controls.Add(this.tableLayoutPanel2);
            this.panel030.Controls.Add(this.panel031);
            this.panel030.Location = new System.Drawing.Point(0, 665);
            this.panel030.Name = "panel030";
            this.panel030.Size = new System.Drawing.Size(1058, 111);
            this.panel030.TabIndex = 14;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Beige;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 252F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.Controls.Add(this.lblEstimatedTime, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.hdgEstTime, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.hdgLoops, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.hdgTestName, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.hdgTaskName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTaskName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTestName, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1056, 27);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTaskName.Location = new System.Drawing.Point(95, 3);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(0, 21);
            this.lblTaskName.TabIndex = 12;
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTestName.Location = new System.Drawing.Point(436, 3);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(0, 21);
            this.lblTestName.TabIndex = 13;
            this.lblTestName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTestName.UseMnemonic = false;
            // 
            // panel020
            // 
            this.panel020.BackColor = System.Drawing.SystemColors.Control;
            this.panel020.Controls.Add(this.splitContainer1);
            this.panel020.Location = new System.Drawing.Point(0, 131);
            this.panel020.Name = "panel020";
            this.panel020.Size = new System.Drawing.Size(1058, 532);
            this.panel020.TabIndex = 15;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.testSelectionTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbTestResults);
            this.splitContainer1.Size = new System.Drawing.Size(1058, 532);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 0;
            // 
            // testSelectionTree
            // 
            this.testSelectionTree.CheckBoxes = true;
            this.testSelectionTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testSelectionTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSelectionTree.Location = new System.Drawing.Point(0, 0);
            this.testSelectionTree.Name = "testSelectionTree";
            treeNode1.Name = "Node1_1";
            treeNode1.Text = "1.1. Power On";
            treeNode2.Name = "Node1";
            treeNode2.Text = "1. Power On";
            treeNode3.Name = "Node2_1";
            treeNode3.Text = "2.1. Scratches";
            treeNode4.Name = "Node2_2";
            treeNode4.Text = "2.2. Blemishes";
            treeNode5.Name = "Node2_3";
            treeNode5.Text = "2.3. Defective Pixels";
            treeNode6.Name = "Node2";
            treeNode6.Text = "2. Display Defects";
            treeNode7.Name = "Node3_1";
            treeNode7.Text = "3.1. Contrast - Day";
            treeNode8.Name = "Node3_2";
            treeNode8.Text = "3.2. Brightness Range - Day";
            treeNode9.Name = "Node3_3";
            treeNode9.Text = "3.3. Luminance Homogeneity - Day";
            treeNode10.Name = "Node3_4";
            treeNode10.Text = "3.4. Color Coordinates & Uniformity - Day";
            treeNode11.Name = "Node3";
            treeNode11.Text = "3. Day Mode";
            treeNode12.Name = "Node4_1";
            treeNode12.Text = "4.1. Brightness Range - NVG";
            treeNode13.Name = "Node4_2";
            treeNode13.Text = "4.2. Luminance Homogeneity - NVG";
            treeNode14.Name = "Node4_3";
            treeNode14.Text = "4.3. Color Coordinates - NVG";
            treeNode15.Name = "Node4_4";
            treeNode15.Text = "4.4. NVG Compatibility";
            treeNode16.Name = "Node4_5";
            treeNode16.Text = "4.5. Bezel Lighting";
            treeNode17.Name = "Node4_6";
            treeNode17.Text = "4.6. Bezel Backlighting";
            treeNode18.Name = "Node4_7";
            treeNode18.Text = "4.7. Power LED";
            treeNode19.Name = "Node4";
            treeNode19.Text = "4. NVG Mode";
            treeNode20.Name = "Node5_1";
            treeNode20.Text = "5.1. Power Off";
            treeNode21.Name = "Node5";
            treeNode21.Text = "5. Power Off";
            treeNode22.Name = "Node0";
            treeNode22.Text = "MFD_Optical Tests";
            this.testSelectionTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22});
            this.testSelectionTree.ShowPlusMinus = false;
            this.testSelectionTree.ShowRootLines = false;
            this.testSelectionTree.Size = new System.Drawing.Size(327, 532);
            this.testSelectionTree.TabIndex = 0;
            this.testSelectionTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeSelectedTests_AfterCheck);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Beige;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            this.tableLayoutPanel1.Controls.Add(this.hdgUUT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUUTPartNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSoftwareVersion, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSWVer, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.hdgOperator, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.hdgSN, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUUTSerialNo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOperatorName, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1058, 32);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // lblUUTPartNo
            // 
            this.lblUUTPartNo.Location = new System.Drawing.Point(58, 3);
            this.lblUUTPartNo.Name = "lblUUTPartNo";
            this.lblUUTPartNo.Size = new System.Drawing.Size(112, 23);
            this.lblUUTPartNo.TabIndex = 1;
            this.lblUUTPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoftwareVersion
            // 
            this.lblSoftwareVersion.Location = new System.Drawing.Point(852, 3);
            this.lblSoftwareVersion.Name = "lblSoftwareVersion";
            this.lblSoftwareVersion.Size = new System.Drawing.Size(127, 21);
            this.lblSoftwareVersion.TabIndex = 3;
            this.lblSoftwareVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hdgOperator
            // 
            this.hdgOperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.hdgOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdgOperator.Location = new System.Drawing.Point(347, 3);
            this.hdgOperator.Name = "hdgOperator";
            this.hdgOperator.Size = new System.Drawing.Size(71, 21);
            this.hdgOperator.TabIndex = 0;
            this.hdgOperator.Text = "Operator :";
            this.hdgOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hdgSN
            // 
            this.hdgSN.Dock = System.Windows.Forms.DockStyle.Top;
            this.hdgSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdgSN.Location = new System.Drawing.Point(181, 3);
            this.hdgSN.Name = "hdgSN";
            this.hdgSN.Size = new System.Drawing.Size(34, 21);
            this.hdgSN.TabIndex = 0;
            this.hdgSN.Text = "SN :";
            this.hdgSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUUTSerialNo
            // 
            this.lblUUTSerialNo.Location = new System.Drawing.Point(224, 3);
            this.lblUUTSerialNo.Name = "lblUUTSerialNo";
            this.lblUUTSerialNo.Size = new System.Drawing.Size(114, 23);
            this.lblUUTSerialNo.TabIndex = 1;
            this.lblUUTSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.Location = new System.Drawing.Point(427, 3);
            this.lblOperatorName.Name = "lblOperatorName";
            this.lblOperatorName.Size = new System.Drawing.Size(294, 23);
            this.lblOperatorName.TabIndex = 2;
            this.lblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Beige;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.tableLayoutPanel3.Controls.Add(this.hdgFailures, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.hdgStatus, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblStatus, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblDate, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTime, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblFailures, 6, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 747);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1056, 27);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatus.Location = new System.Drawing.Point(436, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 21);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(138, 3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(1, 21);
            this.lblDate.TabIndex = 3;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(280, 3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(84, 21);
            this.lblTime.TabIndex = 4;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFailures
            // 
            this.lblFailures.AutoSize = true;
            this.lblFailures.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFailures.Location = new System.Drawing.Point(843, 3);
            this.lblFailures.Name = "lblFailures";
            this.lblFailures.Size = new System.Drawing.Size(0, 21);
            this.lblFailures.TabIndex = 5;
            this.lblFailures.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MFD_Optical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1059, 776);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel020);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.panel010);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel030);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MFD_Optical";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CIGALHE MFD - Optical Tests";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MFD_OpticalForm_FormClosing);
            this.Load += new System.EventHandler(this.MFD_OpticalForm_Load);
            this.Shown += new System.EventHandler(this.MFD_OpticalForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel010.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.panel031.ResumeLayout(false);
            this.panel031.PerformLayout();
            this.panel032.ResumeLayout(false);
            this.panel030.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel020.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuRunTests;
        private System.Windows.Forms.ToolStripMenuItem mnuFullTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSubTests;
        private System.Windows.Forms.ToolStripMenuItem mnuPowerOn;
        private System.Windows.Forms.RichTextBox rtbTestResults;
        private System.Windows.Forms.ToolStripMenuItem umnuUtilities;
        private System.Windows.Forms.ToolStripMenuItem mnuACRO55;
        private System.Windows.Forms.ToolStripMenuItem mnuACRO55Home;
        private System.Windows.Forms.ToolStripMenuItem mnuACRO55ClearAlarm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuCS200;
        private System.Windows.Forms.Label hdgUUT;
        private System.Windows.Forms.Label lblSWVer;
        private System.Windows.Forms.Panel panel010;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnUUTPower;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblF1;
        private System.Windows.Forms.Label lblF3;
        private System.Windows.Forms.Label lblF8;
        private System.Windows.Forms.Label lblF9;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label hdgStatus;
        private System.Windows.Forms.Label hdgFailures;
        private System.Windows.Forms.Label hdgTaskName;
        private System.Windows.Forms.Label hdgTestName;
        private System.Windows.Forms.Label hdgLoops;
        private System.Windows.Forms.Label hdgEstTime;
        private System.Windows.Forms.Label lblEstimatedTime;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel031;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Panel panel032;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Panel panel030;
        private System.Windows.Forms.Panel panel020;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuACRO55ShowDialog;
        private System.Windows.Forms.Label hdgOperator;
        private System.Windows.Forms.Label lblSoftwareVersion;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label hdgSN;
        private System.Windows.Forms.TreeView testSelectionTree;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ToolStripMenuItem mnuClearResults;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem testDevelopmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHeadersAndData;
        private System.Windows.Forms.ToolStripMenuItem mnuPrompts;
        private System.Windows.Forms.ToolStripMenuItem mnuAdjBrightnessPopup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuEnterTestInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem scratchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blemishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defectivePixelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessRangeDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luminanceHomogeneityDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorCoordinatesUniformityDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nVGModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessRangeNVGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luminanceHomogeneityNVGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorCoordinatesNVGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nVGCompatibilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bezelLightingToolStripMenuItem;
        private ToolStripMenuItem bezelBacklightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerLEDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuACRO55Calibrate;
        private System.Windows.Forms.ToolStripMenuItem mnuCS200Connect;
        private System.Windows.Forms.ToolStripMenuItem mnuCS200Disconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem enableRemoteModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableRemoteModeToolStripMenuItem;
        internal System.Windows.Forms.Label lblOperatorName;
        internal System.Windows.Forms.Label lblUUTPartNo;
        internal System.Windows.Forms.Label lblUUTSerialNo;
        private System.Windows.Forms.Label lblFailures;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem setMediumBrightnessDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setMediumBrightnessNVGToolStripMenuItem;
    }
}

