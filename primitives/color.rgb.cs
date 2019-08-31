using System;

namespace SturdyTribble.Primitive
{
    public class ColorRgb : Color
    {
        readonly float red;
        readonly float green;
        readonly float blue;

        public float R => red;
        public float G => green;
        public float B => blue;

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

        public ColorRgb(ColorRgb other)
        {
            red = other.red;
            green = other.green;
            blue = other.blue;
        }

        public ColorRgb(ColorRgba rgba)
        {
            red = rgba.A * rgba.R;
            green = rgba.A * rgba.G;
            blue = rgba.A * rgba.B;
        }

        public override string ToString() => $"({red}, {green}, {blue})";
        public override ColorRgb ToRgb() => this;
        public override ColorRgba ToRgba() => new ColorRgba(this);

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
