using System;

namespace SturdyTribble.Primitive
{
    public class PointPolar
    {
        readonly double a;
        readonly double r;

        public double A => a;
        public double R => r;

        public PointPolar()
        {
            a = 0;
            r = 0;
        }

        public PointPolar(double a, double r)
        {
            this.a = a;
            this.r = r;
        }

        public PointPolar(PointPolar other)
        {
            this.a = other.a;
            this.r = other.r;
        }

        public PointPolar(PointInteger p) : this(p.ToPointDouble())
        {}

        public PointPolar(PointDouble p)
        {
            this.a = Math.Atan2(p.Y, p.X);
            this.r = Algorithms.PythagoreanTheorem(p);
        }

        public static implicit operator PointPolar(PointInteger p) => new PointPolar(p);
        public static implicit operator PointPolar(PointDouble p) => new PointPolar(p);

        public override string ToString() => $"({a}, {r})";
        public PointInteger ToPointInteger() => new PointInteger(this);
        public PointDouble ToPointDouble() => new PointDouble(this);

        public PointPolar TransformR(Func<double, double> fn)
            => new PointPolar(a, fn(r));
    }

}
