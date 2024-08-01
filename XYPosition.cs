namespace XYPositionSystem
{
    public class XYPosition
    {
        public XYPosition()
        {
        }

        public XYPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        public XYPosition(XYPosition position)
        {
            X = position.X;
            Y = position.Y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public static bool operator ==(XYPosition pt1, XYPosition pt2)
        {
            if (object.Equals(pt1, null))
                if (object.Equals(pt2, null))
                    return true;
                else return false;
            else
                return pt1.Equals(pt2);
        }

        public static bool operator !=(XYPosition pt1, XYPosition pt2) => !(pt1 == pt2);

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            XYPosition p = (XYPosition)obj;
            return X == p.X && Y == p.Y;
        }

        public override int GetHashCode()
        {
            string hashString = (X * 10000).ToString() + (Y * 10000).ToString();
            return hashString.GetHashCode();
        }
    }
}
