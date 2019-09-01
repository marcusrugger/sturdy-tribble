using System;

namespace SturdyTribble.Primitive
{
    public class Algorithms
    {
        public static double ToRadians(double degrees)
            => Math.PI * degrees / 180.0;

        public static double ToDegrees(double radians)
            => 180.0 * radians / Math.PI;

        public static double PythagoreanTheorem(double x, double y)
            => Math.Sqrt(x * x + y * y);

        public static double PythagoreanTheorem(PointDouble p)
            => PythagoreanTheorem(p.X, p.Y);

        public static double SafeAtan(PointDouble p)
            => Math.Abs(p.X) < 1e-9 ? AtanPointOnYAxis(p) : AtanByQuadrant(p);

        private static double AtanPointOnYAxis(PointDouble p)
            => p.Y >= 0.0 ? Math.PI / 2.0 : 3.0 * Math.PI / 2.0;

        private static double AtanByQuadrant(PointDouble p)
        {
            double result = Math.Atan(p.Y / p.X);

            if (p.X < 0.0)
                result += Math.PI;
            else if (p.Y < 0.0)
                result += 2 * Math.PI;

            return result;
        }

        public static Angle SumForA(PointPolar a, PointPolar b)
            => a.A + Angle.Atan2(b.R * (b.A - a.A).Sin, a.R + b.R * (b.A - a.A).Cos);

        public static double SumForR(PointPolar a, PointPolar b)
            => Math.Sqrt(a.R * a.R + b.R * b.R + 2 * a.R * b.R * (b.A - a.A).Cos);
    }
}
