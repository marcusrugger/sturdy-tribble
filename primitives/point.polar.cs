using System;

namespace SturdyTribble.Primitive
{
    public class PointPolar : Point
    {
        readonly Angle a;
        readonly double r;

        public Angle A => a;
        public double R => r;

        public PointPolar()
        {
            a = Angle.FromTurns(0);
            r = 0;
        }

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
            this.a = Angle.Atan2(p.y, p.x);
            this.r = Algorithms.PythagoreanTheorem(p);
        }

        public static implicit operator PointPolar(PointInteger p) => new PointPolar(p);
        public static implicit operator PointPolar(PointDouble p) => new PointPolar(p);

        public override string ToString() => $"({a}, {r})";
        public override PointInteger ToPointInteger() => (PointInteger)this;
        public override PointDouble ToPointDouble() => (PointDouble)this;
        public override PointPolar ToPointPolar() => this;

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
