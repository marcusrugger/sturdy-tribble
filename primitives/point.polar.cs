using System;

namespace SturdyTribble.Primitive
{
    public struct PointPolar
    {
        public Angle a;
        public double r;

        public double X => r * a.Cos;
        public double Y => r * a.Sin;

        public PointPolar(Angle a, double r)
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
        { }

        public PointPolar(PointDouble p)
        {
            this.a = p.A;
            this.r = p.R;
        }

        public static implicit operator PointPolar(PointInteger p) => new PointPolar(p);
        public static implicit operator PointPolar(PointDouble p) => new PointPolar(p);

        public override string ToString() => $"({a}, {r})";
        public PointInteger ToPointInteger() => (PointInteger)this;
        public PointDouble ToPointDouble() => (PointDouble)this;

        public static PointPolar operator +(PointPolar ls, PointPolar rs)
        {
            var lsp = ls.ToPointDouble();
            var rsp = rs.ToPointDouble();
            var sum = lsp + rsp;
            return sum.ToPointPolar();
        }

        public PointPolar TransformR(Func<double, double> fn)
            => new PointPolar(a, fn(r));
    }

}
