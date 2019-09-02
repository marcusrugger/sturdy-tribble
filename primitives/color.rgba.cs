using System;

namespace SturdyTribble.Primitive
{
    public struct ColorRgba
    {
        public float R, G, B, A;

        public ColorRgba(float greyscale)
        {
            R = G = B = boxin(greyscale);
            A = 1f;
        }

        public ColorRgba(float red, float green, float blue, float alpha = 1.0f)
        {
            this.R = boxin(red);
            this.G = boxin(green);
            this.B = boxin(blue);
            this.A = boxin(alpha);
        }

        public ColorRgba(ColorRgba other)
        {
            R = other.R;
            G = other.G;
            B = other.B;
            A = other.A;
        }

        public ColorRgba(ColorRgb other)
        {
            this.R = other.R;
            this.G = other.G;
            this.B = other.B;
            this.A = 1f;
        }

        public override string ToString() => $"({R}, {G}, {B}, {A})";
        public ColorRgb ToRgb() => new ColorRgb(this);

        public static ColorRgba operator +(ColorRgba dst, ColorRgba src) => Blend(src, dst);
        public static ColorRgba Blend(ColorRgba src, ColorRgba dst)
        {
            var outA = src.A + dst.A * (1f - src.A);
            if (outA == 0f) return Color.Black.ToRgba();

            var outR = (src.R * src.A + dst.R * dst.A * (1f - src.A)) / outA;
            var outG = (src.G * src.A + dst.G * dst.A * (1f - src.A)) / outA;
            var outB = (src.B * src.A + dst.B * dst.A * (1f - src.A)) / outA;

            return new ColorRgba(outR, outG, outB, outA);
        }

        public ColorRgba BlendWith(ColorRgba src)
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
