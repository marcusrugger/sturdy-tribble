using System;

namespace SturdyTribble.Primitive
{
    public class ColorRgb
    {
        public class Color
        {
            public static readonly ColorRgb Black   = new ColorRgb( 0.00f );
            public static readonly ColorRgb DkGray  = new ColorRgb( 0.25f );
            public static readonly ColorRgb Gray    = new ColorRgb( 0.50f );
            public static readonly ColorRgb LtGray  = new ColorRgb( 0.75f );
            public static readonly ColorRgb White   = new ColorRgb( 1.00f );

            public static readonly ColorRgb Red     = new ColorRgb( 1.0f, 0.0f, 0.0f );
            public static readonly ColorRgb Green   = new ColorRgb( 0.0f, 1.0f, 0.0f );
            public static readonly ColorRgb Blue    = new ColorRgb( 0.0f, 0.0f, 1.0f );
            public static readonly ColorRgb Cyan    = new ColorRgb( 0.0f, 1.0f, 1.0f );
            public static readonly ColorRgb Magenta = new ColorRgb( 1.0f, 0.0f, 1.0f );
            public static readonly ColorRgb Yellow  = new ColorRgb( 1.0f, 1.0f, 0.0f );
        }

        readonly float red;
        readonly float green;
        readonly float blue;

        public float Red => red;
        public float Green => green;
        public float Blue => blue;

        public ColorRgb()
        { }

        public ColorRgb(float greyscale)
            => red = green = blue = boxin(greyscale);

        public ColorRgb(float red, float green, float blue)
        {
            this.red = boxin(red);
            this.green = boxin(green);
            this.blue = boxin(blue);
        }

        public ColorRgb(ColorRgba rgba)
        {
            red = rgba.Alpha * rgba.Red;
            green = rgba.Alpha * rgba.Green;
            blue = rgba.Alpha * rgba.Blue;
        }

        public static ColorRgb operator +(ColorRgb dst, ColorRgb src) => Blend(src, dst);
        public static ColorRgb Blend(ColorRgb src, ColorRgb dst)
        {
            float r = (src.red + dst.red) / 2f;
            float g = (src.green + dst.green) / 2f;
            float b = (src.blue + dst.blue) / 2f;
            return new ColorRgb(r, g, b);
        }

        public ColorRgb BlendWith(ColorRgb src)
            => Blend(src, this);

        private float boxin(float value)
            => value < 0.0f ? 0.0f : value > 1.0f ? 1.0f : value;
    }
}
