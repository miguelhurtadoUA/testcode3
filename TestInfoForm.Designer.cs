namespace CIGALHE.MFD.Optical
{
    public partial class TestInfoForm
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
            this.grpOperator = new System.Windows.Forms.GroupBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpUUTInfo = new System.Windows.Forms.GroupBox();
            this.cmboPartNo = new System.Windows.Forms.ComboBox();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.grpComments = new System.Windows.Forms.GroupBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpOperator.SuspendLayout();
            this.grpUUTInfo.SuspendLayout();
            this.grpComments.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOperator
            // 
            this.grpOperator.Controls.Add(this.txtUserName);
            this.grpOperator.Controls.Add(this.label1);
            this.grpOperator.Location = new System.Drawing.Point(13, 13);
            this.grpOperator.Name = "grpOperator";
            this.grpOperator.Size = new System.Drawing.Size(214, 55);
            this.grpOperator.TabIndex = 0;
            this.grpOperator.TabStop = false;
            this.grpOperator.Text = "Operator";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(48, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(156, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // grpUUTInfo
            // 
            this.grpUUTInfo.Controls.Add(this.cmboPartNo);
            this.grpUUTInfo.Controls.Add(this.txtSerialNo);
            this.grpUUTInfo.Controls.Add(this.label3);
            this.grpUUTInfo.Controls.Add(this.label2);
            this.grpUUTInfo.Location = new System.Drawing.Point(13, 89);
            this.grpUUTInfo.Name = "grpUUTInfo";
            this.grpUUTInfo.Size = new System.Drawing.Size(186, 82);
            this.grpUUTInfo.TabIndex = 1;
            this.grpUUTInfo.TabStop = false;
            this.grpUUTInfo.Text = "Unit Under Test";
            // 
            // cmboPartNo
            // 
            this.cmboPartNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboPartNo.FormattingEnabled = true;
            this.cmboPartNo.Location = new System.Drawing.Point(59, 22);
            this.cmboPartNo.Name = "cmboPartNo";
            this.cmboPartNo.Size = new System.Drawing.Size(117, 21);
            this.cmboPartNo.TabIndex = 1;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(59, 48);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(117, 20);
            this.txtSerialNo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Serial No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Part No.";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(192, 262);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // grpComments
            // 
            this.grpComments.Controls.Add(this.txtComments);
            this.grpComments.Location = new System.Drawing.Point(13, 192);
            this.grpComments.Name = "grpComments";
            this.grpComments.Size = new System.Drawing.Size(254, 48);
            this.grpComments.TabIndex = 2;
            this.grpComments.TabStop = false;
            this.grpComments.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(10, 19);
            this.txtComments.MaxLength = 38;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(234, 20);
            this.txtComments.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtComments, "Maximum 38 characters");
            // 
            // TestInfoForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 297);
            this.Controls.Add(this.grpComments);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.grpUUTInfo);
            this.Controls.Add(this.grpOperator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Information";
            this.Load += new System.EventHandler(this.TestInfoForm_Load);
            this.grpOperator.ResumeLayout(false);
            this.grpOperator.PerformLayout();
            this.grpUUTInfo.ResumeLayout(false);
            this.grpUUTInfo.PerformLayout();
            this.grpComments.ResumeLayout(false);
            this.grpComments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOperator;
        internal System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpUUTInfo;
        internal System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.ComboBox cmboPartNo;
        private System.Windows.Forms.GroupBox grpComments;
        internal System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}