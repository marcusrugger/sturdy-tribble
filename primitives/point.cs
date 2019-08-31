using System;

namespace SturdyTribble.Primitive
{
    public abstract class Point
    {
        public abstract PointInteger ToPointInteger();
        public abstract PointDouble ToPointDouble();
        public abstract PointPolar ToPointPolar();
    }
}
