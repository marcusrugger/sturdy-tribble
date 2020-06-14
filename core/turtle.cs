using SturdyTribble.Primitive;
using System;

namespace SturdyTribble.Core
{
    public interface Turtle
    {
        Turtle Turn(Angle angle);
        Turtle TurnTo(Angle angle);

        Turtle Move(double distance);
        Turtle MoveTo(PointDouble p);

        Turtle Draw(double distance);
        Turtle DrawTo(PointDouble p);
    }
}
