
namespace XYPositionSystem
{
    partial class CalibrateACRO55
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
            this.grpJog = new System.Windows.Forms.GroupBox();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblYPos = new System.Windows.Forms.Label();
            this.lblXPos = new System.Windows.Forms.Label();
            this.grpJogIncrement = new System.Windows.Forms.GroupBox();
            this.rdoJogHundredth = new System.Windows.Forms.RadioButton();
            this.rdoJogTenth = new System.Windows.Forms.RadioButton();
            this.rdoJogInch = new System.Windows.Forms.RadioButton();
            this.grpSavePosition = new System.Windows.Forms.GroupBox();
            this.btnSavePositionTopRight = new System.Windows.Forms.Button();
            this.btnSavePositionBottomRight = new System.Windows.Forms.Button();
            this.btnSavePositionBottomLeft = new System.Windows.Forms.Button();
            this.btnSavePositionTopLeft = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpInitializePosition = new System.Windows.Forms.GroupBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.grpJog.SuspendLayout();
            this.grpJogIncrement.SuspendLayout();
            this.grpSavePosition.SuspendLayout();
            this.grpInitializePosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpJog
            // 
            this.grpJog.Controls.Add(this.lblY);
            this.grpJog.Controls.Add(this.lblX);
            this.grpJog.Controls.Add(this.btnLeft);
            this.grpJog.Controls.Add(this.btnRight);
            this.grpJog.Controls.Add(this.btnDown);
            this.grpJog.Controls.Add(this.btnUp);
            this.grpJog.Controls.Add(this.lblYPos);
            this.grpJog.Controls.Add(this.lblXPos);
            this.grpJog.Location = new System.Drawing.Point(13, 17);
            this.grpJog.Name = "grpJog";
            this.grpJog.Size = new System.Drawing.Size(169, 178);
            this.grpJog.TabIndex = 0;
            this.grpJog.TabStop = false;
            this.grpJog.Text = "Jog";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(90, 128);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 13);
            this.lblY.TabIndex = 4;
            this.lblY.Text = "Y";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(41, 128);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.TabIndex = 4;
            this.lblX.Text = "X";
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(17, 42);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(45, 45);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.TabStop = false;
            this.btnLeft.Text = "X-";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnXMinus_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(107, 42);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(45, 45);
            this.btnRight.TabIndex = 3;
            this.btnRight.TabStop = false;
            this.btnRight.Text = "X+";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnXPlus_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(62, 65);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(45, 45);
            this.btnDown.TabIndex = 1;
            this.btnDown.TabStop = false;
            this.btnDown.Text = "Y-";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnYMinus_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(62, 20);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(45, 45);
            this.btnUp.TabIndex = 0;
            this.btnUp.TabStop = false;
            this.btnUp.Text = "Y+";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnYPlus_Click);
            // 
            // lblYPos
            // 
            this.lblYPos.BackColor = System.Drawing.SystemColors.Window;
            this.lblYPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYPos.Location = new System.Drawing.Point(90, 144);
            this.lblYPos.Name = "lblYPos";
            this.lblYPos.Size = new System.Drawing.Size(38, 23);
            this.lblYPos.TabIndex = 0;
            this.lblYPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblXPos
            // 
            this.lblXPos.BackColor = System.Drawing.SystemColors.Window;
            this.lblXPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblXPos.Location = new System.Drawing.Point(41, 144);
            this.lblXPos.Name = "lblXPos";
            this.lblXPos.Size = new System.Drawing.Size(38, 23);
            this.lblXPos.TabIndex = 0;
            this.lblXPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpJogIncrement
            // 
            this.grpJogIncrement.Controls.Add(this.rdoJogHundredth);
            this.grpJogIncrement.Controls.Add(this.rdoJogTenth);
            this.grpJogIncrement.Controls.Add(this.rdoJogInch);
            this.grpJogIncrement.Location = new System.Drawing.Point(13, 204);
            this.grpJogIncrement.Name = "grpJogIncrement";
            this.grpJogIncrement.Size = new System.Drawing.Size(169, 51);
            this.grpJogIncrement.TabIndex = 1;
            this.grpJogIncrement.TabStop = false;
            this.grpJogIncrement.Text = "Jog &Increment";
            // 
            // rdoJogHundredth
            // 
            this.rdoJogHundredth.AutoSize = true;
            this.rdoJogHundredth.Location = new System.Drawing.Point(111, 20);
            this.rdoJogHundredth.Name = "rdoJogHundredth";
            this.rdoJogHundredth.Size = new System.Drawing.Size(51, 17);
            this.rdoJogHundredth.TabIndex = 2;
            this.rdoJogHundredth.Text = "0.01\"";
            this.rdoJogHundredth.UseVisualStyleBackColor = true;
            this.rdoJogHundredth.CheckedChanged += new System.EventHandler(this.rdoJogHundredth_CheckedChanged);
            // 
            // rdoJogTenth
            // 
            this.rdoJogTenth.AutoSize = true;
            this.rdoJogTenth.Checked = true;
            this.rdoJogTenth.Location = new System.Drawing.Point(54, 20);
            this.rdoJogTenth.Name = "rdoJogTenth";
            this.rdoJogTenth.Size = new System.Drawing.Size(45, 17);
            this.rdoJogTenth.TabIndex = 1;
            this.rdoJogTenth.TabStop = true;
            this.rdoJogTenth.Text = "0.1\"";
            this.rdoJogTenth.UseVisualStyleBackColor = true;
            this.rdoJogTenth.CheckedChanged += new System.EventHandler(this.rdoJogTenth_CheckedChanged);
            // 
            // rdoJogInch
            // 
            this.rdoJogInch.AutoSize = true;
            this.rdoJogInch.Location = new System.Drawing.Point(6, 20);
            this.rdoJogInch.Name = "rdoJogInch";
            this.rdoJogInch.Size = new System.Drawing.Size(36, 17);
            this.rdoJogInch.TabIndex = 0;
            this.rdoJogInch.Text = "1\"";
            this.rdoJogInch.UseVisualStyleBackColor = true;
            this.rdoJogInch.CheckedChanged += new System.EventHandler(this.rdoJogInch_CheckedChanged);
            // 
            // grpSavePosition
            // 
            this.grpSavePosition.Controls.Add(this.btnSavePositionTopRight);
            this.grpSavePosition.Controls.Add(this.btnSavePositionBottomRight);
            this.grpSavePosition.Controls.Add(this.btnSavePositionBottomLeft);
            this.grpSavePosition.Controls.Add(this.btnSavePositionTopLeft);
            this.grpSavePosition.Location = new System.Drawing.Point(189, 88);
            this.grpSavePosition.Name = "grpSavePosition";
            this.grpSavePosition.Size = new System.Drawing.Size(184, 107);
            this.grpSavePosition.TabIndex = 2;
            this.grpSavePosition.TabStop = false;
            this.grpSavePosition.Text = "Save Position";
            // 
            // btnSavePositionTopRight
            // 
            this.btnSavePositionTopRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSavePositionTopRight.Location = new System.Drawing.Point(98, 20);
            this.btnSavePositionTopRight.Name = "btnSavePositionTopRight";
            this.btnSavePositionTopRight.Size = new System.Drawing.Size(78, 23);
            this.btnSavePositionTopRight.TabIndex = 0;
            this.btnSavePositionTopRight.Text = "Top Right";
            this.btnSavePositionTopRight.UseVisualStyleBackColor = true;
            this.btnSavePositionTopRight.Click += new System.EventHandler(this.btnSavePositionTopRight_Click);
            // 
            // btnSavePositionBottomRight
            // 
            this.btnSavePositionBottomRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSavePositionBottomRight.Location = new System.Drawing.Point(98, 71);
            this.btnSavePositionBottomRight.Name = "btnSavePositionBottomRight";
            this.btnSavePositionBottomRight.Size = new System.Drawing.Size(78, 23);
            this.btnSavePositionBottomRight.TabIndex = 0;
            this.btnSavePositionBottomRight.Text = "Bottom Right";
            this.btnSavePositionBottomRight.UseVisualStyleBackColor = true;
            this.btnSavePositionBottomRight.Click += new System.EventHandler(this.btnSavePositionBottomRight_Click);
            // 
            // btnSavePositionBottomLeft
            // 
            this.btnSavePositionBottomLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSavePositionBottomLeft.Location = new System.Drawing.Point(7, 70);
            this.btnSavePositionBottomLeft.Name = "btnSavePositionBottomLeft";
            this.btnSavePositionBottomLeft.Size = new System.Drawing.Size(78, 23);
            this.btnSavePositionBottomLeft.TabIndex = 0;
            this.btnSavePositionBottomLeft.Text = "Bottom Left";
            this.btnSavePositionBottomLeft.UseVisualStyleBackColor = true;
            this.btnSavePositionBottomLeft.Click += new System.EventHandler(this.btnSavePositionBottomLeft_Click);
            // 
            // btnSavePositionTopLeft
            // 
            this.btnSavePositionTopLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSavePositionTopLeft.Location = new System.Drawing.Point(7, 20);
            this.btnSavePositionTopLeft.Name = "btnSavePositionTopLeft";
            this.btnSavePositionTopLeft.Size = new System.Drawing.Size(78, 23);
            this.btnSavePositionTopLeft.TabIndex = 0;
            this.btnSavePositionTopLeft.Text = "Top Left";
            this.btnSavePositionTopLeft.UseVisualStyleBackColor = true;
            this.btnSavePositionTopLeft.Click += new System.EventHandler(this.btnSavePositionTopLeft_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(289, 224);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grpInitializePosition
            // 
            this.grpInitializePosition.Controls.Add(this.btnHome);
            this.grpInitializePosition.Location = new System.Drawing.Point(189, 17);
            this.grpInitializePosition.Name = "grpInitializePosition";
            this.grpInitializePosition.Size = new System.Drawing.Size(183, 65);
            this.grpInitializePosition.TabIndex = 4;
            this.grpInitializePosition.TabStop = false;
            this.grpInitializePosition.Text = "Initialize Position";
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(54, 25);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // CalibrateACRO55
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(384, 263);
            this.Controls.Add(this.grpInitializePosition);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpSavePosition);
            this.Controls.Add(this.grpJogIncrement);
            this.Controls.Add(this.grpJog);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalibrateACRO55";
            this.Text = "Chroma Meter Position";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.grpJog.ResumeLayout(false);
            this.grpJog.PerformLayout();
            this.grpJogIncrement.ResumeLayout(false);
            this.grpJogIncrement.PerformLayout();
            this.grpSavePosition.ResumeLayout(false);
            this.grpInitializePosition.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpJog;
        private System.Windows.Forms.Label lblYPos;
        private System.Windows.Forms.Label lblXPos;
        private System.Windows.Forms.GroupBox grpJogIncrement;
        private System.Windows.Forms.RadioButton rdoJogHundredth;
        private System.Windows.Forms.RadioButton rdoJogTenth;
        private System.Windows.Forms.RadioButton rdoJogInch;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.GroupBox grpSavePosition;
        private System.Windows.Forms.Button btnSavePositionTopRight;
        private System.Windows.Forms.Button btnSavePositionBottomRight;
        private System.Windows.Forms.Button btnSavePositionBottomLeft;
        private System.Windows.Forms.Button btnSavePositionTopLeft;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grpInitializePosition;
        private System.Windows.Forms.Button btnHome;
    }
}

