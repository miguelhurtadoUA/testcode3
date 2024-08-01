namespace CIGALHE.MFD.Optical
{
    internal partial class ScratchesForm
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
            this.components = new System.ComponentModel.Container();
            this.lblMediumWidth = new System.Windows.Forms.Label();
            this.chkBacklightingOff = new System.Windows.Forms.CheckBox();
            this.chkAuxLightOn = new System.Windows.Forms.CheckBox();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.grpScratches = new System.Windows.Forms.GroupBox();
            this.lblLengths = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtHeavyScratchesLengths = new System.Windows.Forms.TextBox();
            this.txtMediumScratchesLengths = new System.Windows.Forms.TextBox();
            this.lblHeavyWidth = new System.Windows.Forms.Label();
            this.lblSmudgesQuestion = new System.Windows.Forms.Label();
            this.radYesSmudges = new System.Windows.Forms.RadioButton();
            this.radNoSmudges = new System.Windows.Forms.RadioButton();
            this.grpSmudges = new System.Windows.Forms.GroupBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpSetup.SuspendLayout();
            this.grpScratches.SuspendLayout();
            this.grpSmudges.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMediumWidth
            // 
            this.lblMediumWidth.AutoSize = true;
            this.lblMediumWidth.Location = new System.Drawing.Point(8, 73);
            this.lblMediumWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMediumWidth.Name = "lblMediumWidth";
            this.lblMediumWidth.Size = new System.Drawing.Size(98, 16);
            this.lblMediumWidth.TabIndex = 1;
            this.lblMediumWidth.Text = "0.10 to 0.25 mm";
            // 
            // chkBacklightingOff
            // 
            this.chkBacklightingOff.AutoSize = true;
            this.chkBacklightingOff.Location = new System.Drawing.Point(8, 22);
            this.chkBacklightingOff.Margin = new System.Windows.Forms.Padding(4);
            this.chkBacklightingOff.Name = "chkBacklightingOff";
            this.chkBacklightingOff.Size = new System.Drawing.Size(173, 20);
            this.chkBacklightingOff.TabIndex = 0;
            this.chkBacklightingOff.Text = "MFD backlighting is OFF";
            this.chkBacklightingOff.UseVisualStyleBackColor = true;
            // 
            // chkAuxLightOn
            // 
            this.chkAuxLightOn.AutoSize = true;
            this.chkAuxLightOn.Location = new System.Drawing.Point(8, 50);
            this.chkAuxLightOn.Margin = new System.Windows.Forms.Padding(4);
            this.chkAuxLightOn.Name = "chkAuxLightOn";
            this.chkAuxLightOn.Size = new System.Drawing.Size(173, 20);
            this.chkAuxLightOn.TabIndex = 1;
            this.chkAuxLightOn.Text = "Supplemental light is ON";
            this.chkAuxLightOn.UseVisualStyleBackColor = true;
            // 
            // grpSetup
            // 
            this.grpSetup.Controls.Add(this.chkBacklightingOff);
            this.grpSetup.Controls.Add(this.chkAuxLightOn);
            this.grpSetup.Location = new System.Drawing.Point(20, 17);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(200, 79);
            this.grpSetup.TabIndex = 0;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "Setup";
            // 
            // grpScratches
            // 
            this.grpScratches.Controls.Add(this.lblLengths);
            this.grpScratches.Controls.Add(this.lblWidth);
            this.grpScratches.Controls.Add(this.txtHeavyScratchesLengths);
            this.grpScratches.Controls.Add(this.txtMediumScratchesLengths);
            this.grpScratches.Controls.Add(this.lblHeavyWidth);
            this.grpScratches.Controls.Add(this.lblMediumWidth);
            this.grpScratches.Location = new System.Drawing.Point(20, 114);
            this.grpScratches.Name = "grpScratches";
            this.grpScratches.Size = new System.Drawing.Size(236, 101);
            this.grpScratches.TabIndex = 2;
            this.grpScratches.TabStop = false;
            this.grpScratches.Text = "Scratches";
            // 
            // lblLengths
            // 
            this.lblLengths.AutoSize = true;
            this.lblLengths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLengths.Location = new System.Drawing.Point(123, 22);
            this.lblLengths.Name = "lblLengths";
            this.lblLengths.Size = new System.Drawing.Size(88, 16);
            this.lblLengths.TabIndex = 0;
            this.lblLengths.Text = "Lengths (mm)";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.Location = new System.Drawing.Point(8, 22);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(42, 16);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width";
            // 
            // txtHeavyScratchesLengths
            // 
            this.txtHeavyScratchesLengths.Location = new System.Drawing.Point(126, 42);
            this.txtHeavyScratchesLengths.Name = "txtHeavyScratchesLengths";
            this.txtHeavyScratchesLengths.Size = new System.Drawing.Size(102, 22);
            this.txtHeavyScratchesLengths.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtHeavyScratchesLengths, "Enter the length of each scratch, separated by a space, comma,\r\nor both.  For exa" +
        "mple, for three scratches of lengths 4 mm, 5 mm\r\nand 2 mm, enter: 4 5 2.  Or, en" +
        "ter: 4,5,2.\r\n");
            // 
            // txtMediumScratchesLengths
            // 
            this.txtMediumScratchesLengths.Location = new System.Drawing.Point(126, 70);
            this.txtMediumScratchesLengths.Name = "txtMediumScratchesLengths";
            this.txtMediumScratchesLengths.Size = new System.Drawing.Size(102, 22);
            this.txtMediumScratchesLengths.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtMediumScratchesLengths, "Enter the length of each scratch, separated by a space, comma,\r\nor both.  For exa" +
        "mple, for three scratches of lengths 4 mm, 5 mm\r\nand 2 mm, enter: 4 5 2.  Or, en" +
        "ter: 4,5,2.");
            // 
            // lblHeavyWidth
            // 
            this.lblHeavyWidth.AutoSize = true;
            this.lblHeavyWidth.Location = new System.Drawing.Point(8, 45);
            this.lblHeavyWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeavyWidth.Name = "lblHeavyWidth";
            this.lblHeavyWidth.Size = new System.Drawing.Size(67, 16);
            this.lblHeavyWidth.TabIndex = 0;
            this.lblHeavyWidth.Text = "> 0.25 mm";
            // 
            // lblSmudgesQuestion
            // 
            this.lblSmudgesQuestion.AutoSize = true;
            this.lblSmudgesQuestion.Location = new System.Drawing.Point(8, 24);
            this.lblSmudgesQuestion.Name = "lblSmudgesQuestion";
            this.lblSmudgesQuestion.Size = new System.Drawing.Size(297, 32);
            this.lblSmudgesQuestion.TabIndex = 0;
            this.lblSmudgesQuestion.Text = "Is the LCD free of concentrations of fine scratches\r\n(< 0.1 mm wide) that would a" +
    "ppear as smudges?";
            // 
            // radYesSmudges
            // 
            this.radYesSmudges.AutoSize = true;
            this.radYesSmudges.Location = new System.Drawing.Point(205, 60);
            this.radYesSmudges.Name = "radYesSmudges";
            this.radYesSmudges.Size = new System.Drawing.Size(50, 20);
            this.radYesSmudges.TabIndex = 0;
            this.radYesSmudges.TabStop = true;
            this.radYesSmudges.Text = "Yes";
            this.radYesSmudges.UseVisualStyleBackColor = true;
            // 
            // radNoSmudges
            // 
            this.radNoSmudges.AutoSize = true;
            this.radNoSmudges.Location = new System.Drawing.Point(261, 60);
            this.radNoSmudges.Name = "radNoSmudges";
            this.radNoSmudges.Size = new System.Drawing.Size(44, 20);
            this.radNoSmudges.TabIndex = 1;
            this.radNoSmudges.TabStop = true;
            this.radNoSmudges.Text = "No";
            this.radNoSmudges.UseVisualStyleBackColor = true;
            // 
            // grpSmudges
            // 
            this.grpSmudges.Controls.Add(this.lblSmudgesQuestion);
            this.grpSmudges.Controls.Add(this.radNoSmudges);
            this.grpSmudges.Controls.Add(this.radYesSmudges);
            this.grpSmudges.Location = new System.Drawing.Point(20, 233);
            this.grpSmudges.Name = "grpSmudges";
            this.grpSmudges.Size = new System.Drawing.Size(313, 92);
            this.grpSmudges.TabIndex = 3;
            this.grpSmudges.TabStop = false;
            this.grpSmudges.Text = "Smudges";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(258, 342);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 7000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // ScratchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 377);
            this.ControlBox = false;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.grpSmudges);
            this.Controls.Add(this.grpScratches);
            this.Controls.Add(this.grpSetup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScratchesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Display Defects - Scratches";
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            this.grpScratches.ResumeLayout(false);
            this.grpScratches.PerformLayout();
            this.grpSmudges.ResumeLayout(false);
            this.grpSmudges.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMediumWidth;
        private System.Windows.Forms.GroupBox grpSetup;
        private System.Windows.Forms.GroupBox grpScratches;
        private System.Windows.Forms.Label lblHeavyWidth;
        private System.Windows.Forms.Label lblSmudgesQuestion;
        private System.Windows.Forms.GroupBox grpSmudges;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblLengths;
        private System.Windows.Forms.Label lblWidth;
        internal System.Windows.Forms.CheckBox chkBacklightingOff;
        internal System.Windows.Forms.CheckBox chkAuxLightOn;
        internal System.Windows.Forms.TextBox txtMediumScratchesLengths;
        internal System.Windows.Forms.TextBox txtHeavyScratchesLengths;
        internal System.Windows.Forms.RadioButton radYesSmudges;
        internal System.Windows.Forms.RadioButton radNoSmudges;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}