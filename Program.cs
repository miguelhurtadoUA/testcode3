using System;
using System.Windows.Forms;
using CS.Libraries.Forms.Prompts;

namespace CIGALHE.MFD.Optical
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Popup.Show("Turn on the following three pieces of equipment\n" +
                       "in the order listed:\n" +
                       "     1. POWER SUPPLY to Blackbox Controller,\n" +
                       "     2. Blackbox Controller,\n" +
                       "     3. CS-200 Chroma Meter\n\n" +
                       "Do NOT turn on the MFD POWER SUPPLY at this time.",
                        title: "Equipment Power-up");
            Application.Run(new MFD_Optical());
        }
    }
}
