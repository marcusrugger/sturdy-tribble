using SturdyTribble.Primitive;
using System;

namespace SturdyTribble.Core
{
    public interface Context
    {
        void DrawPoint(Point p);
        void DrawLine(Point a, Point b);
        void DrawArc(Point point, double radius, double startAngle, double sweepAngle);
    }
}
