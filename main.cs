using System;
using System.Windows.Forms;
using System.Timers;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Threading;
using System.Drawing.Printing;
using System.Diagnostics;
using Modbus_Poll_CS.Properties;
using Microsoft.Win32;
//using System.IO.Ports.SerialPort;
//using Modbus_Poll_CS.FirmwareSearch;

namespace Modbus_Poll_CS
{

    public partial class main : Form
    {
        #region GUI Delegate Declarations
        public delegate void GUIDelegate(string paramString);
        public delegate void GUIClear();
        public delegate void GUIStatus(string paramString);
        #endregion

        modbus mb = new modbus();
        SerialPort sp = new SerialPort();
        System.Timers.Timer timer = new System.Timers.Timer();
        string dataType;
        bool isPolling = false;
        int pollCount;
        string SlaveIDText, HwText, SwText, SnText, StText, StLogs;
        short[] values = new short[Convert.ToInt32(Properties.Settings.Default.RegisterQ)];
        ushort pollStart = Convert.ToUInt16(Properties.Settings.Default.StartAddress);
        ushort pollLength = Convert.ToUInt16(Properties.Settings.Default.RegisterQ);
        byte address = Convert.ToByte(Properties.Settings.Default.SlaveID);
        int LocksQuantity = 12;
       
        IEnumerable<short> LockStatusMask = new List<short> { 0b000000000001, 0b000000000010, 0b000000000100, 0b000000001000,
                                                            0b000000010000, 0b000000100000, 0b000001000000, 0b000010000000,
                                                            0b000100000000, 0b001000000000, 0b010000000000, 0b100000000000 };


        enum ErrorType
        {
            Info, Debug, Error
        }

       


        //List<BoardsModel> boards = new List<BoardsModel>();    



        public main()
        {
            InitializeComponent();
            //LoadBoardList(); 
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            Logger.Test();
           
        }

        #region Log Text_Change_Function
        //void txtLog_TextChanged(object sender, EventArgs e)
        //{
        //    System.Drawing.SizeF mySize = new System.Drawing.SizeF();

        //    // Use the textbox font
        //    System.Drawing.Font myFont = txtLog.Font;

        //    using (Graphics g = this.CreateGraphics())
        //    {
        //        // Get the size given the string and the font
        //        mySize = g.MeasureString(txtLog.Text, myFont);
        //    }

        //    // Resize the textbox 
        //    this.txtLog.Height = (int)Math.Round(mySize.Height, 0);
        //}
        #endregion


