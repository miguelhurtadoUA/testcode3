namespace CIGALHE.MFD.Optical
{
    public partial class MFD_Optical
    {
        // Enumerations
        public enum TestColor
        {
            Black_Day, Red_Day, Green_Day, Blue_Day, White_Day, Black_NVG, Red_NVG, Yellow_NVG, White_NVG
        }

        public enum Mode
        {
            Day, Night, NVG
        }

        private enum Position
        {
            Home, MiddleCenter
        }

        private enum Power
        {
            OFF, ON
        }

        private enum TiltTableAngle
        {
            Normal, NormalToUser, Other
        }

        // File and Folder Names
        const string IMAGES_FOLDER    = "Images";
        const string RESOURCES_FOLDER = @".\Resources";
        const string INIFILENAME      = "MFD_OpticalTest.ini";
        const string INIFILE          = RESOURCES_FOLDER + "\\" + INIFILENAME;


        // Results Headings
        const string ResultsHeaderIndent       = "                          ";
        const string CalculatedResultHeader    = "{0,-8}    Lower Limit    Upper Limit    Units    Status";
        const string MeasurementHeader         = "Received    Lower Limit    Upper Limit    Units    Status";
        const string ReceivedExpectedHeader    = "Received          Expected           Units         Status";
        const string UpperLimitOnlyHeader      = "Received         Upper Limit         Units         Status";
        const string LowerLimitOnlyHeader      = "Received         Lower Limit         Units         Status";
        const string ScratchesLengthsHeader    = "Received    Total Length Allowed     Units         Status";
        const string MaximumAllowedHeader      = "Received       Maximum Allowed       Units         Status";

        // Results Formats
        const string OperatorResponseFormat     = "      Operator response:    {0,-3}               {1,-3}               {2,3}           {3,4}";
        const string ChromaPointStatusFormat    = "      {0,-18}    {1,-4}              {2,-4}              ---           {3,-4}";
        const string ScratchesLengthsFormat     = "      {0,-19}   {1,3}                {2,2}               {3,-4}          {4}";
        const string BlemishesCountsFormat      = "      {0,-19}   {1,3}                {2,2}              {3,-4}           {4}";
        const string FailedPixelCountsFormat    = "      {0,-19}   {1,3}                {2,2}              {3,-8}       {4}";
        const string FailedNearEachOtherFormat  = "      {0,-18}     {1,-3}               {2,-3}             {3,-8}       {4}";
        const string MeasurementFormatInt       = "      {0,-18}    {1,3:d}           {2,3:d}            {3,3:d}         {4,-3}      {5}";
        const string MeasurementFormatDbl1Int   = "      {0,-18}    {1,5:f1}        {2,4:d}           {3,4:d}         {4,-3}      {5}";
        const string MeasurementFormatDbl2Int   = "      {0,-18}    {1,4:f2}         {2,4:d}           {3,4:d}         {4,-3}      {5}";
        const string MeasurementFormatDbl2      = "      {0,-18}    {1,4:f2}         {2,4:f2}           {3,4:f2}         {4,-3}      {5}";
        const string MeasurementFormatDbl3      = "      {0,-18}    {1,5:f3}        {2,5:f3}          {3,5:f3}        {4,-3}      {5}";
        const string MeasurementLowerLimitDbl1Int   = "      {0,-18}    {1,5:f1}              {2,3:d}              {3,-3}           {4}";
        const string MeasurementUpperLimitDbl3Dbl3  = "      {0,-18}    {1,5:f3}             {2,5:f3}             {3,-3}           {4}";
        const string MeasurementUpperLimitInt       = "      {0,-18}    {1,3:d}                {2,3:d}              {3,-3}           {4}";

        // Test Header/Footer
        const string HeaderFooterTopBorder      = "|---------------------------------------------------------------------------------|";
        const string HeaderFooterHorizBorder    = "|----------------------------------------|----------------------------------------|";
        const string HeaderFooterTitleSeparator = "|=================================================================================|";
        const string HeaderFooterTitle          = "                  CIGALHE MFD Optical Tests - General Information                  ";
        const string FooterPartialATPLine       = "                           Partial ATP was run by user                           ";
        const string HeaderFooterLineItemFormat = "| {0,-38} | {1,-38} |\n";
        const string FooterLeftHandFormat       = "| {0,-38} |";
        const string FooterRightHandFormat      = " {0,-38} ";

        // Chromaticity Table
        const string ChromaTableIndent        = "  ";
        const string ChromaTableHorizBorder   = "|-------------------------------------------------------------------------------|";
        const string ChromaTableTitle         = "|                              Chromaticity Table                               |";
        const string ChromaTableHeadings1st   = "|  Color   |         Expected           |          Received          |  Status  |";
        const string ChromaTableHeadings2nd   = "|          |    U'       V'      Dev    |     U'       V'      Dev   |          |";
        const string ChromaTableWhiteFormat   = "|  {0,-6}  |  -.---    -.---    -.---   |   {1,5:f3}    {2,5:f3}    -.---  |   ----   |";
        const string ChromaTableColorFormat   = "|  {0,-6}  |  {1,5:f3}    {2,5:f3}    {3,5:f3}   |   {4,5:f3}    {5,5:f3}    {6,5:f3}  |   {7}   |";

        // Tables of Readings
        const string ReadingsTableIndent              = "          ";
        const string ReadingsTableHorizBorder         = "|-------------------|-------------------|-------------------|";
        const string ReadingsTableEmptyRow            = "|                   |                   |                   |";
        const string ReadingsTableCellLabelsFormat    = "| {0,-17} | {1,-17} | {2,-17} |";
        const string ReadingsTableThreeReadingsFormat = "|       {0,6:f2}      |       {1,6:f2}      |       {2,6:f2}      |";

        // ATP Report Summary
        const string ATPSummaryHorizBorder    = "|---------------------------------------------------|--------------|--------------|";
        const string ATPSummaryHorizSeparator = "|===================================================|==============|==============|";
        const string ATPSummaryTitle          = "                                ATP REPORT SUMMARY                                 ";
        const string ATPSummaryColumnHeadings = "|                       Test                        |    Status    |   Failures   |";
        const string TaskDescriptionFormat    = " {0, -42}        ";
        const string PassFailTallyFormat1     = "|   {0,-4} {1,-40}   |";
        const string PassFailTallyFormat2     = "     {0,-4}     ";
        const string PassFailTallyFormat3     = "{0,8}      ";

        const string PopupPromptTiltTableNormal       = "Set tilt table to 0 degrees horizontal and 0 degrees vertical";
        const string PopupPromptTiltTableNormalToUser = "Set tilt table normal to operator using wedge labeled, \"VERTICAL TILT SPACER\".\n\n" +
                                                        "          (Click blue Help button at upper right to view step-by-step instructions.)";
        const string PopupTitleTiltTable              = "Tilt Table";
        const string PopupTitleTiltTableNormal        = "Tilt Table Normal to Chroma Meter";
        const string PopupTitleTiltTableNormalToUser  = "Tilt Table Normal to User";

        const int MaximumLightScratchesSmudges      =  0;
        const int MediumScratchesTotalLengthMaximum = 15;
        const int HeavyScratchesTotalLengthMaximum  =  0;

        const int LargeBlemishesMaximum  =  0;
        const int MediumBlemishesMaximum = 10;
        //        MaximumSmallBlemishes  = no limit;

        const int PixelsStuckOffMaximum            = 24;
        const int PixelsStuckOnMaximum             = 14;
        const int MaximumPixelFailuresWithin10mm   =  0;
        const int Failed2PixelClustersMaximum      = 10;
        const int Failed3To5PixelClusterMaximum    =  3;
        const int MaximumClusterFailuresWithin30mm =  0;

        const int ContrastRatioLowerLimit =  20; // Same for both displays 
        const int ContrastRatioUpperLimit = 350; // Rose has upper limit of 1000
        const int ContrastRatioUpperLimitRose = 1000; 

        const int BrightnessDayNormalMaxLowerLimit    = 240; // should be same for Rose, MFD only uses the lower value 
        const int BrightnessDayNormalMaxUpperLimit    = 450; // Rose same as MFD just absent in the CIGAHLE ATP, max value never used for MFD 
        const int BrightnessDayNormalMedLowerLimit    =  80;
        const int BrightnessDayNormalMedUpperLimit    = 120;
        const double BrightnessDayNormalMinLowerLimit = 0.00;
        const double BrightnessDayNormalMinUpperLimit = 0.10;
        const int BrightnessDayNonNormalMaxLowerLimit = 152;
        const int BrightnessDayNonNormalMaxUpperLimit = 450;

        const int BrightnessNVGMaxLowerLimit    =  3;
        const int BrightnessNVGMaxUpperLimit    = 25;
        const double BrightnessNVGMedLowerLimit = 0.48;
        const double BrightnessNVGMedUpperLimit = 0.72;
        const double BrightnessNVGMinLowerLimit = 0.00;
        const double BrightnessNVGMinUpperLimit = 0.03;

        const double LuminanceHomogeneityLowerLimitRose = 0.60; //for Rose
        const double LuminanceHomogeneityLowerLimit = 0.70; 
        const double LuminanceHomogeneityUpperLimit = 1.00; // Same for Rose

        const double DayRedUPrime   = 0.445;
        const double DayRedVPrime   = 0.525;
        const double DayGreenUPrime = 0.130;
        const double DayGreenVPrime = 0.572;
        const double DayBlueUPrime  = 0.150;
        const double DayBlueVPrime  = 0.237;

        const double NVGRedUPrime    = 0.450;
        const double NVGRedVPrime    = 0.550;
        const double NVGYellowUPrime = 0.274;
        const double NVGYellowVPrime = 0.622;

        const double ColorRadiusDayRedLowerLimit   = 0.000;
        const double ColorRadiusDayRedUpperLimit   = 0.030;
        const double ColorRadiusDayGreenLowerLimit = 0.000;
        const double ColorRadiusDayGreenUpperLimit = 0.030;
        const double ColorRadiusDayBlueLowerLimit  = 0.000;
        const double ColorRadiusDayBlueUpperLimit  = 0.045;

        const double ColorRadiusNVGRedLowerLimit    = 0.000;
        const double ColorRadiusNVGRedUpperLimit    = 0.070;
        const double ColorRadiusNVGYellowLowerLimit = 0.000;
        const double ColorRadiusNVGYellowUpperLimit = 0.093;

        const double ChromaUniformityRedLowerLimit   = 0.000;
        const double ChromaUniformityRedUpperLimit   = 0.020;
        const double ChromaUniformityGreenLowerLimit = 0.000;
        const double ChromaUniformityGreenUpperLimit = 0.020;
        const double ChromaUniformityWhiteLowerLimit = 0.000;
        const double ChromaUniformityWhiteUpperLimit = 0.020;
        const double ChromaUniformityBlueLowerLimit  = 0.000;
        const double ChromaUniformityBlueUpperLimit  = 0.035;
    }
}
