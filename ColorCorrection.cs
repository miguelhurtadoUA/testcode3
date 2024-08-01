using System;
using System.IO;
using System.Windows.Forms;
using CS.Libraries.File.Initialization;
using ChromaMeter;
using MFD_Optical;

namespace CIGALHE.MFD.Optical
{
    public class ColorCorrection
    {
        private INI_File _IniFile;

        public ColorCorrection(INI_File IniFile)
        {
            _IniFile = IniFile;
        }

        public LightReading AdjustColor(MFD_Optical.TestColor testColor, LightReading lightReading)
        {
            double uAdjustment = 0, vAdjustment = 0;
            string partNumber = SharedData.Instance.PartNumber;

            // TestColor is an enum with values such as 'blue_Day' and 'yellow_NVG'.
            // This section breaks a TestColor value into two strings: 'color' and 'dayNVG'.
            string colorPlusMode = testColor.ToString();
            int len = colorPlusMode.Length;
            string color = colorPlusMode.Substring(0, len - 4); // string splitting
            string dayNVG = colorPlusMode.Substring(len - 3, 3); // string splitting

            // Need to add in the extra part# heading then follow with the color correction offsets
            string sectionName = $"Color Correction, {color}, {dayNVG}";
            string key = null;

            try
            {
                key = "u'";
                uAdjustment = Convert.ToDouble(_IniFile.GetValue(partNumber, sectionName, key));
                key = "v'";
                vAdjustment = Convert.ToDouble(_IniFile.GetValue(partNumber, sectionName, key));
            }
            catch
            {
                MessageBox.Show("Failed to read Color Correction offset\n" +
                    $"from INI file: '{Path.GetFileName(_IniFile.FileName)}'\n" +
                    $"Section: {sectionName}, Key: {key}.\n\n" +
                    $"File location: {new FileInfo(_IniFile.FileName).DirectoryName.Replace(" ", "")}\n\n\n" +
                    "Clicking OK will close app.", "INI File Error");
                Environment.Exit(0);
            }

            return new LightReading(lightReading.Lv, lightReading.UPrime + uAdjustment, lightReading.VPrime + vAdjustment);
        }
    }
}
