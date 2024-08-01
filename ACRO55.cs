using System;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using CS.Libraries.File.Initialization;

namespace XYPositionSystem
{
    public partial class ACRO55 : Form
    {
        const char ctrl_X = (char)0x18;

        // Dimensions of active LCD (area with pixels)
        const double LCD_height = 8.283;    // 210.4 mm on MFD drawings
        const double LCD_width  = 6.213;    // 157.8 mm on MFD drawings

        const double LCD_marginHoriz = 0.1 * LCD_width;
        const double LCD_marginVert  = 0.1 * LCD_height;

        /* THE POSITIONS DEFINED BELOW ARE FROM THE PERSPECTIVE OF THE X-Y TABLE.
         * The Y axis is the direction that the gantry moves back and forth (two stepper motors,
         * one at each end of the gantry)  The back of the X-Y table is where the BlackBox
         * controller is mounted, so movement of the gantry towards the BlackBox controller is
         * movement in the Y+ direction.
         * The X axis is movement along the gantry (single stepper motor).
         * 
         * The mounted MFD is turned 90 degrees clockwise relative to the X-Y table, so the
         * positions below cannot simply be added to the X and Y offsets from Home.  This is
         * because the nearest corner of the LCD is not the bottom left corner but the bottom
         * right corner (due to the 90 deg. rotation).
         */

        const double LCD_topViewingSpots    = LCD_height - LCD_marginVert;
        const double LCD_middleViewingSpots = LCD_height * 0.5;
        const double LCD_bottomViewingSpots = 0.0 + LCD_marginVert;

        const double LCD_leftViewingSpots   = 0.0 + LCD_marginHoriz;
        const double LCD_centerViewingSpots = LCD_width * 0.5;
        const double LCD_rightViewingSpots  = LCD_width - LCD_marginHoriz;

        public static XYPosition ACRO55_home = new XYPosition(0, 0);

        public XYPosition LCD_topLeftViewingSpot   = new XYPosition(LCD_leftViewingSpots,
                                                                    LCD_topViewingSpots);
        public XYPosition LCD_topCenterViewingSpot = new XYPosition(LCD_centerViewingSpots,
                                                                    LCD_topViewingSpots);
        public XYPosition LCD_topRightViewingSpot  = new XYPosition(LCD_rightViewingSpots,
                                                                    LCD_topViewingSpots);

        public XYPosition LCD_middleLeftViewingSpot   = new XYPosition(LCD_leftViewingSpots,
                                                                       LCD_middleViewingSpots);
        public XYPosition LCD_middleCenterViewingSpot = new XYPosition(LCD_centerViewingSpots,
                                                                       LCD_middleViewingSpots);
        public XYPosition LCD_middleRightViewingSpot  = new XYPosition(LCD_rightViewingSpots,
                                                                       LCD_middleViewingSpots);

        public XYPosition LCD_bottomLeftViewingSpot   = new XYPosition(LCD_leftViewingSpots,
                                                                       LCD_bottomViewingSpots);
        public XYPosition LCD_bottomCenterViewingSpot = new XYPosition(LCD_centerViewingSpots,
                                                                       LCD_bottomViewingSpots);
        public XYPosition LCD_bottomRightViewingSpot  = new XYPosition(LCD_rightViewingSpots,
                                                                       LCD_bottomViewingSpots);

        private INI_File _IniFile;
        private string _jogSize;
        private string _Movement;
        // Distance from chroma meter HOME position to viewing bottom right corner of LCD active area
        private XYPosition _offset_HomeToLCD = new XYPosition();

        private static SerialPort _serialPort;
        public static XYPosition _chromaMeterPosition;
        public static ManualResetEvent _manResetEvent = new ManualResetEvent(false);

        private string Movement
        {
            get
            {
                return _Movement;
            }
            set
            {
                if (value.Length >= 10 && value[0].CompareTo('<') == 0)
                {
                    int idxPipeChr = value.IndexOf("|");
                    _Movement = value.Substring(1, idxPipeChr - 1);
                }
                else
                {
                    _Movement = "";
                }
            }
        }

