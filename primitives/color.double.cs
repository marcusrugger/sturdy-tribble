using System;

namespace SturdyTribble.Primitive
{
    public class ColorDouble
    {
        readonly double red;
        readonly double green;
        readonly double blue;
        readonly double alpha = 1.0;

        public double Red => red;
        public double Green => green;
        public double Blue => blue;
        public double Alpha => alpha;

        public ColorDouble()
        { }

        public ColorDouble(double greyscale)
            => red = green = blue = greyscale;
    }
}