        #region Delegate Functions
        public void DoGUIClear()
        {
            if (this.InvokeRequired)
            {
                GUIClear delegateMethod = new GUIClear(this.DoGUIClear);
                this.Invoke(delegateMethod);
            }
            else
            this.txtLog.Clear();
        }
        public void DoGUIStatus(string paramString)
        {
            if (this.InvokeRequired)
            {
                GUIStatus delegateMethod = new GUIStatus(this.DoGUIStatus);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
           //   this.lblStatus.Text = paramString;
           // this.lbSlaveID.Text = SlaveIDText;
           // this.lbHw.Text = HwText;
           // this.lbSw.Text = SwText;
           // this.lbSn.Text = SnText;
           // this.lbStatuses.Text = StText;
            this.txtLog.Text = StLogs;
        }
        public void DoGUIUpdate(string paramString)
        {
            if (this.InvokeRequired)
            {
                GUIDelegate delegateMethod = new GUIDelegate(this.DoGUIUpdate);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
            {
                this.txtLog.Text = StLogs;

            }
        }
        #endregion

        #region Timer Elapsed Event Handler
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PollFunction();
        }
        #endregion



        #region Start and Stop Procedures
        private void StartPoll()
        {
           // Task.Delay(1000);
            pollCount = 0;
            isPolling = true;
            Properties.Settings.Default.Upgrade();

            if (mb.Open(Properties.Settings.Default.ComPort, Properties.Settings.Default.BaudRate, 8, Parity.None, StopBits.One))

            //Open COM port using provided settings:
            {
                //Disable double starts:
                dataType = "Decimal";

                //Set polling flag:
                isPolling = true;

                //Start timer using provided values:
                timer.AutoReset = true;

                timer.Interval = Convert.ToDouble(Properties.Settings.Default.SampleRate);
                //if (txtSampleRate.Text != "")
                //    timer.Interval = Convert.ToDouble(txtSampleRate.Text);
                //else
                //    timer.Interval = 1000;
                timer.Start();
            }


           // Task.Delay(5000);
            lblStatus.Text = mb.modbusStatus;
        }
        private void StopPoll()
        {
            //Stop timer and close COM port:
            isPolling = false;
            timer.Stop();
            mb.Close();
            //  sp.Close();
            lblStatus.Text = mb.modbusStatus;
        }

        //private void LoadBoardList() 
        //{


        //}

        //private void WireUpListBoxes() 
        //{
        //    lstRegisterValues.DataSource = null;
        //    lstRegisterValues.DataSource = boards;

        //}

        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //    StartPoll();
        //}
        //private void btnStop_Click(object sender, EventArgs e)
        //{
        //    StopPoll();
        //}
        #endregion

        #region Poll Function

        private void PollFunction()
        {
            //Update GUI:
            DoGUIClear();
            pollCount++;
            DoGUIStatus("Poll count: " + pollCount.ToString());

            //Create array to accept read values:


            try
            {
                while (!mb.SendFc3(Convert.ToByte(Properties.Settings.Default.SlaveID), pollStart, pollLength, ref values)) ;
            }
            catch (Exception err)
            {
                DoGUIStatus("Error in modbus read: " + err.Message);
            }

            string itemString;

            switch (dataType)
            {
                case "Decimal":
                    for (int i = 0; i < pollLength; i++)
                    {
                        itemString = "[" + Convert.ToString(pollStart + i + 1) + "] = " + values[i].ToString();
                        DoGUIUpdate(itemString);
                        switch (pollStart + i + 1)
                        {
                            case 1000:
                                SlaveIDText = values[i].ToString();
                                break;
                            case 1001:
                                HwText = values[i].ToString();
                                break;
                            case 1002:
                                SwText = values[i].ToString();
                                break;
                            case 1003:
                                SnText = values[i].ToString();
                                break;
                            case 1004:
                                SnText += values[i].ToString();
                                break;
                            case 1005:
                                StText = Convert.ToString(values[i], 2).PadLeft(16, '0');
                                break;


                        }


                    }
                    break;
                    //case "Hexadecimal":
                    //    for (int i = 0; i < pollLength; i++)
                    //    {
                    //        itemString = "[" + Convert.ToString(pollStart + i + 1) + "]  = " + values[i].ToString("X");

                    //        DoGUIUpdate(itemString);
                    //    }
                    //    break;
                    //case "Float":
                    //    for (int i = 0; i < (pollLength / 2); i++)
                    //    {
                    //        int intValue = (int)values[2 * i];
                    //        intValue <<= 16;
                    //        intValue += (int)values[2 * i + 1];
                    //        itemString = "[" + Convert.ToString(pollStart + 2 * i +1) + "] = " +
                    //            (BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0)).ToString();
                    //        DoGUIUpdate(itemString);
                    //    }
                    //    break;
                    //case "Reverse":
                    //    for (int i = 0; i < (pollLength / 2); i++)
                    //    {
                    //        int intValue = (int)values[2 * i + 1];
                    //        intValue <<= 16;
                    //        intValue += (int)values[2 * i];
                    //        itemString = "[" + Convert.ToString(pollStart + 2 * i + 1) + "] = " +
                    //            (BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0)).ToString();
                    //        DoGUIUpdate(itemString);
                    //    }
                    //    break;
            }
        }
        #endregion


        void WriteLog(String Mtext, ErrorType ErType)
        {

            StLogs += Mtext;
            txtLog.AppendText(Mtext);
            //switch (ErType)
            //{
            //    case ErrorType.Debug:
            //        StLogs += "::DEBUG::" + Environment.NewLine;
            //        log.Debug(Mtext);
            //        break;
            //    case ErrorType.Info:
            //        StLogs += "::INFO::" + Environment.NewLine;
            //        log.Info(Mtext);
            //        break;
            //    case ErrorType.Error:

            //        StLogs += "::ERROR::" + Environment.NewLine;
            //        log.Error(Mtext);
            //        break;
            //}
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
          //  StLogs += StLogs + Mtext + Environment.NewLine;
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(main));
        private readonly string HKEY_CURRENT_USER;

        #region Enter new SlaveID and Serial Number
        private void checkBoxSLID_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSLID.Checked)
            {
                txtBoxSLID.Visible = true;

                chkBoxRange.Enabled = false;
                chkBoxRange.Checked = false;
            }
            else 
            {
                chkBoxRange.Enabled = true;
                txtBoxSLID.Visible = false;
            }
        }

