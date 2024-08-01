namespace CIGALHE.MFD.Optical
{
    internal partial class UUTBrightnessForm
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
            this.lblBrightness = new System.Windows.Forms.Label();
            this.lblfL = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblBrightnessValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdateReading = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(16, 85);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(56, 13);
            this.lblBrightness.TabIndex = 0;
            this.lblBrightness.Text = "Brightness";
            // 
            // lblfL
            // 
            this.lblfL.AutoSize = true;
            this.lblfL.Location = new System.Drawing.Point(133, 85);
            this.lblfL.Name = "lblfL";
            this.lblfL.Size = new System.Drawing.Size(16, 13);
            this.lblfL.TabIndex = 0;
            this.lblfL.Text = "fL";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(175, 220);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(13, 13);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(237, 40);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "On the UUT, press the LUM+/- bezel button\r\n   until the brightness reading displa" +
    "yed below\r\n   is between xx and yy fL.";
            // 
            // lblBrightnessValue
            // 
            this.lblBrightnessValue.BackColor = System.Drawing.SystemColors.Window;
            this.lblBrightnessValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrightnessValue.Location = new System.Drawing.Point(78, 81);
            this.lblBrightnessValue.Name = "lblBrightnessValue";
            this.lblBrightnessValue.Size = new System.Drawing.Size(48, 20);
            this.lblBrightnessValue.TabIndex = 0;
            this.lblBrightnessValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdateReading);
            this.groupBox1.Controls.Add(this.lblBrightnessValue);
            this.groupBox1.Controls.Add(this.lblBrightness);
            this.groupBox1.Controls.Add(this.lblfL);
            this.groupBox1.Location = new System.Drawing.Point(31, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 122);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LCD Brightness";
            // 
            // btnUpdateReading
            // 
            this.btnUpdateReading.AutoSize = true;
            this.btnUpdateReading.Location = new System.Drawing.Point(55, 31);
            this.btnUpdateReading.Name = "btnUpdateReading";
            this.btnUpdateReading.Size = new System.Drawing.Size(101, 42);
            this.btnUpdateReading.TabIndex = 1;
            this.btnUpdateReading.Text = "Click Here to\r\nUpdate Reading";
            this.btnUpdateReading.UseVisualStyleBackColor = true;
            this.btnUpdateReading.Click += new System.EventHandler(this.btnUpdateReading_Click);
            // 
            // UUTBrightnessForm
            // 
            this.AcceptButton = this.btnUpdateReading;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 255);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UUTBrightnessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LCD Brightness";
            this.Load += new System.EventHandler(this.UUTBrightnessForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.Label lblfL;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdateReading;
        internal System.Windows.Forms.Label lblBrightnessValue;
    }
}