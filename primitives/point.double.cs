using System;

namespace SturdyTribble.Primitive
{
    public class PointDouble
    {
        readonly double x;
        readonly double y;
        
        public PointDouble()
        {
            x = 0;
            y = 0;
        }

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
            x = pc.R * Math.Cos(pc.A);
            y = pc.R * Math.Sin(pc.A);
        }
        
        public PointDouble(PointInteger p)
        {
            x = p.X;
            y = p.Y;
        }

        public static PointDouble operator +(PointDouble ls, PointDouble rs)
        {
            return new PointDouble(ls.x + rs.x, ls.y + rs.y);
        }

        public static PointDouble operator -(PointDouble ls, PointDouble rs)
        {
            return new PointDouble(ls.x - rs.x, ls.y - rs.y);
        }

        public PointDouble Offset(double dx, double dy)
        {
            return new PointDouble(x + dx, y + dy);
        }

        public PointDouble Offset(PointDouble other)
        {
            return new PointDouble(x + other.x, y + other.y);
        }

        public PointDouble Scale(double scale)
        {
            return new PointDouble(scale * x, scale * y);
        }

        public PointDouble Scale(PointDouble scale)
        {
            return new PointDouble(scale.x * x, scale.y * y);
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }

        public PointInteger ToPointInteger()
        {
            return new PointInteger(this);
        }

        public PointPolar ToPointPolar()
        {
            return new PointPolar(this);
        }

        public PointDouble ToPointDouble()
        {
            return this;
        }

        public double X { get { return x; } }
        public double Y { get { return y; } }
    }
}