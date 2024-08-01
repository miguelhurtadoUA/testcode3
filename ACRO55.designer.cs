namespace XYPositionSystem
{
    partial class ACRO55
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtTxData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnYplus = new System.Windows.Forms.Button();
            this.btnYminus = new System.Windows.Forms.Button();
            this.btnXplus = new System.Windows.Forms.Button();
            this.btnXminus = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIncrement = new System.Windows.Forms.Label();
            this.cboJogSize = new System.Windows.Forms.ComboBox();
            this.btnConnectDisconnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnClearAlarm = new System.Windows.Forms.Button();
            this.txtXPosition = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYPosition = new System.Windows.Forms.TextBox();
            this.lstRxData = new System.Windows.Forms.ListBox();
            this.btnQueryPosition = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnClearRxData = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.btnMiddleCenter = new System.Windows.Forms.Button();
            this.btnBottomRight = new System.Windows.Forms.Button();
            this.btnBottomLeft = new System.Windows.Forms.Button();
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(289, 94);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtTxData
            // 
            this.txtTxData.Location = new System.Drawing.Point(26, 96);
            this.txtTxData.Name = "txtTxData";
            this.txtTxData.Size = new System.Drawing.Size(243, 20);
            this.txtTxData.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transmit Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Received Data";
            // 
            // btnYplus
            // 
            this.btnYplus.Location = new System.Drawing.Point(57, 26);
            this.btnYplus.Name = "btnYplus";
            this.btnYplus.Size = new System.Drawing.Size(31, 23);
            this.btnYplus.TabIndex = 2;
            this.btnYplus.Text = "Y+";
            this.btnYplus.UseVisualStyleBackColor = true;
            this.btnYplus.Click += new System.EventHandler(this.btnYplus_Click);
            // 
            // btnYminus
            // 
            this.btnYminus.Location = new System.Drawing.Point(57, 72);
            this.btnYminus.Name = "btnYminus";
            this.btnYminus.Size = new System.Drawing.Size(31, 23);
            this.btnYminus.TabIndex = 3;
            this.btnYminus.Text = "Y-";
            this.btnYminus.UseVisualStyleBackColor = true;
            this.btnYminus.Click += new System.EventHandler(this.btnYminus_Click);
            // 
            // btnXplus
            // 
            this.btnXplus.Location = new System.Drawing.Point(88, 49);
            this.btnXplus.Name = "btnXplus";
            this.btnXplus.Size = new System.Drawing.Size(31, 23);
            this.btnXplus.TabIndex = 1;
            this.btnXplus.Text = "X+";
            this.btnXplus.UseVisualStyleBackColor = true;
            this.btnXplus.Click += new System.EventHandler(this.btnXplus_Click);
            // 
            // btnXminus
            // 
            this.btnXminus.Location = new System.Drawing.Point(26, 49);
            this.btnXminus.Name = "btnXminus";
            this.btnXminus.Size = new System.Drawing.Size(31, 23);
            this.btnXminus.TabIndex = 0;
            this.btnXminus.Text = "X-";
            this.btnXminus.UseVisualStyleBackColor = true;
            this.btnXminus.Click += new System.EventHandler(this.btnXminus_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIncrement);
            this.groupBox1.Controls.Add(this.cboJogSize);
            this.groupBox1.Controls.Add(this.btnYminus);
            this.groupBox1.Controls.Add(this.btnXminus);
            this.groupBox1.Controls.Add(this.btnYplus);
            this.groupBox1.Controls.Add(this.btnXplus);
            this.groupBox1.Location = new System.Drawing.Point(23, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 162);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jog";
            // 
            // lblIncrement
            // 
            this.lblIncrement.AutoSize = true;
            this.lblIncrement.Location = new System.Drawing.Point(13, 125);
            this.lblIncrement.Name = "lblIncrement";
            this.lblIncrement.Size = new System.Drawing.Size(57, 13);
            this.lblIncrement.TabIndex = 4;
            this.lblIncrement.Text = "Increment:";
            // 
            // cboJogSize
            // 
            this.cboJogSize.FormattingEnabled = true;
            this.cboJogSize.Items.AddRange(new object[] {
            "1\"",
            "0.1\"",
            "0.01\""});
            this.cboJogSize.Location = new System.Drawing.Point(76, 121);
            this.cboJogSize.Name = "cboJogSize";
            this.cboJogSize.Size = new System.Drawing.Size(54, 21);
            this.cboJogSize.TabIndex = 4;
            this.cboJogSize.SelectedIndexChanged += new System.EventHandler(this.cboJogSize_SelectedIndexChanged);
            // 
            // btnConnectDisconnect
            // 
            this.btnConnectDisconnect.Location = new System.Drawing.Point(26, 29);
            this.btnConnectDisconnect.Name = "btnConnectDisconnect";
            this.btnConnectDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnectDisconnect.TabIndex = 0;
            this.btnConnectDisconnect.Text = "Connect";
            this.btnConnectDisconnect.UseVisualStyleBackColor = true;
            this.btnConnectDisconnect.Click += new System.EventHandler(this.btnConnectDisconnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "USB Port";
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(256, 363);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 10;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnClearAlarm
            // 
            this.btnClearAlarm.Location = new System.Drawing.Point(256, 392);
            this.btnClearAlarm.Name = "btnClearAlarm";
            this.btnClearAlarm.Size = new System.Drawing.Size(75, 23);
            this.btnClearAlarm.TabIndex = 11;
            this.btnClearAlarm.Text = "Clear Alarm";
            this.btnClearAlarm.UseVisualStyleBackColor = true;
            this.btnClearAlarm.Click += new System.EventHandler(this.btnClearAlarm_Click);
            // 
            // txtXPosition
            // 
            this.txtXPosition.Location = new System.Drawing.Point(232, 308);
            this.txtXPosition.Name = "txtXPosition";
            this.txtXPosition.Size = new System.Drawing.Size(51, 20);
            this.txtXPosition.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "X-Pos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Y-Pos";
            // 
            // txtYPosition
            // 
            this.txtYPosition.Location = new System.Drawing.Point(299, 308);
            this.txtYPosition.Name = "txtYPosition";
            this.txtYPosition.Size = new System.Drawing.Size(51, 20);
            this.txtYPosition.TabIndex = 8;
            // 
            // lstRxData
            // 
            this.lstRxData.FormattingEnabled = true;
            this.lstRxData.Location = new System.Drawing.Point(26, 156);
            this.lstRxData.Name = "lstRxData";
            this.lstRxData.Size = new System.Drawing.Size(338, 82);
            this.lstRxData.TabIndex = 3;
            // 
            // btnQueryPosition
            // 
            this.btnQueryPosition.Location = new System.Drawing.Point(246, 334);
            this.btnQueryPosition.Name = "btnQueryPosition";
            this.btnQueryPosition.Size = new System.Drawing.Size(94, 23);
            this.btnQueryPosition.TabIndex = 9;
            this.btnQueryPosition.Text = "Query Position";
            this.btnQueryPosition.UseVisualStyleBackColor = true;
            this.btnQueryPosition.Click += new System.EventHandler(this.btnQueryPosition_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.Location = new System.Drawing.Point(241, 421);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(105, 33);
            this.btnAbort.TabIndex = 12;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnClearRxData
            // 
            this.btnClearRxData.Location = new System.Drawing.Point(26, 245);
            this.btnClearRxData.Name = "btnClearRxData";
            this.btnClearRxData.Size = new System.Drawing.Size(75, 23);
            this.btnClearRxData.TabIndex = 4;
            this.btnClearRxData.Text = "Clear";
            this.btnClearRxData.UseVisualStyleBackColor = true;
            this.btnClearRxData.Click += new System.EventHandler(this.btnClearRxData_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTopRight);
            this.groupBox2.Controls.Add(this.btnMiddleCenter);
            this.groupBox2.Controls.Add(this.btnBottomRight);
            this.groupBox2.Controls.Add(this.btnBottomLeft);
            this.groupBox2.Controls.Add(this.btnTopLeft);
            this.groupBox2.Location = new System.Drawing.Point(26, 473);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 175);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MFD Positions";
            // 
            // btnTopRight
            // 
            this.btnTopRight.Location = new System.Drawing.Point(110, 20);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(30, 23);
            this.btnTopRight.TabIndex = 1;
            this.btnTopRight.Text = "TR";
            this.btnTopRight.UseVisualStyleBackColor = true;
            this.btnTopRight.Click += new System.EventHandler(this.btnTopRight_Click);
            // 
            // btnMiddleCenter
            // 
            this.btnMiddleCenter.Location = new System.Drawing.Point(58, 83);
            this.btnMiddleCenter.Name = "btnMiddleCenter";
            this.btnMiddleCenter.Size = new System.Drawing.Size(31, 23);
            this.btnMiddleCenter.TabIndex = 2;
            this.btnMiddleCenter.Text = "MC";
            this.btnMiddleCenter.UseVisualStyleBackColor = true;
            this.btnMiddleCenter.Click += new System.EventHandler(this.btnMiddleCenter_Click);
            // 
            // btnBottomRight
            // 
            this.btnBottomRight.Location = new System.Drawing.Point(111, 146);
            this.btnBottomRight.Name = "btnBottomRight";
            this.btnBottomRight.Size = new System.Drawing.Size(30, 23);
            this.btnBottomRight.TabIndex = 4;
            this.btnBottomRight.Text = "BR";
            this.btnBottomRight.UseVisualStyleBackColor = true;
            this.btnBottomRight.Click += new System.EventHandler(this.btnBottomRight_Click);
            // 
            // btnBottomLeft
            // 
            this.btnBottomLeft.Location = new System.Drawing.Point(7, 146);
            this.btnBottomLeft.Name = "btnBottomLeft";
            this.btnBottomLeft.Size = new System.Drawing.Size(30, 23);
            this.btnBottomLeft.TabIndex = 3;
            this.btnBottomLeft.Text = "BL";
            this.btnBottomLeft.UseVisualStyleBackColor = true;
            this.btnBottomLeft.Click += new System.EventHandler(this.btnBottomLeft_Click);
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.Location = new System.Drawing.Point(7, 20);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(30, 23);
            this.btnTopLeft.TabIndex = 0;
            this.btnTopLeft.Text = "TL";
            this.btnTopLeft.UseVisualStyleBackColor = true;
            this.btnTopLeft.Click += new System.EventHandler(this.btnTopLeft_Click);
            // 
            // ACRO55
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 662);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClearRxData);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnQueryPosition);
            this.Controls.Add(this.lstRxData);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtYPosition);
            this.Controls.Add(this.txtXPosition);
            this.Controls.Add(this.btnClearAlarm);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConnectDisconnect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTxData);
            this.Controls.Add(this.btnSend);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ACRO55";
            this.Text = "X-Y Positioning System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ACRO55_FormClosed);
            this.Load += new System.EventHandler(this.ACRO55_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtTxData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnYplus;
        private System.Windows.Forms.Button btnYminus;
        private System.Windows.Forms.Button btnXplus;
        private System.Windows.Forms.Button btnXminus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnectDisconnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnClearAlarm;
        private System.Windows.Forms.TextBox txtXPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYPosition;
        private System.Windows.Forms.ListBox lstRxData;
        private System.Windows.Forms.Button btnQueryPosition;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnClearRxData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTopRight;
        private System.Windows.Forms.Button btnMiddleCenter;
        private System.Windows.Forms.Button btnBottomRight;
        private System.Windows.Forms.Button btnBottomLeft;
        private System.Windows.Forms.Button btnTopLeft;
        private System.Windows.Forms.Label lblIncrement;
        private System.Windows.Forms.ComboBox cboJogSize;
    }
}

