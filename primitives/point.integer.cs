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
        
        public PointInteger(PointPolar p) : this(p.ToPointInteger())
        {}

        public PointInteger(PointDouble p)
        {
            x = (int) (p.X + 0.5);
            y = (int) (p.Y + 0.5);
        }

        public PointInteger Offset(PointInteger p)
            => new PointInteger(x + p.x, y + p.y);

        public PointInteger Offset(int x, int y)
            => new PointInteger(this.x + x, this.y + y);

        public override string ToString()
            => "(" + x + ", " + y + ")";

        public PointInteger ToPointInteger()
            => this;

        public PointPolar ToPointPolar()
            => new PointPolar(this);

        public PointDouble ToPointDouble()
            => new PointDouble(this);

        public int X => x;
        public int Y => y;
    }
}