        private void checkBoxSerNum_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSerNum.Checked)
            {
                txtBoxSerNum.Visible = true;
            }
            else 
            {
                txtBoxSerNum.Visible = false;
            }

        }
        private void chkBoxRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxRange.Checked)
            {
                txtBoxSlaveRange1.Visible = true;
                txtBoxSlaveRange2.Visible = true;
                lblSlaveRange.Visible = true;

                checkBoxSLID.Enabled = false;
            }
            else
            {
                txtBoxSlaveRange1.Visible = false;
                txtBoxSlaveRange2.Visible = false;
                lblSlaveRange.Visible = false;

                checkBoxSLID.Enabled = true;
            }
        }

        private void btnTestPCB_Click(object sender, EventArgs e)
        {
            mb.Open(Properties.Settings.Default.ComPort, Properties.Settings.Default.BaudRate, 8, Parity.None, StopBits.One);
            WriteLog("Testing PCB...", ErrorType.Info);

            #region Check locks statuses
            short[] lockst = new short[1];
            try
            {
               mb.SendFc3(address, 1004, (ushort)1, ref lockst); 
            }
            catch
            {
                MessageBox.Show("Error in read event");
            }
            for (int i = 1; i <= 12; i++)
            {
                bool check = (lockst[0] & LockStatusMask.ElementAt(i - 1)) == 0;
                if (check)
                {
                    //  WriteLog("Lock  " + Convert.ToString(i) + " status - ok. Lock closed\r\n", ErrorType.Info);
                }
                else
                {
                    WriteLog(".\r\n", ErrorType.Error);
                    WriteLog(":::FAIL:::" + " Lock  " + Convert.ToString(i) + "  status - error. Lock is not closed\r\n", ErrorType.Error);
                    MessageBox.Show("Lock  " + Convert.ToString(i) + "  status - error. Lock is not closed");
                }
            }

            #endregion

            #region Check locks efficiency
            try
            {
                short oldVal = lockst[0];
                ushort start = 1004;
                short[] value = new short[1];
                value[0] = 32767;
                mb.SendFc16(address, start, (ushort)1, value);

                Thread.Sleep(500);
                mb.SendFc3(Convert.ToByte(Properties.Settings.Default.SlaveID), pollStart, pollLength, ref values);
                short newVal = values[5];

                for (int i = 0; i <= 11; i++)
                {
                    bool check1 = ((oldVal & 1 << i) > 0);
                    bool check2 = ((newVal & 1 << i) == 0);
                    bool check3 = ((oldVal & 1 << i) == 0);
                    bool check4 = ((newVal & 1 << i) > 0);

                    if ((check1 && check2) || (check3 && check4))
                    {
                        //  WriteLog("Lock  " + Convert.ToString(i+1) + " works correctly\r\n", ErrorType.Info);
                       
                    }
                    else
                    {
                        WriteLog(":::FAIL:::" + " Lock  " + Convert.ToString(i + 1) + " does not work\r\n", ErrorType.Error);
                        MessageBox.Show("Lock  " + Convert.ToString(i + 1) + " does not work");
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("Error doing to test lock");
            }
            #endregion
            //txtLog.AppendText(" OK");
            WriteLog(" OK\r\n", ErrorType.Info);
            mb.Close();
        }
        #endregion

        public static class NewFirmwareSelectValue
        {
            public static string value { get; set; }
        }



        #region Validation
        private void txtBoxSLID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value (NUMBER)");
            }
        }

        private void txtBoxSLID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(txtBoxSLID.Text) == 0 || Convert.ToInt16(txtBoxSLID.Text) > 62)
                {
                    MessageBox.Show("SlaveID must be in range from 1 to 62");
                }
                else
                {
                }
            }
            catch
            {
            }

        }

        private void txtBoxSlaveRange1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(txtBoxSlaveRange1.Text) == 0) MessageBox.Show("Slave ID must be in range from 1 to 62");
            }
            catch { }
        }

        private void txtBoxSlaveRange2_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(txtBoxSlaveRange2.Text) > 62 || (Convert.ToInt16(txtBoxSlaveRange1.Text) > Convert.ToInt16(txtBoxSlaveRange2.Text))) MessageBox.Show("Please input correct range values");
            }
            catch { }
        }

        private void txtBoxSlaveRange1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value (NUMBER)");
            }
        }

        private void txtBoxSlaveRange2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value (NUMBER)");
            }
        }

        #endregion

          #region TestAll
        private void btnTestAll_Click(object sender, EventArgs e)
        {
            
            mb.Open(Properties.Settings.Default.ComPort, Properties.Settings.Default.BaudRate, 8, Parity.None, StopBits.One);
            btnTestAll.Enabled = false;
            if (NewFirmwareSelectValue.value != null)
            {
                try
                {

                    WriteLog("Start flashing...", ErrorType.Info);
                    ProcessStartInfo processFirmwareSend = new ProcessStartInfo("JFlash.exe");
                    processFirmwareSend.WindowStyle = ProcessWindowStyle.Minimized;
                    string[] args = new string[9];
                    string JlinkPath = Convert.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\SEGGER\\J-Link", "InstallPath", false)) + "Jflash.exe";
                    args[0] = "-hide";
                    args[1] = " -jflashlog\"C:\\ModbusPollCS\\J-Link\\Logs.txt\"";
                    args[2] = " -openprj\"C:\\ModbusPollCS\\J-Link\\FirstPF.jflash\"";
                    args[3] = " -open" + NewFirmwareSelectValue.value;           
                    args[4] = " -erasechip";
                    args[5] = " -programverify";
                    args[6] = " -startapp";
                    args[7] = " -disconnect";
                    args[8] = " -exit";
                    processFirmwareSend.Arguments = args[0] + args[1] + args[2] + args[3] + args[4] + args[5] + args[6] + args[7] + args[8];
                    try
                    {
                        Process myProcess = Process.Start(JlinkPath, processFirmwareSend.Arguments);
                      
                        do
                        {
                            if (!myProcess.HasExited)
                            {
                                myProcess.Refresh();
                            }
                        }
                        while (!myProcess.WaitForExit(1000));
                        if (myProcess.ExitCode == 0)
                        {
                            WriteLog(" OK\r\n", ErrorType.Info);
                        }
                        else
                        {
                            WriteLog(" ERROR\r\n", ErrorType.Info);
                        }

                        myProcess.Dispose();
                    }
                    catch
                    {
                        WriteLog(" ERROR\r\n", ErrorType.Error);
                    }
                    Thread.Sleep(1500);
                }
                catch
                {
                    MessageBox.Show("Error in flashing PCB");
                }
            }



                WriteLog("Testing PCB...", ErrorType.Info);


                #region Check locks statuses
                short[] lockst = new short[1];
            
                mb.SendFc3(address, 1004, (ushort)1, ref lockst);
                for (int i = 1; i <= 12; i++)
                {
                    bool check = (lockst[0] & LockStatusMask.ElementAt(i - 1)) == 0;
                    if (check)
                    {
                        //  WriteLog("Lock  " + Convert.ToString(i) + " status - ok. Lock closed\r\n", ErrorType.Info);
                    }
                    else
                    {
                        WriteLog(":::FAIL:::" + "Lock  " + Convert.ToString(i) + "  status - error. Lock is not closed\r\n", ErrorType.Error);
                    }
                }

                #endregion

                #region Check locks efficiency


                try
                {
                if (!sp.IsOpen)
                {
                   // sp.Open();
                    mb.Open(Properties.Settings.Default.ComPort, Properties.Settings.Default.BaudRate, 8, Parity.None, StopBits.One);
                }
                short oldVal = lockst[0];
                    ushort start = 1004;
                    short[] value = new short[1];
                    value[0] = 32767;
                    mb.SendFc16(address, start, (ushort)1, value);

                    Thread.Sleep(500);
                    mb.SendFc3(Convert.ToByte(Properties.Settings.Default.SlaveID), pollStart, pollLength, ref values);
                    short newVal = values[5];

                    for (int i = 0; i <= 11; i++)
                    {
                        bool check1 = ((oldVal & 1 << i) > 0);
                        bool check2 = ((newVal & 1 << i) == 0);//locks

                        bool check3 = ((oldVal & 1 << i) == 0);
                        bool check4 = ((newVal & 1 << i) > 0);//relayss

                        if ((check1 && check2) || (check3 && check4))
                        {
                            //  WriteLog("Lock  " + Convert.ToString(i+1) + " works correctly\r\n", ErrorType.Info);
                            WriteLog("\r\nLock " + (i+1) + "--- OK", ErrorType.Info);
                        }
                        else
                        {
                            WriteLog("\r\n:::FAIL:::" + " Lock  " + Convert.ToString(i + 1) + " does not work", ErrorType.Error);
                       //     MessageBox.Show("Lock  " + Convert.ToString(i + 1) + " does not work");
                        }
                    }

                }
                catch (Exception ex)
                {
                    log.Error("Error doing to test lock");
                }



                #endregion
               
                #region stich SerialNumber

                try
                {
                    if (checkBoxSerNum.Checked && txtBoxSerNum.Text != "")
                    {
                        // newSerialNumber = Convert.ToInt16(txtBoxSerNum.Text);
                        if (txtBoxSerNum.Text == "") MessageBox.Show("Please enter Serial Number");
                        short[] newSerial = new short[1];
                        newSerial[0] = Convert.ToInt16(txtBoxSerNum.Text);
                        mb.SendFc16(address, 1002, (ushort)1, newSerial);
                        Logger.WriteInfo("Serial Number is " + newSerial[0]);
                    }
                    else
                    {
                    //    ushort start = 1002;
                     //   short[] value = new short[1];
                    //   value[0] = 111;
                    //    if (mb.SendFc16(address, start, (ushort)1, value)) Logger.WriteInfo("Serial Number is " + value[0]);
                    }

                }
                catch
                {
                    // MessageBox.Show("Error flashing the Serial Number to the board");
                    WriteLog(":::FAIL:::" + "Error flashing the Serial Number to the board\r\n", ErrorType.Error);
                }
                #endregion

                #region stich Id

                try
                {
                 
                    if (checkBoxSLID.Checked && txtBoxSLID.Text != "")
                    {
                        if (txtBoxSLID.Text == "") MessageBox.Show("Please enter SlaveID");
                        short[] newSlave = new short[1];
                        newSlave[0] = Convert.ToInt16(txtBoxSLID.Text);
                        mb.SendFc16(address, 999, (ushort)1, newSlave);
                        Logger.WriteInfo("SlaveID is " + newSlave[0]);
                    }
                    if (chkBoxRange.Checked && txtBoxSlaveRange1.Text != "" && txtBoxSlaveRange2.Text != "")
                    {
                        int first = Convert.ToInt16(txtBoxSlaveRange1.Text);
                        int last = Convert.ToInt16(txtBoxSlaveRange2.Text);
                        short[] newSlave = new short[1];

                        newSlave[0] = Convert.ToInt16(txtBoxSlaveRange1.Text);
                        mb.SendFc16(address, 999, (ushort)1, newSlave);
                        Logger.WriteInfo("SlaveID is " + newSlave[0]);
                        first++;
                        txtBoxSlaveRange1.Text = Convert.ToString(first);

                        if (Convert.ToInt16(txtBoxSlaveRange1.Text) == Convert.ToInt16(txtBoxSlaveRange2.Text))
                            mb.SendFc16(address, 999, (ushort)1, newSlave);
                        //for (int i = first; Convert.ToBoolean(i = last); i++)
                        //{
                        //    newSlave[0] = Convert.ToInt16(i);
                        //    mb.SendFc16(address, 999, (ushort)1, newSlave);
                        //    Logger.WriteInfo("SlaveID is " + newSlave[0]);
                        //}
                    }
                    if (!(checkBoxSLID.Checked || chkBoxRange.Checked))
                    {
                        ushort start = 999;
                        short[] value = new short[1];
                        value[0] = 62;
                        mb.SendFc16(address, start, (ushort)1, value);
                        Logger.WriteInfo("SlaveID is " + value[0]);
                    }

                
                    Thread.Sleep(500);
                }
                catch
                {
                    WriteLog(":::FAIL:::" + "Error flashing the Slave ID to the board\r\n", ErrorType.Error);
                }

                #endregion

                #region Print Label

                //try
                //{
                //    PrintPreviewDialog PPDlg = new PrintPreviewDialog();
                //    PrintDocument PDoc = new PrintDocument();
                //    //base.OnLoad(e);
                //    PDoc.PrinterSettings.PrinterName = "TSC TTP-244 Pro";
                //    PDoc.OriginAtMargins = true;
                //    PDoc.DefaultPageSettings.Margins = new Margins(10, 0, 0, 0);
                //    PDoc.PrintPage += PDoc_PrintPage;
                //    PPDlg.Document = PDoc;
                //    PPDlg.ShowDialog();
                //}
                //catch
                //{
                //    MessageBox.Show("Error in printering label");
                //}

                #endregion
                btnTestAll.Enabled = true;
                Logger.WriteInfo("Flashing of the board is successful!");
                WriteLog("\r\nWe are done with test lock\r\n", ErrorType.Info);
                 mb.Close();
        }          
          
           
        

        #endregion
 
        #region Printer Label Settings
        //private void PDoc_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    string serialLabel;
        //    if (txtBoxSerNum.Text == "")
        //    {
        //        serialLabel = "111";
        //    }
        //    else
        //    {
        //       serialLabel = txtBoxSerNum.Text;
        //    }
        //    Rectangle R = new Rectangle(8, 2, 500, 0);
        //    StringFormat SF = StringFormat.GenericTypographic;
        //    e.Graphics.DrawString(serialLabel, new Font("", 20), Brushes.Black, R, SF);

        //}
        #endregion
        
       
      
        mySet SettingsForm;
        private void bSettings_Click(object sender, EventArgs e)
        {
            StopPoll();
            mb.Close();

            SettingsForm = new mySet();
            SettingsForm.ShowDialog();
        }


     
        private void main_Load(object sender, EventArgs e)
        {
                List<BoardsModel> boards = SqlLiteDataAccess.LoadBoards();
          //    WireUpListBoxes();
        }
    }
    
    }
