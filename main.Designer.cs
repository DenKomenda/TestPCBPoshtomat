namespace Modbus_Poll_CS
{
    partial class main
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bSettings = new System.Windows.Forms.Button();
            this.btnTestAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.checkBoxSLID = new System.Windows.Forms.CheckBox();
            this.checkBoxSerNum = new System.Windows.Forms.CheckBox();
            this.txtBoxSLID = new System.Windows.Forms.TextBox();
            this.txtBoxSerNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTestPCB = new System.Windows.Forms.Button();
            this.txtBoxSlaveRange1 = new System.Windows.Forms.TextBox();
            this.txtBoxSlaveRange2 = new System.Windows.Forms.TextBox();
            this.lblSlaveRange = new System.Windows.Forms.Label();
            this.chkBoxRange = new System.Windows.Forms.CheckBox();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 411);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(948, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // bSettings
            // 
            this.bSettings.Location = new System.Drawing.Point(12, 21);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(108, 47);
            this.bSettings.TabIndex = 7;
            this.bSettings.Text = "Settings";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // btnTestAll
            // 
            this.btnTestAll.Location = new System.Drawing.Point(12, 321);
            this.btnTestAll.Name = "btnTestAll";
            this.btnTestAll.Size = new System.Drawing.Size(915, 76);
            this.btnTestAll.TabIndex = 49;
            this.btnTestAll.Text = "Stich and test PCD";
            this.btnTestAll.UseVisualStyleBackColor = true;
            this.btnTestAll.Click += new System.EventHandler(this.btnTestAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLog);
            this.groupBox1.Location = new System.Drawing.Point(9, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 241);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(912, 222);
            this.txtLog.TabIndex = 0;
            // 
            // checkBoxSLID
            // 
            this.checkBoxSLID.AutoSize = true;
            this.checkBoxSLID.Location = new System.Drawing.Point(390, 14);
            this.checkBoxSLID.Name = "checkBoxSLID";
            this.checkBoxSLID.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSLID.TabIndex = 50;
            this.checkBoxSLID.UseVisualStyleBackColor = true;
            this.checkBoxSLID.CheckedChanged += new System.EventHandler(this.checkBoxSLID_CheckedChanged);
            // 
            // checkBoxSerNum
            // 
            this.checkBoxSerNum.AutoSize = true;
            this.checkBoxSerNum.Location = new System.Drawing.Point(390, 54);
            this.checkBoxSerNum.Name = "checkBoxSerNum";
            this.checkBoxSerNum.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSerNum.TabIndex = 51;
            this.checkBoxSerNum.UseVisualStyleBackColor = true;
            this.checkBoxSerNum.CheckedChanged += new System.EventHandler(this.checkBoxSerNum_CheckedChanged);
            // 
            // txtBoxSLID
            // 
            this.txtBoxSLID.Location = new System.Drawing.Point(411, 11);
            this.txtBoxSLID.Multiline = true;
            this.txtBoxSLID.Name = "txtBoxSLID";
            this.txtBoxSLID.Size = new System.Drawing.Size(100, 24);
            this.txtBoxSLID.TabIndex = 52;
            this.txtBoxSLID.Visible = false;
            this.txtBoxSLID.TextChanged += new System.EventHandler(this.txtBoxSLID_TextChanged);
            this.txtBoxSLID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSLID_KeyPress);
            // 
            // txtBoxSerNum
            // 
            this.txtBoxSerNum.Location = new System.Drawing.Point(411, 51);
            this.txtBoxSerNum.Multiline = true;
            this.txtBoxSerNum.Name = "txtBoxSerNum";
            this.txtBoxSerNum.Size = new System.Drawing.Size(100, 24);
            this.txtBoxSerNum.TabIndex = 53;
            this.txtBoxSerNum.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "SlaveID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "SerialNumber";
            // 
            // btnTestPCB
            // 
            this.btnTestPCB.Location = new System.Drawing.Point(150, 21);
            this.btnTestPCB.Name = "btnTestPCB";
            this.btnTestPCB.Size = new System.Drawing.Size(108, 47);
            this.btnTestPCB.TabIndex = 56;
            this.btnTestPCB.Text = "Test PCB";
            this.btnTestPCB.UseVisualStyleBackColor = true;
            this.btnTestPCB.Click += new System.EventHandler(this.btnTestPCB_Click);
            // 
            // txtBoxSlaveRange1
            // 
            this.txtBoxSlaveRange1.Location = new System.Drawing.Point(639, 11);
            this.txtBoxSlaveRange1.Multiline = true;
            this.txtBoxSlaveRange1.Name = "txtBoxSlaveRange1";
            this.txtBoxSlaveRange1.Size = new System.Drawing.Size(43, 24);
            this.txtBoxSlaveRange1.TabIndex = 57;
            this.txtBoxSlaveRange1.Text = "1";
            this.txtBoxSlaveRange1.Visible = false;
            this.txtBoxSlaveRange1.TextChanged += new System.EventHandler(this.txtBoxSlaveRange1_TextChanged);
            this.txtBoxSlaveRange1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSlaveRange1_KeyPress);
            // 
            // txtBoxSlaveRange2
            // 
            this.txtBoxSlaveRange2.Location = new System.Drawing.Point(716, 11);
            this.txtBoxSlaveRange2.Multiline = true;
            this.txtBoxSlaveRange2.Name = "txtBoxSlaveRange2";
            this.txtBoxSlaveRange2.Size = new System.Drawing.Size(43, 24);
            this.txtBoxSlaveRange2.TabIndex = 58;
            this.txtBoxSlaveRange2.Text = "5";
            this.txtBoxSlaveRange2.Visible = false;
            this.txtBoxSlaveRange2.TextChanged += new System.EventHandler(this.txtBoxSlaveRange2_TextChanged_1);
            this.txtBoxSlaveRange2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSlaveRange2_KeyPress);
            // 
            // lblSlaveRange
            // 
            this.lblSlaveRange.AutoSize = true;
            this.lblSlaveRange.Location = new System.Drawing.Point(689, 14);
            this.lblSlaveRange.Name = "lblSlaveRange";
            this.lblSlaveRange.Size = new System.Drawing.Size(22, 13);
            this.lblSlaveRange.TabIndex = 59;
            this.lblSlaveRange.Text = "-----";
            this.lblSlaveRange.Visible = false;
            // 
            // chkBoxRange
            // 
            this.chkBoxRange.AutoSize = true;
            this.chkBoxRange.Checked = true;
            this.chkBoxRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxRange.Location = new System.Drawing.Point(551, 15);
            this.chkBoxRange.Name = "chkBoxRange";
            this.chkBoxRange.Size = new System.Drawing.Size(65, 17);
            this.chkBoxRange.TabIndex = 60;
            this.chkBoxRange.Text = "In range";
            this.chkBoxRange.UseVisualStyleBackColor = true;
            this.chkBoxRange.CheckedChanged += new System.EventHandler(this.chkBoxRange_CheckedChanged);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 433);
            this.Controls.Add(this.chkBoxRange);
            this.Controls.Add(this.lblSlaveRange);
            this.Controls.Add(this.txtBoxSlaveRange2);
            this.Controls.Add(this.txtBoxSlaveRange1);
            this.Controls.Add(this.btnTestPCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxSerNum);
            this.Controls.Add(this.txtBoxSLID);
            this.Controls.Add(this.checkBoxSerNum);
            this.Controls.Add(this.checkBoxSLID);
            this.Controls.Add(this.btnTestAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bSettings);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modbus Poll";
            this.Load += new System.EventHandler(this.main_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnTestAll;
        private System.Windows.Forms.CheckBox checkBoxSLID;
        private System.Windows.Forms.CheckBox checkBoxSerNum;
        private System.Windows.Forms.TextBox txtBoxSLID;
        private System.Windows.Forms.TextBox txtBoxSerNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestPCB;
        private System.Windows.Forms.TextBox txtBoxSlaveRange1;
        private System.Windows.Forms.TextBox txtBoxSlaveRange2;
        private System.Windows.Forms.Label lblSlaveRange;
        private System.Windows.Forms.CheckBox chkBoxRange;
    }
    #region Validation Methods
    //private void txtBoxSLID_Validated(object sender, System.EventArgs e)
    //{

    //    //Check SlaveId correctness
    //    if (IsSlaveValid()) slaveIDErrorProvider.SetError(this.txtBoxSLID, String.Empty);

    //    if (Convert.ToInt16(txtBoxSLID.Text) <= 0 || Convert.ToUInt16(txtBoxSLID.Text) > 62)
    //    {
    //        slaveIDErrorProvider.SetError(this.txtBoxSLID, "SlaveID is in range from 1 to 62");
    //    }

    //}
    //private bool IsSlaveValid()
    //{
    //    return (txtBoxSLID.Text.Length > 0);
    //}
    #endregion


}



