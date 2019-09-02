using System;

namespace SturdyTribble.Primitive
{
    public struct PointDouble
    {
        public double x, y;

        public Angle A => Angle.Atan2(y, x);
        public double R => Math.Sqrt(x * x + y * y);

        public PointDouble(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public PointDouble(PointDouble other)
        {
            this.x = other.x;
            this.y = other.y;
        }

        public PointDouble(PointPolar pc)
        {
            x = pc.X;
            y = pc.Y;
        }
        
        public PointDouble(PointInteger p)
        {
            x = p.x;
            y = p.y;
        }

        public static implicit operator PointDouble(PointInteger p) => new PointDouble(p);
        public static implicit operator PointDouble(PointPolar p) => new PointDouble(p);

        public override string ToString() => $"({x}, {y})";
        public PointInteger ToPointInteger() => (PointInteger)this;
        public PointPolar ToPointPolar() => (PointPolar)this;

        public static PointDouble operator +(PointDouble ls, PointDouble rs)
            => new PointDouble(ls.x + rs.x, ls.y + rs.y);

        public static PointDouble operator -(PointDouble ls, PointDouble rs)
            => new PointDouble(ls.x - rs.x, ls.y - rs.y);

        public PointDouble Offset(double dx, double dy)
            => new PointDouble(x + dx, y + dy);

        public PointDouble Offset(PointDouble other)
            => new PointDouble(x + other.x, y + other.y);

        public PointDouble Scale(double scale)
            => new PointDouble(scale * x, scale * y);

        public PointDouble Scale(PointDouble scale)
            => new PointDouble(scale.x * x, scale.y * y);
    }
}
