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
        
        public PointInteger(PointPolar p) : this(p.ToPointDouble())
        {}

        public PointInteger(PointDouble p)
        {
            x = (int) (p.X + 0.5);
            y = (int) (p.Y + 0.5);
        }

        public PointInteger Offset(PointInteger p)
        {
            return new PointInteger(x + p.x, y + p.y);
        }

        public PointInteger Offset(int x, int y)
        {
            return new PointInteger(this.x + x, this.y + y);
        }

        public PointInteger ToPoint()
        {
            return this;
        }

        public PointPolar ToPointPolar()
        {
            return new PointPolar(this);
        }

        public PointDouble ToPointDouble()
        {
            return new PointDouble(this);
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }
    }
}
