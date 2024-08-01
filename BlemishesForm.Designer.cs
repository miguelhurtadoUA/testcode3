namespace CIGALHE.MFD.Optical
{
    internal partial class BlemishesForm
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
            this.lblMediumScratches = new System.Windows.Forms.Label();
            this.grpScratches = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBlemishSize = new System.Windows.Forms.Label();
            this.numMediumBlemishes = new System.Windows.Forms.NumericUpDown();
            this.numLargeBlemishes = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSmudgesQuestion = new System.Windows.Forms.Label();
            this.radYesSmudgeFree = new System.Windows.Forms.RadioButton();
            this.radNoSmudgeFree = new System.Windows.Forms.RadioButton();
            this.grpSmudges = new System.Windows.Forms.GroupBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpScratches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMediumBlemishes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLargeBlemishes)).BeginInit();
            this.grpSmudges.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMediumScratches
            // 
            this.lblMediumScratches.AutoSize = true;
            this.lblMediumScratches.Location = new System.Drawing.Point(8, 95);
            this.lblMediumScratches.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMediumScratches.Name = "lblMediumScratches";
            this.lblMediumScratches.Size = new System.Drawing.Size(67, 16);
            this.lblMediumScratches.TabIndex = 0;
            this.lblMediumScratches.Text = "> 0.50 mm";
            // 
            // grpScratches
            // 
            this.grpScratches.Controls.Add(this.label4);
            this.grpScratches.Controls.Add(this.label3);
            this.grpScratches.Controls.Add(this.lblBlemishSize);
            this.grpScratches.Controls.Add(this.numMediumBlemishes);
            this.grpScratches.Controls.Add(this.numLargeBlemishes);
            this.grpScratches.Controls.Add(this.label5);
            this.grpScratches.Controls.Add(this.label2);
            this.grpScratches.Controls.Add(this.label1);
            this.grpScratches.Controls.Add(this.lblMediumScratches);
            this.grpScratches.Location = new System.Drawing.Point(20, 17);
            this.grpScratches.Name = "grpScratches";
            this.grpScratches.Size = new System.Drawing.Size(304, 184);
            this.grpScratches.TabIndex = 0;
            this.grpScratches.TabStop = false;
            this.grpScratches.Text = "Blemishes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(111, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Count";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Size";
            // 
            // lblBlemishSize
            // 
            this.lblBlemishSize.AutoSize = true;
            this.lblBlemishSize.Location = new System.Drawing.Point(8, 24);
            this.lblBlemishSize.Name = "lblBlemishSize";
            this.lblBlemishSize.Size = new System.Drawing.Size(288, 32);
            this.lblBlemishSize.TabIndex = 0;
            this.lblBlemishSize.Text = "For oblong blemishes, size = (length + width) / 2.\r\nFor circular blemishes, size " +
    "= diameter.";
            // 
            // numMediumBlemishes
            // 
            this.numMediumBlemishes.Location = new System.Drawing.Point(114, 120);
            this.numMediumBlemishes.Name = "numMediumBlemishes";
            this.numMediumBlemishes.Size = new System.Drawing.Size(60, 22);
            this.numMediumBlemishes.TabIndex = 1;
            this.toolTip1.SetToolTip(this.numMediumBlemishes, "Number of blemishes of this size");
            // 
            // numLargeBlemishes
            // 
            this.numLargeBlemishes.Location = new System.Drawing.Point(114, 92);
            this.numLargeBlemishes.Name = "numLargeBlemishes";
            this.numLargeBlemishes.Size = new System.Drawing.Size(60, 22);
            this.numLargeBlemishes.TabIndex = 0;
            this.toolTip1.SetToolTip(this.numLargeBlemishes, "Number of blemishes of this size");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 151);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "no limit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "< 0.15 mm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "0.15 to 0.50 mm";
            // 
            // lblSmudgesQuestion
            // 
            this.lblSmudgesQuestion.AutoSize = true;
            this.lblSmudgesQuestion.Location = new System.Drawing.Point(8, 24);
            this.lblSmudgesQuestion.Name = "lblSmudgesQuestion";
            this.lblSmudgesQuestion.Size = new System.Drawing.Size(312, 32);
            this.lblSmudgesQuestion.TabIndex = 0;
            this.lblSmudgesQuestion.Text = "Is the LCD free of concentrations of small blemishes\r\n(< 0.15 mm) that would appe" +
    "ar as smudges?";
            // 
            // radYesSmudgeFree
            // 
            this.radYesSmudgeFree.AutoSize = true;
            this.radYesSmudgeFree.Location = new System.Drawing.Point(205, 60);
            this.radYesSmudgeFree.Name = "radYesSmudgeFree";
            this.radYesSmudgeFree.Size = new System.Drawing.Size(50, 20);
            this.radYesSmudgeFree.TabIndex = 0;
            this.radYesSmudgeFree.TabStop = true;
            this.radYesSmudgeFree.Text = "Yes";
            this.radYesSmudgeFree.UseVisualStyleBackColor = true;
            // 
            // radNoSmudgeFree
            // 
            this.radNoSmudgeFree.AutoSize = true;
            this.radNoSmudgeFree.Location = new System.Drawing.Point(261, 60);
            this.radNoSmudgeFree.Name = "radNoSmudgeFree";
            this.radNoSmudgeFree.Size = new System.Drawing.Size(44, 20);
            this.radNoSmudgeFree.TabIndex = 1;
            this.radNoSmudgeFree.TabStop = true;
            this.radNoSmudgeFree.Text = "No";
            this.radNoSmudgeFree.UseVisualStyleBackColor = true;
            // 
            // grpSmudges
            // 
            this.grpSmudges.Controls.Add(this.lblSmudgesQuestion);
            this.grpSmudges.Controls.Add(this.radNoSmudgeFree);
            this.grpSmudges.Controls.Add(this.radYesSmudgeFree);
            this.grpSmudges.Location = new System.Drawing.Point(20, 219);
            this.grpSmudges.Name = "grpSmudges";
            this.grpSmudges.Size = new System.Drawing.Size(328, 92);
            this.grpSmudges.TabIndex = 1;
            this.grpSmudges.TabStop = false;
            this.grpSmudges.Text = "Smudges";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(273, 336);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // BlemishesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 371);
            this.ControlBox = false;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.grpSmudges);
            this.Controls.Add(this.grpScratches);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlemishesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Display Defects - Blemishes";
            this.grpScratches.ResumeLayout(false);
            this.grpScratches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMediumBlemishes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLargeBlemishes)).EndInit();
            this.grpSmudges.ResumeLayout(false);
            this.grpSmudges.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMediumScratches;
        private System.Windows.Forms.GroupBox grpScratches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSmudgesQuestion;
        private System.Windows.Forms.GroupBox grpSmudges;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBlemishSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.NumericUpDown numLargeBlemishes;
        internal System.Windows.Forms.NumericUpDown numMediumBlemishes;
        internal System.Windows.Forms.RadioButton radYesSmudgeFree;
        internal System.Windows.Forms.RadioButton radNoSmudgeFree;
        private System.Windows.Forms.Label label5;
    }
}