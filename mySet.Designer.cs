using System;
using System.Drawing.Text;

namespace Modbus_Poll_CS
{
    partial class mySet
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
            this.bClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSampleRate = new System.Windows.Forms.TextBox();
            this.txtRegisterQty = new System.Windows.Forms.TextBox();
            this.txtStartAddr = new System.Windows.Forms.TextBox();
            this.txtSlaveID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstBaudrate = new System.Windows.Forms.ComboBox();
            this.lstPorts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.slaveErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.startaddErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.QregisterErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.sampleRateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOpenFirmwareSearch = new System.Windows.Forms.Button();
            this.txtBoxSelectedFirmwarePath = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slaveErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startaddErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QregisterErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRateErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(138, 269);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(120, 23);
            this.bClose.TabIndex = 0;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSampleRate);
            this.groupBox2.Controls.Add(this.txtRegisterQty);
            this.groupBox2.Controls.Add(this.txtStartAddr);
            this.groupBox2.Controls.Add(this.txtSlaveID);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 124);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Poll Info";
            // 
            // txtSampleRate
            // 
            this.txtSampleRate.Location = new System.Drawing.Point(90, 91);
            this.txtSampleRate.Name = "txtSampleRate";
            this.txtSampleRate.Size = new System.Drawing.Size(82, 20);
            this.txtSampleRate.TabIndex = 8;
            this.txtSampleRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSampleRate_KeyPress);
            this.txtSampleRate.Validated += new System.EventHandler(this.txtSampleRate_Validated);
            // 
            // txtRegisterQty
            // 
            this.txtRegisterQty.Location = new System.Drawing.Point(90, 65);
            this.txtRegisterQty.Name = "txtRegisterQty";
            this.txtRegisterQty.Size = new System.Drawing.Size(82, 20);
            this.txtRegisterQty.TabIndex = 7;
            this.txtRegisterQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegisterQty_KeyPress);
            this.txtRegisterQty.Validated += new System.EventHandler(this.txtRegisterQry_Validated);
            // 
            // txtStartAddr
            // 
            this.txtStartAddr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStartAddr.Location = new System.Drawing.Point(90, 39);
            this.txtStartAddr.Name = "txtStartAddr";
            this.txtStartAddr.Size = new System.Drawing.Size(82, 20);
            this.txtStartAddr.TabIndex = 6;
            this.txtStartAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartAddr_KeyPress);
            this.txtStartAddr.Validated += new System.EventHandler(this.txtStartAddr_Validated);
            // 
            // txtSlaveID
            // 
            this.txtSlaveID.Location = new System.Drawing.Point(90, 13);
            this.txtSlaveID.Name = "txtSlaveID";
            this.txtSlaveID.Size = new System.Drawing.Size(82, 20);
            this.txtSlaveID.TabIndex = 5;
            this.txtSlaveID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlaveID_KeyPress);
            this.txtSlaveID.Validated += new System.EventHandler(this.txtSlaveID_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Sample Rate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Register Qty:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Start Addr:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Slave ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstBaudrate);
            this.groupBox1.Controls.Add(this.lstPorts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Info";
            // 
            // lstBaudrate
            // 
            this.lstBaudrate.Enabled = false;
            this.lstBaudrate.FormattingEnabled = true;
            this.lstBaudrate.Location = new System.Drawing.Point(90, 40);
            this.lstBaudrate.Name = "lstBaudrate";
            this.lstBaudrate.Size = new System.Drawing.Size(82, 21);
            this.lstBaudrate.TabIndex = 3;
            // 
            // lstPorts
            // 
            this.lstPorts.FormattingEnabled = true;
            this.lstPorts.Location = new System.Drawing.Point(90, 13);
            this.lstPorts.Name = "lstPorts";
            this.lstPorts.Size = new System.Drawing.Size(82, 21);
            this.lstPorts.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Location = new System.Drawing.Point(12, 269);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(120, 23);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // slaveErrorProvider
            // 
            this.slaveErrorProvider.ContainerControl = this;
            // 
            // startaddErrorProvider
            // 
            this.startaddErrorProvider.ContainerControl = this;
            // 
            // QregisterErrorProvider
            // 
            this.QregisterErrorProvider.ContainerControl = this;
            // 
            // sampleRateErrorProvider
            // 
            this.sampleRateErrorProvider.ContainerControl = this;
            // 
            // btnOpenFirmwareSearch
            // 
            this.btnOpenFirmwareSearch.Location = new System.Drawing.Point(12, 217);
            this.btnOpenFirmwareSearch.Name = "btnOpenFirmwareSearch";
            this.btnOpenFirmwareSearch.Size = new System.Drawing.Size(110, 23);
            this.btnOpenFirmwareSearch.TabIndex = 5;
            this.btnOpenFirmwareSearch.Text = "Select firmware file";
            this.btnOpenFirmwareSearch.UseVisualStyleBackColor = true;
            this.btnOpenFirmwareSearch.Click += new System.EventHandler(this.btnOpenFirmwareSearch_Click);
            // 
            // txtBoxSelectedFirmwarePath
            // 
            this.txtBoxSelectedFirmwarePath.Location = new System.Drawing.Point(12, 246);
            this.txtBoxSelectedFirmwarePath.Name = "txtBoxSelectedFirmwarePath";
            this.txtBoxSelectedFirmwarePath.ReadOnly = true;
            this.txtBoxSelectedFirmwarePath.Size = new System.Drawing.Size(246, 20);
            this.txtBoxSelectedFirmwarePath.TabIndex = 6;
            // 
            // mySet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 300);
            this.Controls.Add(this.txtBoxSelectedFirmwarePath);
            this.Controls.Add(this.btnOpenFirmwareSearch);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "mySet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modbus settings";
            this.Load += new System.EventHandler(this.mySet_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slaveErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startaddErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QregisterErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRateErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #region Validation Methods
        private void txtSlaveID_Validated(object sender, System.EventArgs e) 
        {

            //Check SlaveId correctness
            if (IsSlaveValid()) slaveErrorProvider.SetError(this.txtSlaveID, String.Empty);

            if (Convert.ToInt16(txtSlaveID.Text) <= 0 || Convert.ToUInt16(txtSlaveID.Text) > 62)
            {
                slaveErrorProvider.SetError(this.txtSlaveID, "SlaveID is in range from 1 to 62");
            }
           
        }
        private void txtSampleRate_Validated(object sender, System.EventArgs e)
        {
            if (IsSampleRateValid())  sampleRateErrorProvider.SetError(this.txtSampleRate, String.Empty); 
            if (Convert.ToUInt16(txtSampleRate.Text) <= 0) sampleRateErrorProvider.SetError(this.txtSampleRate, "Sampe Rate must be positive!");
        }

        private void txtRegisterQry_Validated(object sender, System.EventArgs e)
        {
            if (IsRegisterQtyValid()) QregisterErrorProvider.SetError(this.txtRegisterQty, String.Empty);
            if (Convert.ToUInt16(txtRegisterQty.Text) > 6) QregisterErrorProvider.SetError(this.txtRegisterQty, "There are 6 registers!");
        }

        private void txtStartAddr_Validated(object sender, System.EventArgs e)
        {
            if (IsStartaddrValid()) startaddErrorProvider.SetError(this.txtStartAddr, String.Empty);
            if (Convert.ToUInt16(txtStartAddr.Text) < 999 || Convert.ToUInt16(txtStartAddr.Text) > 1005) startaddErrorProvider.SetError(this.txtStartAddr, "Start address is incorrect!(From 999 to 1005)");
            

        }



        private bool IsSlaveValid()
        {
            return (txtSlaveID.Text.Length > 0);
        }
        private bool IsSampleRateValid()
        {
            return (txtSampleRate.Text.Length > 0);
        }
        private bool IsRegisterQtyValid()
        {
            return (txtRegisterQty.Text.Length > 0);
        }
        private bool IsStartaddrValid()
        {
            return (txtStartAddr.Text.Length > 0);
        }

        #endregion


        #endregion

        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSampleRate;
        private System.Windows.Forms.TextBox txtRegisterQty;
        private System.Windows.Forms.TextBox txtStartAddr;
        private System.Windows.Forms.TextBox txtSlaveID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox lstBaudrate;
        private System.Windows.Forms.ComboBox lstPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.ErrorProvider slaveErrorProvider;
        private System.Windows.Forms.ErrorProvider startaddErrorProvider;
        private System.Windows.Forms.ErrorProvider QregisterErrorProvider;
        private System.Windows.Forms.ErrorProvider sampleRateErrorProvider;
        private System.Windows.Forms.Button btnOpenFirmwareSearch;
        private System.Windows.Forms.TextBox txtBoxSelectedFirmwarePath;
    }

}