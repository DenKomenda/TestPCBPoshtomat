using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Modbus_Poll_CS.main;

namespace Modbus_Poll_CS
{
    public partial class FirmwareSearch : Form
    {
        List<string> listFiles = new List<string>();
        public FirmwareSearch()
        {
            InitializeComponent();
           
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = listView.FocusedItem.Text;
                txtPath.Text += "\\" + Name.ToString();
                Close();
            }
            catch 
            {
                MessageBox.Show("Select Firmware!");
            }
               
        }

 




        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
           // Process.WaitForExit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listFiles.Clear();
            listView.Items.Clear();
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fbd.SelectedPath.ToString();
                    foreach (string item in Directory.GetFiles(fbd.SelectedPath))
                    {
                        imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                        imageList.ImageSize = new Size(112, 112);
                        FileInfo fi = new FileInfo(item);
                        
                        listFiles.Add(fi.FullName);
                        listView.Items.Add(fi.Name, imageList.Images.Count - 1);
                       
                    }
                }               
                
            }      
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            NewFirmwareSelectValue.value = txtPath.Text;
        }
    }
  
}
