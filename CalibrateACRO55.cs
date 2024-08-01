using System;
using System.Linq;
using System.Windows.Forms;

namespace XYPositionSystem
{
    public partial class CalibrateACRO55 : Form
    {
        XYPosition _currentPosition = new XYPosition(0, 0);
        XYPosition _positionTopLeft, _positionTopRight, _positionBottomLeft, _positionBottomRight;
        double _jogSize    = 0;

        public CalibrateACRO55()
        {
            InitializeComponent();
            foreach (RadioButton radioButton in grpJogIncrement.Controls)
            {
                if (radioButton.Checked)
                {
                    _jogSize = Convert.ToDouble(radioButton.Text.Trim('"'));
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                HandlePreviewKeyDownForAllControls(this.Controls);
            }
            ACRO55.KillAlarmLock();
        }

        private void HandlePreviewKeyDownForAllControls(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Control control in cc)
                {
                    control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
                    HandlePreviewKeyDownForAllControls(control.Controls);
                }
            }
        }

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                case Keys.Tab:
                    e.IsInputKey = true;
                    break;
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    ACRO55.Send("$J = G91 G20" + "X" + _jogSize + "F200");
                    _currentPosition.Y += _jogSize;
                    lblYPos.Text = _currentPosition.Y.ToString("f2");
                    break;
                case Keys.Down:
                    ACRO55.Send("$J = G91 G20" + "X-" + _jogSize + "F200");
                    _currentPosition.Y -= _jogSize;
                    lblYPos.Text = _currentPosition.Y.ToString("f2");
                    break;
                case Keys.Left:
                    ACRO55.Send("$J = G91 G20" + "Y" + _jogSize + "F200");
                    _currentPosition.X -= _jogSize;
                    lblXPos.Text = _currentPosition.X.ToString("f2");
                    break;
                case Keys.Right:
                    ACRO55.Send("$J = G91 G20" + "Y-" + _jogSize + "F200");
                    _currentPosition.X += _jogSize;
                    lblXPos.Text = _currentPosition.X.ToString("f2");
                    break;
                case Keys.I:
                    if (e.Alt)
                    {
                        NextJogIncrement();
                    }
                    break;
                default:
                    break;
            }
        }

        private void NextJogIncrement()
        {
            var rads = grpJogIncrement.Controls.OfType<RadioButton>();    // get all radioButtons in group

            rads = rads.OrderBy(r => r.Left);                             // sort radio buttons

            // find checked radio button and set checked for next one
            for (int i = 0; i < rads.Count(); i++)
            {
                if (rads.ElementAt(i).Checked)
                {
                    int idx = i;

                    if (idx == rads.Count() - 1)
                    {
                        idx = 0;
                    }
                    else
                    {
                        idx++;
                    }

                    rads.ElementAt(idx).Checked = true;

                    for (int j = 0; j < idx+1; j++)
                    {
                        Console.Beep(1000, 400);
                    }

                    return;
                }
            }
        }


        //*********************************************************************
        //                X-Y Position, Keyboard Arrow Buttons
        //*********************************************************************
        // The MFD is turned 90 degrees clockwise relative to the ACRO55 X-Y table
        // above it.  That means that in order to move vertically, up the MFD
        // (Y+ direction) the ACRO55 must move in its X+ direction.  To move
        // horizontally, left-to-right, across the MFD (X+ direction) the ACRO55
        // must move in its Y- direction.

        private void btnXPlus_Click(object sender, EventArgs e)
        {
            ACRO55.Send("$J = G91 G20" + "Y-" + _jogSize + "F200");
            _currentPosition.X += _jogSize;
            lblXPos.Text = _currentPosition.X.ToString("f2");
        }

        private void btnXMinus_Click(object sender, EventArgs e)
        {
            ACRO55.Send("$J = G91 G20" + "Y" + _jogSize + "F200");
            _currentPosition.X -= _jogSize;
            lblXPos.Text = _currentPosition.X.ToString("f2");
        }

        private void btnYPlus_Click(object sender, EventArgs e)
        {
            ACRO55.Send("$J = G91 G20" + "X" + _jogSize + "F200");
            _currentPosition.Y += _jogSize;
            lblYPos.Text = _currentPosition.Y.ToString("f2");
        }

        private void btnYMinus_Click(object sender, EventArgs e)
        {
            ACRO55.Send("$J = G91 G20" + "X-" + _jogSize + "F200");
            _currentPosition.Y -= _jogSize;
            lblYPos.Text = _currentPosition.Y.ToString("f2");
        }


        //*********************************************************************
        //                        Save-Position Buttons
        //*********************************************************************

        private void btnSavePositionTopLeft_Click(object sender, EventArgs e)
        {
            _positionTopLeft = new XYPosition(_currentPosition.X, _currentPosition.Y);
        }

        private void btnSavePositionTopRight_Click(object sender, EventArgs e)
        {
            _positionTopRight = new XYPosition(_currentPosition.X, _currentPosition.Y);
        }

        private void btnSavePositionBottomLeft_Click(object sender, EventArgs e)
        {
            _positionBottomLeft = new XYPosition(_currentPosition.X, _currentPosition.Y);
        }

        private void btnSavePositionBottomRight_Click(object sender, EventArgs e)
        {
            _positionBottomRight = new XYPosition(_currentPosition.X, _currentPosition.Y);
        }


        //*********************************************************************
        //                    Jog Increment, Radio Buttons
        //*********************************************************************

        private void rdoJogInch_CheckedChanged(object sender, EventArgs e)
        {
            _jogSize = Convert.ToDouble(((RadioButton)sender).Text.Trim('"'));
        }

        private void rdoJogTenth_CheckedChanged(object sender, EventArgs e)
        {
            _jogSize = Convert.ToDouble(((RadioButton)sender).Text.Trim('"'));
        }

        private void rdoJogHundredth_CheckedChanged(object sender, EventArgs e)
        {
            _jogSize = Convert.ToDouble(((RadioButton)sender).Text.Trim('"'));
        }


        //*********************************************************************
        //                             Exit Button
        //*********************************************************************

        private void btnExit_Click(object sender, EventArgs e) => Close();


        //*********************************************************************
        //                             Home Button
        //*********************************************************************

        private void btnHome_Click(object sender, EventArgs e)
        {
            //ACRO55.MoveToHomePosition();
            ACRO55.KillAlarmLock();
            ACRO55.GoToHomePosition();
            ACRO55._chromaMeterPosition = new XYPosition(ACRO55.ACRO55_home);
        }
    }
}
