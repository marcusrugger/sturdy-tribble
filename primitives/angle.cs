using System;

namespace SturdyTribble.Primitive
{
    public struct Angle
    {
        public const double Pi = Math.PI;
        public const double Tau = 2 * Math.PI;
        private double _turns;

        public static Angle FromTurns(double turns)
            => new Angle(turns);

        public static Angle FromRadians(double radians)
            => new Angle(radians / Tau);

        public static Angle FromDegrees(double degrees)
            => new Angle(degrees / 360.0);

        public static Angle FromGradians(double gradians)
            => new Angle(gradians / 400.0);

        private Angle(double turns) { _turns = turns; }

        public static Angle operator +(Angle a, Angle b) => new Angle(a._turns + b._turns);
        public static Angle operator -(Angle a, Angle b) => new Angle(a._turns - b._turns);

        public override string ToString() => _turns.ToString();

        public double Turns => _turns;
        public double Radians => Tau * _turns;
        public double Degrees => 360.0 * _turns;
        public double Gradians => 400.0 * _turns;

        public double Sin => Math.Sin(Radians);
        public double Cos => Math.Cos(Radians);
        public double Tan => Math.Tan(Radians);

        public static Angle Asin(double sin) => FromRadians(Math.Asin(sin));
        public static Angle Acos(double cos) => FromRadians(Math.Acos(cos));
        public static Angle Atan(double tan) => FromRadians(Math.Atan(tan));

        public static Angle Atan2(double y, double x) => FromRadians(Math.Atan2(y, x));
    }
}
