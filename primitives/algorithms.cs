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
            => PythagoreanTheorem(p.x, p.y);

        public static Angle SumForA(PointPolar a, PointPolar b)
            => a.a + Angle.Atan2(b.r * (b.a - a.a).Sin, a.r + b.r * (b.a - a.a).Cos);

        public static double SumForR(PointPolar a, PointPolar b)
            => Math.Sqrt(a.r * a.r + b.r * b.r + 2 * a.r * b.r * (b.a - a.a).Cos);
    }
}