        public ACRO55(string iniFile)
        {
            try
            {
                _IniFile = new INI_File(iniFile);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show($"File, '{Path.GetFileName(e.FileName)}', could not be found.\n\n" +
                    $"Expected location: {Path.GetDirectoryName(e.FileName).Replace(" ", "")}\n\n\n" +
                    "Clicking OK will close app.", caption: "File Not Found");
                Environment.Exit(0);
            }

            InitializeComponent();
            _jogSize = "0.1";
            this.cboJogSize.SelectedIndexChanged -= new System.EventHandler(this.cboJogSize_SelectedIndexChanged);
            cboJogSize.SelectedItem = _jogSize + '\"';      // add inch marks to numerical string
            this.cboJogSize.SelectedIndexChanged += new System.EventHandler(this.cboJogSize_SelectedIndexChanged);

            GetHomeToLcdOffsets();
        }

        private void ACRO55_FormClosed(object sender, FormClosedEventArgs e)
        {
            _serialPort.Close();
        }

        private void ACRO55_Load(object sender, EventArgs e)
        {
            // All of the options for a serial device
            // can be sent through the constructor of the SerialPort class
            _serialPort = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            try
            {
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }

                btnConnectDisconnect.Text = "Disconnect";
                SoftReset(); 
                QueryBlackBoxPosition(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening serial port :: " + ex.Message, "Error Opening Port");
            }
        }

        private void GetHomeToLcdOffsets()
        {
            string sectionName = "[Home-to-MFD Offsets]";
            string key = null;

            try
            {
                key = "X";
                _offset_HomeToLCD.X = Convert.ToDouble(_IniFile.GetValue(sectionName, key));
                key = "Y";
                _offset_HomeToLCD.Y = Convert.ToDouble(_IniFile.GetValue(sectionName, key));
            }
            catch (FormatException)
            {
                MessageBox.Show($"Value has incorrect format in file: '{Path.GetFileName(_IniFile.FileName)}'\n" +
                    $"Section: {sectionName}, Key: {key}.\n\n" +
                    $"File location: {new FileInfo(_IniFile.FileName).DirectoryName.Replace(" ", "")}\n\n\n" +
                    "Clicking OK will close app.", caption: "Incorrect Format");
                Environment.Exit(0);
            }
        }

        public static void MoveToHomePosition()
        {
            // Move chroma meter to home position
            KillAlarmLock();
            _manResetEvent.Reset();
            GoToHomePosition();
            _manResetEvent.WaitOne();

            _chromaMeterPosition = new XYPosition(ACRO55_home);

            // In case this method is immediately followed by move-to-position,
            //    wait for thread to reenter the synchronization domain (MS Docs)
            Thread.Sleep(200);       // 15 ms works, 10 ms is too short
        }

        public void MoveToPosition(XYPosition desiredPosition)
        {//moves to center of viewing spot
            if (_chromaMeterPosition != desiredPosition)
            {
                if(desiredPosition == LCD_middleCenterViewingSpot)
                {
                    MoveToHomePosition();
                }
                _manResetEvent.Reset();
                GoToSpot(desiredPosition);
                _manResetEvent.WaitOne();

                _chromaMeterPosition = new XYPosition(desiredPosition);
            }
        }

        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);

        private void ProcessReceivedSerialData(string rawData)
        {
            string data = rawData.Trim();

            lstRxData.Items.Add(data);

            Movement = data;

            if (Movement.Equals("Run")  || Movement.Equals("Jog")  ||
                Movement.Equals("Idle") || Movement.Equals("Home") ||
                Movement.Equals("Alarm"))
            {
                UpdateXYPositionFields(data);
            }

            if ((data.Length == 2 && data.Equals("ok")) ||
                Movement.Equals("Run") || Movement.Equals("Jog"))
            {
                QueryBlackBoxPosition();
            }
            else if(Movement.Equals("Idle") || Movement.Equals("Home"))
            {
                _manResetEvent.Set();
            }
            else
            {
                _manResetEvent.Reset();
            }

            lstRxData.TopIndex = lstRxData.Items.Count - 1;
        }

        void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(200);
            string data;

