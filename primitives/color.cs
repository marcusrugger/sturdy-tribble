using System;

namespace SturdyTribble.Primitive
{
    public abstract class Color
    {
        public static readonly Color Black   = new ColorRgb( 0.00f );
        public static readonly Color DkGray  = new ColorRgb( 0.25f );
        public static readonly Color Gray    = new ColorRgb( 0.50f );
        public static readonly Color LtGray  = new ColorRgb( 0.75f );
        public static readonly Color White   = new ColorRgb( 1.00f );

        public static readonly Color Red     = new ColorRgb( 1.0f, 0.0f, 0.0f );
        public static readonly Color Green   = new ColorRgb( 0.0f, 1.0f, 0.0f );
        public static readonly Color Blue    = new ColorRgb( 0.0f, 0.0f, 1.0f );
        public static readonly Color Cyan    = new ColorRgb( 0.0f, 1.0f, 1.0f );
        public static readonly Color Magenta = new ColorRgb( 1.0f, 0.0f, 1.0f );
        public static readonly Color Yellow  = new ColorRgb( 1.0f, 1.0f, 0.0f );

        public abstract ColorRgb ToRgb();
        public abstract ColorRgba ToRgba();
    }
}
