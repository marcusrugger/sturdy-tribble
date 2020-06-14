using System;

namespace SturdyTribble.Primitive
{
    public class Matrix
    {
        public readonly double A1, A2, A3;
        public readonly double B1, B2, B3;
        public readonly double C1, C2, C3;

        public Matrix(
            double a1, double a2, double a3,
            double b1, double b2, double b3,
            double c1, double c2, double c3)
        {
            A1 = a1; A2 = a2; A3 = a3;
            B1 = b1; B2 = b2; B3 = b3;
            C1 = c1; C2 = c2; C3 = c3;
        }

        public static Matrix Scaling(PointDouble scale)
            => new Matrix(
                scale.x, 0.0, 0.0,
                0.0, scale.y, 0.0,
                0.0, 0.0, 1.0
            );

        public static Matrix operator *(Matrix l, Matrix r)
        {
            double a1, a2, a3;
            double b1, b2, b3;
            double c1, c2, c3;

            a1 = l.A1 * r.A1 + l.A2 * r.B1 + l.A3 * r.C1;
            a2 = l.A1 * r.A2 + l.A2 * r.B2 + l.A3 * r.C2;
            a3 = l.A1 * r.A3 + l.A2 * r.B3 + l.A3 * r.C3;

            b1 = l.B1 * r.A1 + l.B2 * r.B1 + l.B3 * r.C1;
            b2 = l.B1 * r.A2 + l.B2 * r.B2 + l.B3 * r.C2;
            b3 = l.B1 * r.A3 + l.B2 * r.B3 + l.B3 * r.C3;

            c1 = l.C1 * r.A1 + l.C2 * r.B1 + l.C3 * r.C1;
            c2 = l.C1 * r.A2 + l.C2 * r.B2 + l.C3 * r.C2;
            c3 = l.C1 * r.A3 + l.C2 * r.B3 + l.C3 * r.C3;

            return new Matrix(a1, a2, a3, b1, b2, b3, c1, c2, c3);
        }
    }
}