            try
            {
                while (true)
                {
                    data = _serialPort.ReadLine();
                    BeginInvoke(new SetTextDeleg(ProcessReceivedSerialData), new object[] { data });
                }
            }
            catch (TimeoutException)
            {
            }
        }

        private void UpdateXYPositionFields(string message)
        {
            int idxFirstNum = message.IndexOf("WPos:") + "WPos:".Length;
            int idxFirstComma = message.IndexOf(',');
            int idxSecondComma = message.IndexOf(',', idxFirstComma + 1);

            txtXPosition.Text = message.Substring(idxFirstNum, idxFirstComma - idxFirstNum);
            txtYPosition.Text = message.Substring(idxFirstComma + 1, idxSecondComma - idxFirstComma - 1);
        }

        public static void GoToHomePosition() => Send("$H");

        public static void KillAlarmLock() => Send("$X");

        private void QueryBlackBoxPosition() => _serialPort.Write("?");

        private void SoftReset() => _serialPort.Write($"{ctrl_X}");

        public void CloseSerialPort() => _serialPort.Close();

        public static void Send(string text)
        {
            // Makes sure serial port is open before trying to write
            if (!_serialPort.IsOpen)
                MessageBox.Show("Serial port " + _serialPort.PortName + " is not open.\nClick OK, and then click the Connect button",
                    "Serial Port Not Open");
            else
                _serialPort.WriteLine(text);
        }

        public XYPosition SwapXY(XYPosition spot, double xWidth, XYPosition offsetFromHome)
        {
            var xyTableCoords = new XYPosition
            {
                X = offsetFromHome.X + spot.Y,
                Y = offsetFromHome.Y + (xWidth - spot.X)
            };

            return xyTableCoords;
        }

        public void GoToSpot(XYPosition spot)
        {
            XYPosition ACRO55_coords = SwapXY(spot, LCD_width, _offset_HomeToLCD);

            string xCoord, yCoord;
            xCoord = Convert.ToString(ACRO55_coords.X);
            yCoord = Convert.ToString(ACRO55_coords.Y);

            Send($"G90 G20 X{xCoord} Y{yCoord}");
        }


        //*********************************************************************
        //                               Events
        //*********************************************************************

        private void cboJogSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            _jogSize = cboJogSize.Text.Substring(0, cboJogSize.Text.Length - 1);
        }


        //*********************************************************************
        //                         Serial Port Buttons
        //*********************************************************************

        private void btnConnectDisconnect_Click(object sender, EventArgs e)
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
                btnConnectDisconnect.Text = "Disconnect";
                txtTxData.Focus();
            }
            else
            {
                _serialPort.Close();
                btnConnectDisconnect.Text = "Connect";
            }
        }

        private void btnSend_Click(object sender, EventArgs e) => Send(txtTxData.Text);

        private void btnClearRxData_Click(object sender, EventArgs e) => lstRxData.Items.Clear();


        //*********************************************************************
        //                             Jog Buttons
        //*********************************************************************

        // The MFD is turned 90 degrees clockwise relative to the ACRO55 X-Y table
        // above it.  That means that in order to move vertically, up the MFD
        // (Y+ direction) the ACRO55 must move in its X+ direction.  To move
        // horizontally, left-to-right, across the MFD (X+ direction) the ACRO55
        // must move downward in its Y- direction.

        private void btnXplus_Click(object sender, EventArgs e)
        {
            Send("$J = G91 G20" + "Y-" + _jogSize + "F200");
        }

        private void btnXminus_Click(object sender, EventArgs e)
        {
            Send("$J = G91 G20" + "Y" + _jogSize + "F200");
        }

        private void btnYplus_Click(object sender, EventArgs e)
        {
            Send("$J = G91 G20" + "X" + _jogSize + "F200");
        }

        private void btnYminus_Click(object sender, EventArgs e)
        {
            Send("$J = G91 G20" + "X-" + _jogSize + "F200");
        }


        //*********************************************************************
        //                        MFD Position Buttons
        //*********************************************************************

        private void btnBottomLeft_Click(object sender, EventArgs e)
        {
            GoToSpot(LCD_bottomLeftViewingSpot);
        }

        private void btnBottomRight_Click(object sender, EventArgs e)
        {
            GoToSpot(LCD_bottomRightViewingSpot);
        }

        private void btnMiddleCenter_Click(object sender, EventArgs e)
        {
            GoToSpot(LCD_middleCenterViewingSpot);
        }

        private void btnTopLeft_Click(object sender, EventArgs e)
        {
            GoToSpot(LCD_topLeftViewingSpot);
        }

        private void btnTopRight_Click(object sender, EventArgs e)
        {
            GoToSpot(LCD_topRightViewingSpot);
        }


        //*********************************************************************
        //                            Other Buttons
        //*********************************************************************

        private void btnQueryPosition_Click(object sender, EventArgs e)
        {
            QueryBlackBoxPosition();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MoveToHomePosition();
            //KillAlarmLock();
            //GoToHomePosition();
        }

        private void btnClearAlarm_Click(object sender, EventArgs e)
        {
            KillAlarmLock();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            SoftReset();
        }
    }
}