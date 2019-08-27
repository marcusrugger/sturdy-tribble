using System;

namespace SturdyTribble.Primitive
{
    public class Algorithms
    {
        public static double ToRadians(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        public static double ToDegrees(double radians)
        {
            return 180.0 * radians / Math.PI;
        }

        public static double SafeAtan(PointDouble p)
        {
            if (Math.Abs(p.X) > 1e-9)
                return AtanByQuadrant(p);
            else
                return AtanPointOnYAxis(p);
        }

        private static double AtanByQuadrant(PointDouble p)
        {
            double result = Math.Atan(p.Y / p.X);

            if (p.X < 0.0)
                result += Math.PI;
            else if (p.Y < 0.0)
                result += 2 * Math.PI;

            return result;
        }

        private static double AtanPointOnYAxis(PointDouble p)
        {
            if (p.Y >= 0.0)
                return Math.PI / 2.0;
            else
                return 3.0 * Math.PI / 2.0;
        }
    }
}
