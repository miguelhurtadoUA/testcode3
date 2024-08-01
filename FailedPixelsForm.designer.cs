namespace CIGALHE.MFD.Optical
{
    internal partial class FailedPixelsForm
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
            this.grpSinglePixels = new System.Windows.Forms.GroupBox();
            this.radNoSinglesNearOthers = new System.Windows.Forms.RadioButton();
            this.radYesSinglesNearOthers = new System.Windows.Forms.RadioButton();
            this.numStuckON = new System.Windows.Forms.NumericUpDown();
            this.numStuckOFF = new System.Windows.Forms.NumericUpDown();
            this.lblPixelProximity = new System.Windows.Forms.Label();
            this.lblStuckOn = new System.Windows.Forms.Label();
            this.lblStuckOff = new System.Windows.Forms.Label();
            this.grpPixelClusters = new System.Windows.Forms.GroupBox();
            this.radNoClustersNearOthers = new System.Windows.Forms.RadioButton();
            this.num3To5PixelFailures = new System.Windows.Forms.NumericUpDown();
            this.radYesClustersNearOthers = new System.Windows.Forms.RadioButton();
            this.num2PixelFailures = new System.Windows.Forms.NumericUpDown();
            this.lbl3To5PixelFailures = new System.Windows.Forms.Label();
            this.lblTwoPixelFailures = new System.Windows.Forms.Label();
            this.lblClusterProximity = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.grpSinglePixels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStuckON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStuckOFF)).BeginInit();
            this.grpPixelClusters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num3To5PixelFailures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2PixelFailures)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSinglePixels
            // 
            this.grpSinglePixels.Controls.Add(this.radNoSinglesNearOthers);
            this.grpSinglePixels.Controls.Add(this.radYesSinglesNearOthers);
            this.grpSinglePixels.Controls.Add(this.numStuckON);
            this.grpSinglePixels.Controls.Add(this.numStuckOFF);
            this.grpSinglePixels.Controls.Add(this.lblPixelProximity);
            this.grpSinglePixels.Controls.Add(this.lblStuckOn);
            this.grpSinglePixels.Controls.Add(this.lblStuckOff);
            this.grpSinglePixels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSinglePixels.Location = new System.Drawing.Point(20, 17);
            this.grpSinglePixels.Margin = new System.Windows.Forms.Padding(4);
            this.grpSinglePixels.Name = "grpSinglePixels";
            this.grpSinglePixels.Padding = new System.Windows.Forms.Padding(4);
            this.grpSinglePixels.Size = new System.Drawing.Size(376, 152);
            this.grpSinglePixels.TabIndex = 0;
            this.grpSinglePixels.TabStop = false;
            this.grpSinglePixels.Text = "Single Pixels";
            // 
            // radNoSinglesNearOthers
            // 
            this.radNoSinglesNearOthers.AutoSize = true;
            this.radNoSinglesNearOthers.Location = new System.Drawing.Point(227, 123);
            this.radNoSinglesNearOthers.Margin = new System.Windows.Forms.Padding(4);
            this.radNoSinglesNearOthers.Name = "radNoSinglesNearOthers";
            this.radNoSinglesNearOthers.Size = new System.Drawing.Size(44, 20);
            this.radNoSinglesNearOthers.TabIndex = 3;
            this.radNoSinglesNearOthers.TabStop = true;
            this.radNoSinglesNearOthers.Text = "No";
            this.radNoSinglesNearOthers.UseVisualStyleBackColor = true;
            // 
            // radYesSinglesNearOthers
            // 
            this.radYesSinglesNearOthers.AutoSize = true;
            this.radYesSinglesNearOthers.Location = new System.Drawing.Point(169, 123);
            this.radYesSinglesNearOthers.Margin = new System.Windows.Forms.Padding(4);
            this.radYesSinglesNearOthers.Name = "radYesSinglesNearOthers";
            this.radYesSinglesNearOthers.Size = new System.Drawing.Size(50, 20);
            this.radYesSinglesNearOthers.TabIndex = 2;
            this.radYesSinglesNearOthers.TabStop = true;
            this.radYesSinglesNearOthers.Text = "Yes";
            this.radYesSinglesNearOthers.UseVisualStyleBackColor = true;
            // 
            // numStuckON
            // 
            this.numStuckON.Location = new System.Drawing.Point(226, 62);
            this.numStuckON.Margin = new System.Windows.Forms.Padding(4);
            this.numStuckON.Name = "numStuckON";
            this.numStuckON.Size = new System.Drawing.Size(60, 22);
            this.numStuckON.TabIndex = 1;
            // 
            // numStuckOFF
            // 
            this.numStuckOFF.Location = new System.Drawing.Point(226, 30);
            this.numStuckOFF.Margin = new System.Windows.Forms.Padding(4);
            this.numStuckOFF.Name = "numStuckOFF";
            this.numStuckOFF.Size = new System.Drawing.Size(60, 22);
            this.numStuckOFF.TabIndex = 0;
            // 
            // lblPixelProximity
            // 
            this.lblPixelProximity.AutoSize = true;
            this.lblPixelProximity.Location = new System.Drawing.Point(8, 103);
            this.lblPixelProximity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPixelProximity.Name = "lblPixelProximity";
            this.lblPixelProximity.Size = new System.Drawing.Size(354, 16);
            this.lblPixelProximity.TabIndex = 2;
            this.lblPixelProximity.Text = "Are there any stuck, single pixels within 1 cm of each other?";
            // 
            // lblStuckOn
            // 
            this.lblStuckOn.AutoSize = true;
            this.lblStuckOn.Location = new System.Drawing.Point(8, 65);
            this.lblStuckOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStuckOn.Name = "lblStuckOn";
            this.lblStuckOn.Size = new System.Drawing.Size(204, 16);
            this.lblStuckOn.TabIndex = 1;
            this.lblStuckOn.Text = "Number of single pixels stuck ON";
            // 
            // lblStuckOff
            // 
            this.lblStuckOff.AutoSize = true;
            this.lblStuckOff.Location = new System.Drawing.Point(8, 33);
            this.lblStuckOff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStuckOff.Name = "lblStuckOff";
            this.lblStuckOff.Size = new System.Drawing.Size(210, 16);
            this.lblStuckOff.TabIndex = 0;
            this.lblStuckOff.Text = "Number of single pixels stuck OFF";
            // 
            // grpPixelClusters
            // 
            this.grpPixelClusters.Controls.Add(this.radNoClustersNearOthers);
            this.grpPixelClusters.Controls.Add(this.num3To5PixelFailures);
            this.grpPixelClusters.Controls.Add(this.radYesClustersNearOthers);
            this.grpPixelClusters.Controls.Add(this.num2PixelFailures);
            this.grpPixelClusters.Controls.Add(this.lbl3To5PixelFailures);
            this.grpPixelClusters.Controls.Add(this.lblTwoPixelFailures);
            this.grpPixelClusters.Controls.Add(this.lblClusterProximity);
            this.grpPixelClusters.Location = new System.Drawing.Point(20, 187);
            this.grpPixelClusters.Margin = new System.Windows.Forms.Padding(4);
            this.grpPixelClusters.Name = "grpPixelClusters";
            this.grpPixelClusters.Padding = new System.Windows.Forms.Padding(4);
            this.grpPixelClusters.Size = new System.Drawing.Size(376, 152);
            this.grpPixelClusters.TabIndex = 1;
            this.grpPixelClusters.TabStop = false;
            this.grpPixelClusters.Text = "Clusters of Adjacent Pixels";
            // 
            // radNoClustersNearOthers
            // 
            this.radNoClustersNearOthers.AutoSize = true;
            this.radNoClustersNearOthers.Location = new System.Drawing.Point(227, 123);
            this.radNoClustersNearOthers.Margin = new System.Windows.Forms.Padding(4);
            this.radNoClustersNearOthers.Name = "radNoClustersNearOthers";
            this.radNoClustersNearOthers.Size = new System.Drawing.Size(44, 20);
            this.radNoClustersNearOthers.TabIndex = 3;
            this.radNoClustersNearOthers.TabStop = true;
            this.radNoClustersNearOthers.Text = "No";
            this.radNoClustersNearOthers.UseVisualStyleBackColor = true;
            // 
            // num3To5PixelFailures
            // 
            this.num3To5PixelFailures.Location = new System.Drawing.Point(226, 62);
            this.num3To5PixelFailures.Margin = new System.Windows.Forms.Padding(4);
            this.num3To5PixelFailures.Name = "num3To5PixelFailures";
            this.num3To5PixelFailures.Size = new System.Drawing.Size(60, 22);
            this.num3To5PixelFailures.TabIndex = 1;
            // 
            // radYesClustersNearOthers
            // 
            this.radYesClustersNearOthers.AutoSize = true;
            this.radYesClustersNearOthers.Location = new System.Drawing.Point(169, 123);
            this.radYesClustersNearOthers.Margin = new System.Windows.Forms.Padding(4);
            this.radYesClustersNearOthers.Name = "radYesClustersNearOthers";
            this.radYesClustersNearOthers.Size = new System.Drawing.Size(50, 20);
            this.radYesClustersNearOthers.TabIndex = 2;
            this.radYesClustersNearOthers.TabStop = true;
            this.radYesClustersNearOthers.Text = "Yes";
            this.radYesClustersNearOthers.UseVisualStyleBackColor = true;
            // 
            // num2PixelFailures
            // 
            this.num2PixelFailures.Location = new System.Drawing.Point(226, 30);
            this.num2PixelFailures.Margin = new System.Windows.Forms.Padding(4);
            this.num2PixelFailures.Name = "num2PixelFailures";
            this.num2PixelFailures.Size = new System.Drawing.Size(60, 22);
            this.num2PixelFailures.TabIndex = 0;
            // 
            // lbl3To5PixelFailures
            // 
            this.lbl3To5PixelFailures.AutoSize = true;
            this.lbl3To5PixelFailures.Location = new System.Drawing.Point(8, 65);
            this.lbl3To5PixelFailures.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl3To5PixelFailures.Name = "lbl3To5PixelFailures";
            this.lbl3To5PixelFailures.Size = new System.Drawing.Size(211, 16);
            this.lbl3To5PixelFailures.TabIndex = 1;
            this.lbl3To5PixelFailures.Text = "Number of failed, 3-5-pixel clusters";
            // 
            // lblTwoPixelFailures
            // 
            this.lblTwoPixelFailures.AutoSize = true;
            this.lblTwoPixelFailures.Location = new System.Drawing.Point(8, 33);
            this.lblTwoPixelFailures.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTwoPixelFailures.Name = "lblTwoPixelFailures";
            this.lblTwoPixelFailures.Size = new System.Drawing.Size(200, 16);
            this.lblTwoPixelFailures.TabIndex = 0;
            this.lblTwoPixelFailures.Text = "Number of failed, 2-pixel clusters";
            // 
            // lblClusterProximity
            // 
            this.lblClusterProximity.AutoSize = true;
            this.lblClusterProximity.Location = new System.Drawing.Point(8, 103);
            this.lblClusterProximity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClusterProximity.Name = "lblClusterProximity";
            this.lblClusterProximity.Size = new System.Drawing.Size(325, 16);
            this.lblClusterProximity.TabIndex = 2;
            this.lblClusterProximity.Text = "Are there any failed clusters within 3 cm of each other?";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(330, 357);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FailedPixelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 392);
            this.ControlBox = false;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.grpPixelClusters);
            this.Controls.Add(this.grpSinglePixels);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FailedPixelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Display Defects - Failed Pixels";
            this.grpSinglePixels.ResumeLayout(false);
            this.grpSinglePixels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStuckON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStuckOFF)).EndInit();
            this.grpPixelClusters.ResumeLayout(false);
            this.grpPixelClusters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num3To5PixelFailures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2PixelFailures)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSinglePixels;
        private System.Windows.Forms.Label lblStuckOn;
        private System.Windows.Forms.Label lblStuckOff;
        private System.Windows.Forms.GroupBox grpPixelClusters;
        private System.Windows.Forms.Label lbl3To5PixelFailures;
        private System.Windows.Forms.Label lblTwoPixelFailures;
        private System.Windows.Forms.Label lblPixelProximity;
        private System.Windows.Forms.Label lblClusterProximity;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.NumericUpDown numStuckON;
        internal System.Windows.Forms.NumericUpDown numStuckOFF;
        internal System.Windows.Forms.NumericUpDown num3To5PixelFailures;
        internal System.Windows.Forms.NumericUpDown num2PixelFailures;
        internal System.Windows.Forms.RadioButton radNoSinglesNearOthers;
        internal System.Windows.Forms.RadioButton radYesSinglesNearOthers;
        internal System.Windows.Forms.RadioButton radNoClustersNearOthers;
        internal System.Windows.Forms.RadioButton radYesClustersNearOthers;
    }
}

