using System;
using System.Windows.Forms;

namespace CIGALHE.MFD.Optical
{
    internal partial class ScratchesForm : Form
    {
        public ScratchesForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
