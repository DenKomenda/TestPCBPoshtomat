using Modbus_Poll_CS.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using static Modbus_Poll_CS.main;

namespace Modbus_Poll_CS
{
    
    public partial class mySet : Form
    {
      

        #region Load Listboxes
        private void LoadListboxes()
        {
            //Three to load - ports, baudrates, datetype.  Also set default textbox values:
            //1) Available Ports:
            //Properties.Settings.Default.Upgrade();



            string[] ports = SerialPort.GetPortNames();

            int index = Convert.ToInt16(Settings.Default.ComPort.Substring(3) );
            int index2 = 0;
            int i = 0;

            foreach (string port in ports)
            {

                lstPorts.Items.Add(port);
                if (index == Convert.ToInt16(port.Substring(3))) index2 = i;
                i++;

            }
            try
            {
                if (index2 > -1) lstPorts.SelectedIndex = index2;
            }
            catch (Exception)
            {
                MessageBox.Show("Com port is not available!", "Information");
            }
            

            //2) Baudrates:
            string[] baudrates = { "230400", "115200", "57600", "38400", "19200", "9600" };

            foreach (string baudrate in baudrates)
            {
                lstBaudrate.Items.Add(baudrate);
            }

            lstBaudrate.SelectedIndex = 1;
            lstBaudrate.Enabled = false; 

            txtSlaveID.Text = Convert.ToString(Settings.Default.SlaveID);
            txtSampleRate.Text = Convert.ToString(Settings.Default.SampleRate);
            txtStartAddr.Text = Convert.ToString(Settings.Default.StartAddress);
            txtRegisterQty.Text = Convert.ToString(Settings.Default.RegisterQ );
          
    
        }
        #endregion
       
        public mySet()
        {
            InitializeComponent();
            LoadListboxes();
           // ValidationForm = new myValidation();
        }

      

        //modbus mb = new modbus();
        private void bClose_Click(object sender, EventArgs e)
        {
            //Settings.Default.Save();
            this.Close();
        }

        private void mySet_Load(object sender, EventArgs e)
        {
          txtBoxSelectedFirmwarePath.Text += NewFirmwareSelectValue.value;

            //   Convert.ToInt32(Settings.Default.ComPort.Substring(3));
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Settings.Default.SlaveID= Convert.ToUInt16(txtSlaveID.Text);
            
            Settings.Default.SampleRate= Convert.ToUInt16(txtSampleRate.Text);

            Settings.Default.StartAddress= Convert.ToUInt16(txtStartAddr.Text);

            Settings.Default.RegisterQ= Convert.ToUInt16(txtRegisterQty.Text);
            Settings.Default.ComPort = Convert.ToString(lstPorts.SelectedItem);
            

            if ((slaveErrorProvider.GetError(txtSlaveID) == "") && (sampleRateErrorProvider.GetError(txtSampleRate) == "") && (QregisterErrorProvider.GetError(txtRegisterQty) == "") && (startaddErrorProvider.GetError(txtStartAddr) == ""))
            {
                Settings.Default.Save();
                this.Close();
            }

            else 
            {
                MessageBox.Show("Check yout input values!");
            }

        }
        #region KeyPress(check input values)
        private void txtSlaveID_KeyPress(object sender, KeyPressEventArgs e)
        {        
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
               }
                   

        }

        private void txtStartAddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
           
        }



        private void txtRegisterQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }      
        }

        private void txtSampleRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }


       

        #endregion
        FirmwareSearch myFirmwareSearch;
        private void btnOpenFirmwareSearch_Click(object sender, EventArgs e)
        {
            myFirmwareSearch = new FirmwareSearch();
            myFirmwareSearch.ShowDialog();
        }
    }

}
