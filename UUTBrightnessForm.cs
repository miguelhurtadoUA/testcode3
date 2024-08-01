using System;
using System.Windows.Forms;
using ChromaMeter;

namespace CIGALHE.MFD.Optical
{
    internal partial class UUTBrightnessForm : Form
    {
        CS200 _chromaMeter;

        public UUTBrightnessForm(CS200 chromameter, double lowerLimit, double upperLimit)
        {
            _chromaMeter = chromameter;
            InitializeComponent();
            this.lblInstructions.Text = String.Format("On the UUT, press the LUM+/- bezel button\n" +
                                                      "   until the brightness reading displayed below\n" +
                                                      "   is between {0} and {1} fL.", lowerLimit, upperLimit);
        }

        private void UUTBrightnessForm_Load(object sender, EventArgs e)
        {
        }

        private void btnUpdateReading_Click(object sender, EventArgs e)
        {
            // Prevent exit while chroma meter is taking measurement
            btnExit.Enabled = false;

            btnUpdateReading.Text = "Taking a\nreading...";
            btnUpdateReading.Refresh();
            lblBrightnessValue.Enabled = false;

            _chromaMeter.SetMeasurementSpeed(CS200.MeasurementSpeed.Fast);
            LightReading lightReading = _chromaMeter.TakeMeasurement();
            lblBrightnessValue.Text = lightReading.Lv.ToString();
            lblBrightnessValue.Enabled = true;

            btnUpdateReading.Text = "Click Here to\nUpdate Reading";
            btnExit.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _chromaMeter.SetMeasurementSpeed(CS200.MeasurementSpeed.Auto);
            DialogResult = DialogResult.OK;
        }
    }
}
