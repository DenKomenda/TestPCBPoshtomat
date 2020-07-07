using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus_Poll_CS
{
        public partial class myValidation : Form
     {
      //  mySet SettingsForm;
        public myValidation()
        {
            InitializeComponent();
            LoadMessage();
        }


        public void LoadMessage()
        {
            switch (mySet.typeErr)
            {
                case "SlaveID":
                    txtBoxmyValdation.Text = "Incorrect SlaveID value! The value is in range from 0 to 62 ";
                    break;

                case "StartAddress":
                    txtBoxmyValdation.Text = "Incorrect Start Address value! The value is in range from 999 to 1005 (+1) ";
                    break;

                case "RegisterQuantity":
                    txtBoxmyValdation.Text = "Incorrect Register quantity value! The value is in range from 1 to 6 ";
                    break;

                case "SampleRate":
                    txtBoxmyValdation.Text = "Incorrect Sample rate value! The value must be positive ";
                    break;

            }

        }


        private void btnCloseMyValidation_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     }
}
