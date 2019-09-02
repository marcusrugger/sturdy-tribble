using SturdyTribble.Primitive;
using System;

namespace SturdyTribble.Core
{
    public interface Context
    {
        void DrawPoint(PointDouble p);
        void DrawLine(PointDouble a, PointDouble b);
        void DrawArc(PointDouble point, double radius, double startAngle, double sweepAngle);
    }
}
