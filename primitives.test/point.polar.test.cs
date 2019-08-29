using Microsoft.VisualStudio.TestTools.UnitTesting;
using SturdyTribble.Primitive;
using System;

namespace SturdyTribble.Primitive.Tests
{
    [TestClass]
    public class TestPointPolar
    {
        [TestMethod]
        public void Construct_from_PointDouble()
        {
            TestPolar( 3.0,  4.0,  0.927295218, 5.0);
            TestPolar(-3.0,  4.0,  2.214297436, 5.0);
            TestPolar( 3.0, -4.0, -0.927295218, 5.0);
            TestPolar(-3.0, -4.0, -2.214297436, 5.0);
            TestPolar( 0.0,  1.0,  Math.PI/2.0, 1.0);
            TestPolar( 0.0, -1.0, -Math.PI/2.0, 1.0);
            TestPolar(-1.0,  0.0,  Math.PI,     1.0);
            TestPolar( 1.0,  1.0,  Math.PI/4.0, Math.Sqrt(2.0));

            void TestPolar(double x, double y, double expectedA, double expectedR, double precision = 0.000000001)
            {
                var point = new PointDouble(x, y);
                var polar = new PointPolar(point);

                Assert.AreEqual(expectedA, polar.A, precision);
                Assert.AreEqual(expectedR, polar.R, precision);
            }
        }

        [TestMethod]
        public void Add_two_polar_points()
        {
            var polarA = new PointPolar(Algorithms.ToRadians(30), 1);
            var polarB = new PointPolar(Algorithms.ToRadians(60), 1);
            var polarC = polarA + polarB;

            Console.WriteLine($"Polar point: {polarC}");
            var expectedA = Math.PI/4;
            var side = Math.Sqrt(3.0)/2.0 + 0.5;
            var expectedR = Math.Sqrt(2.0 * side * side);
            Assert.AreEqual(expectedA, polarC.A);
            Assert.AreEqual(expectedR, polarC.R);
        }
    }
}
