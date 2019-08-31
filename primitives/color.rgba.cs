using System;

namespace SturdyTribble.Primitive
{
    public class ColorRgba : Color
    {
        readonly float red;
        readonly float green;
        readonly float blue;
        readonly float alpha = 1.0f;

        public float R => red;
        public float G => green;
        public float B => blue;
        public float A => alpha;

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

        public ColorRgba(ColorRgba other)
        {
            red = other.red;
            green = other.green;
            blue = other.blue;
            alpha = other.alpha;
        }

        public ColorRgba(ColorRgb other)
        {
            this.red = other.R;
            this.green = other.G;
            this.blue = other.B;
        }

        public override ColorRgb ToRgb() => new ColorRgb(this);
        public override ColorRgba ToRgba() => this;

        public static ColorRgba operator +(ColorRgba dst, ColorRgba src) => Blend(src, dst);
        public static ColorRgba Blend(ColorRgba src, ColorRgba dst)
        {
            var outA = src.alpha + dst.alpha * (1f - src.alpha);
            if (outA == 0f) return Color.Black.ToRgba();

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
