using XYPositionSystem;

namespace CIGALHE.MFD.Optical
{
    public class LCDTestSpot
    {
        public string _testPoint;       // example: "#5"
        public XYPosition _position;

        private LCDTestSpot()
        {

        }

        public LCDTestSpot(string testPoint, XYPosition position)
        {
            _testPoint = testPoint;
            _position = position;
        }
    }
}
