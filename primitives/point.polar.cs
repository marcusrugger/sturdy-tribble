using System;

namespace SturdyTribble.Primitive
{
    public class PointPolar
    {
        readonly double a;
        readonly double r;

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
            this.a = Algorithms.SafeAtan(p);
            this.r = Math.Sqrt(p.X * p.X + p.Y * p.Y);
        }

        public PointPolar TransformR(Func<double, double> fn)
        {
            return new PointPolar(a, fn(r));
        }

        public override string ToString()
        {
            return "(" + a + ", " + r + ")";
        }

        public PointInteger ToPointInteger()
        {
            return new PointInteger(this);
        }

        public PointPolar ToPointPolar()
        {
            return this;
        }

        public PointDouble ToPointDouble()
        {
            return new PointDouble(this);
        }

        public double A { get { return a; } }
        public double R { get { return r; } }
    }

}
