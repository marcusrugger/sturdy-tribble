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
            this.a = SafeAtan(p);
            this.r = Math.Sqrt(p.X * p.X + p.Y * p.Y);
        }

        private double SafeAtan(PointDouble p)
        {
            if (Math.Abs(p.X) > 1e-9)
                return AtanByQuadrant(p);
            else
                return AtanPointOnYAxis(p);
        }

        private double AtanByQuadrant(PointDouble p)
        {
            double result = Math.Atan(p.Y / p.X);

            if (p.X < 0.0)
                result += Math.PI;
            else if (p.Y < 0.0)
                result += 2*Math.PI;

            return result;
        }

        private double AtanPointOnYAxis(PointDouble p)
        {
            if (p.Y >= 0.0)
                return Math.PI / 2.0;
            else
                return 3.0 * Math.PI / 2.0;
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
