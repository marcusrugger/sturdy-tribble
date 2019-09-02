using System;

namespace SturdyTribble.Primitive
{
    public struct ColorRgb
    {
        public float R, G, B;

        public ColorRgb(float greyscale)
            => R = G = B = boxin(greyscale);

        public ColorRgb(float red, float green, float blue)
        {
            this.R = boxin(red);
            this.G = boxin(green);
            this.B = boxin(blue);
        }

        public ColorRgb(ColorRgb other)
        {
            R = other.R;
            G = other.G;
            B = other.B;
        }

        public ColorRgb(ColorRgba rgba)
        {
            R = rgba.A * rgba.R;
            G = rgba.A * rgba.G;
            B = rgba.A * rgba.B;
        }

        public override string ToString() => $"({R}, {G}, {B})";
        public ColorRgba ToRgba() => new ColorRgba(this);

        public static ColorRgb operator +(ColorRgb dst, ColorRgb src) => Blend(src, dst);
        public static ColorRgb Blend(ColorRgb src, ColorRgb dst)
        {
            float r = (src.R + dst.R) / 2f;
            float g = (src.G + dst.G) / 2f;
            float b = (src.B + dst.B) / 2f;
            return new ColorRgb(r, g, b);
        }

        public ColorRgb BlendWith(ColorRgb src)
            => Blend(src, this);

        private static float boxin(float value)
            => value < 0.0f ? 0.0f : value > 1.0f ? 1.0f : value;

        public struct Color
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
    }
}
