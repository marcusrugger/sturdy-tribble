using System;

namespace SturdyTribble.Primitive
{
    public class PointInteger
    {
        readonly int x;
        readonly int y;

        public PointInteger()
        {
            x = 0;
            y = 0;
        }

        public PointInteger(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public PointInteger(PointInteger other)
        {
            this.x = other.x;
            this.y = other.y;
        }
        
        public PointInteger(PointPolar p) : this(p.ToPointDouble())
        {}

        public PointInteger(PointDouble p)
        {
            x = (int) (p.X + 0.5);
            y = (int) (p.Y + 0.5);
        }

        public static implicit operator PointInteger(PointDouble p) => new PointInteger(p);
        public static implicit operator PointInteger(PointPolar p) => new PointInteger(p);

        public override string ToString() => $"({x}, {y})";
        public PointDouble ToPointDouble() => new PointDouble(this);
        public PointPolar ToPointPolar() => new PointPolar(this);

        public PointInteger Offset(PointInteger p)
            => new PointInteger(x + p.x, y + p.y);

        public PointInteger Offset(int x, int y)
            => new PointInteger(this.x + x, this.y + y);

        public int X => x;
        public int Y => y;
    }
}
