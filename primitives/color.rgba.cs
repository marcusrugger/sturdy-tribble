using System;

namespace SturdyTribble.Primitive
{
    public class ColorRgba
    {
        public class Color
        {
            public static readonly ColorRgba Black   = new ColorRgba( 0.00f );
            public static readonly ColorRgba DkGray  = new ColorRgba( 0.25f );
            public static readonly ColorRgba Gray    = new ColorRgba( 0.50f );
            public static readonly ColorRgba LtGray  = new ColorRgba( 0.75f );
            public static readonly ColorRgba White   = new ColorRgba( 1.00f );

            public static readonly ColorRgba Red     = new ColorRgba( 1.0f, 0.0f, 0.0f );
            public static readonly ColorRgba Green   = new ColorRgba( 0.0f, 1.0f, 0.0f );
            public static readonly ColorRgba Blue    = new ColorRgba( 0.0f, 0.0f, 1.0f );
            public static readonly ColorRgba Cyan    = new ColorRgba( 0.0f, 1.0f, 1.0f );
            public static readonly ColorRgba Magenta = new ColorRgba( 1.0f, 0.0f, 1.0f );
            public static readonly ColorRgba Yellow  = new ColorRgba( 1.0f, 1.0f, 0.0f );
        }

        readonly float red;
        readonly float green;
        readonly float blue;
        readonly float alpha = 1.0f;

        public float Red => red;
        public float Green => green;
        public float Blue => blue;
        public float Alpha => alpha;

        public ColorRgba()
        { }

        public ColorRgba(float greyscale)
            => red = green = blue = boxin(greyscale);

        public ColorRgba(float red, float green, float blue, float alpha = 1.0f)
        {
            this.red = boxin(red);
            this.green = boxin(green);
            this.blue = boxin(blue);
            this.alpha = boxin(alpha);
        }

        public static ColorRgba operator +(ColorRgba dst, ColorRgba src) => Blend(src, dst);
        public static ColorRgba Blend(ColorRgba src, ColorRgba dst)
        {
            var outA = src.alpha + dst.alpha * (1f - src.alpha);
            if (outA == 0f) return Color.Black;

            var outR = (src.red * src.alpha + dst.red * dst.alpha * (1f - src.alpha)) / outA;
            var outG = (src.green * src.alpha + dst.green * dst.alpha * (1f - src.alpha)) / outA;
            var outB = (src.blue * src.alpha + dst.blue * dst.alpha * (1f - src.alpha)) / outA;

            return new ColorRgba(outR, outG, outB, outA);
        }

        public ColorRgba BlendWith(ColorRgba src)
            => Blend(src, this);

        private float boxin(float value)
            => value < 0.0f ? 0.0f : value > 1.0f ? 1.0f : value;
    }
}
