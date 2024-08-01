using System;
using System.Linq; 
using System.Windows.Forms;

namespace CIGALHE.MFD.Optical
{
    public partial class TestInfoForm : Form
    {
        public TestInfoForm(MFD_Optical mainForm)
        {
            InitializeComponent();
            txtUserName.Text = mainForm.lblOperatorName.Text;
            cmboPartNo.SelectedText = mainForm.lblUUTPartNo.Text;   // currently this line does nothing
            txtSerialNo.Text = mainForm.lblUUTSerialNo.Text;
        }

        private void TestInfoForm_Load(object sender, EventArgs e)
        {
            cmboPartNo.Items.Add("MB0808C-21");
            cmboPartNo.Items.Add("MB0808T-01");
            cmboPartNo.Items.Add("850054-000598");
            cmboPartNo.Items.Add("850054-002101");
            cmboPartNo.Items.Add("MB1690A-20");
            cmboPartNo.Items.Add("MB1690A-10");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Operator name cannot be blank", "Operator Name");
                txtUserName.Focus();
                return;
            }

            char[] separators = new char[] { ' ', ',', '.', '<', '>', ':', ';', '/' };
            string[] names = txtUserName.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (IsNameFormatCorrect(names) == false)
            {
                txtUserName.Focus();
                return;
            }

            // Recombine first and last names with correct capitalization
            if (names.Length == 2)
            {
                txtUserName.Text = CapitalizeFirstLetterOnly(names[0]) + " " +
                                   CapitalizeFirstLetterOnly(names[1]);
            }
            else if (names.Length == 3)  // for last names such as Van Halen and Bon Jovi
            {
                txtUserName.Text = CapitalizeFirstLetterOnly(names[0]) + " " +
                                   CapitalizeFirstLetterOnly(names[1]) + " " +
                                   CapitalizeFirstLetterOnly(names[2]);
            }

            if (cmboPartNo.Text == "")
            {
                MessageBox.Show("Part number cannot be blank", "UUT Part Number");
                cmboPartNo.Focus();
                return;
            }

            if (txtSerialNo.Text == "")
            {
                MessageBox.Show("Serial number cannot be blank", "UUT Serial Number");
                txtSerialNo.Focus();
                return;
            }

            if (IsSerialNumberValid() == false)
            {
                txtSerialNo.Focus();
                txtSerialNo.SelectionLength = 0;    // prevents blue highlighting of S/N text
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private string CapitalizeFirstLetterOnly(string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
        }

        private bool IsNameFormatCorrect(string[] names)
        {
            if (names.Length == 0)
            {
                MessageBox.Show("No name was entered.", "Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (names.Length == 1)
            {
                MessageBox.Show("Enter both a first name and a last name.", "Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (names.Length == 2)
            {
                // Check whether first or last initial --with or without period-- was entered
                if (names[0].Length == 1 || names[0][1] == '.' ||
                    names[1].Length == 1 || names[1][1] == '.')
                {
                    MessageBox.Show("Enter full first name and last name.  Do not use initials.", "Name",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    // Name format is correct
                    return true;
                }
            }
            else if (names.Length == 3)
            {
                // Two-part last names (Van Halen, Bon Jovi) are allowed, initials are not.
                if (names[0].Length == 1 || names[0][1] == '.' ||
                    names[1].Length == 1 || names[1][1] == '.' ||
                    names[2].Length == 1 || names[2][1] == '.')
                {
                    MessageBox.Show("Enter full first name and last name.  Do not use initials.", "Name",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    // Name format is correct
                    return true;
                }
            }
            else // (names.Length > 3)
            {
                MessageBox.Show("Enter first name and last name only.", "Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool IsSerialNumberValid()
        {
            string strSN = txtSerialNo.Text;
            string strPN = cmboPartNo.Text;
            int intSerialNo;

            bool firstLetterU = strSN[0] == 'U' || strSN[0] == 'u';
            int serialNoBegin = firstLetterU ? 1 : 0;
            bool success = int.TryParse(strSN.Substring(serialNoBegin), out intSerialNo);
            if (success)
            {
                if (strPN == "850054-002101")
                {
                    if (100 <= intSerialNo && intSerialNo <= 9999)
                    {
                        txtSerialNo.Text = (intSerialNo < 1000 ? "U0" : "U") + intSerialNo.ToString();
                        if (!firstLetterU)
                        {
                            MessageBox.Show("For this part number, " + strPN +
                                            ", a 'U' has been prepended to the serial number.\n\n" +
                                            "(Move or close this popup to see the corrected S/N.)", "UUT Serial Number");
                            firstLetterU = true;
                            return false;   // Although S/N is now valid, this is to force user to click the Accept button again in the dialog
                        }
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Serial number should in the range 100 to 9999", "Serial Number Out of Range");
                        return false;
                    }
                }
                else if (strPN == "MB0808C-21" || strPN == "850054-000598" || strPN == "MB0808T-01")
                {
                    if (0 <= intSerialNo && intSerialNo <= 9999)
                    {
                        txtSerialNo.Text = intSerialNo.ToString().PadLeft(4, '0');
                        if (firstLetterU)
                        {
                            MessageBox.Show("Serial number cannot begin with a 'U'.  It has been removed.\n\n" +
                                            "(Move or close this popup to see the corrected S/N.)", "UUT Serial Number");
                            firstLetterU = false;
                            return false;   // Although S/N is now valid, this is to force user to click the Accept button again in the dialog
                        }
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Serial number should in the range 0 to 9999", "Serial Number Out of Range");
                        return false;
                    }
                }
                else if (strPN == "MB1690A-20" || strPN == "MB1690A-10")
                {
                    string intSerialNoString = intSerialNo.ToString("D4"); // Format the integer to a 4-digit string with leading zeros

                    if (intSerialNoString.Length == 4)
                    {
                        bool isNumeric = true;
                        foreach (char c in intSerialNoString)
                        {
                            if (!char.IsDigit(c))
                            {
                                isNumeric = false;
                                break;
                            }
                        }

                        if (isNumeric)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Serial number should only contain numbers", "Incorrect Serial Number Format");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Serial number should only contain four digit numbers", "Incorrect Serial Number Format");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid part number: " + strPN, "UUT Part Number");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Invalid serial number: " + strSN, "UUT Serial Number");
                return false;
            }
        }

    }
}
