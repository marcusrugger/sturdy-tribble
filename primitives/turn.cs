using System;

namespace SturdyTribble.Primitive
{
    public class Turn
    {
        public const double Pi = Math.PI;
        public const double Tau = 2 * Math.PI;
        private double _turns;

        public static Turn FromTurns(double turns)
        {
            return new Turn(turns);
        }

        public static Turn FromRadians(double radians)
        {
            return new Turn(radians / Tau);
        }

        public static Turn FromDegrees(double degrees)
        {
            return new Turn(degrees / 360.0);
        }

        private Turn(double turns) { _turns = turns; }

        public static Turn operator +(Turn a, Turn b) => FromTurns(a._turns + b._turns);
        public static Turn operator -(Turn a, Turn b) => FromTurns(a._turns - b._turns);

        public override string ToString() => _turns.ToString();

        public double Turns => _turns;
        public double Radians => Tau * _turns;
        public double Degrees => 360.0 * _turns;

        public double Sin => Math.Sin(Radians);
        public double Cos => Math.Cos(Radians);
        public double Tan => Math.Tan(Radians);

        public static Turn Asin(double sin) => FromRadians(Math.Asin(sin));
        public static Turn Acos(double cos) => FromRadians(Math.Acos(cos));
        public static Turn Atan(double tan) => FromRadians(Math.Atan(tan));

        public static Turn Atan2(double y, double x) => FromRadians(Math.Atan2(y, x));
    }
}
