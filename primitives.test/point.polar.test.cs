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
            TestPolar( 3.0,  4.0, Turn.FromRadians( 0.927295218), 5.0);
            TestPolar(-3.0,  4.0, Turn.FromRadians( 2.214297436), 5.0);
            TestPolar( 3.0, -4.0, Turn.FromRadians(-0.927295218), 5.0);
            TestPolar(-3.0, -4.0, Turn.FromRadians(-2.214297436), 5.0);
            TestPolar( 0.0,  1.0, Turn.FromRadians( Math.PI/2.0), 1.0);
            TestPolar( 0.0, -1.0, Turn.FromRadians(-Math.PI/2.0), 1.0);
            TestPolar(-1.0,  0.0, Turn.FromRadians( Math.PI),     1.0);
            TestPolar( 1.0,  1.0, Turn.FromRadians( Math.PI/4.0), Math.Sqrt(2.0));

            void TestPolar(double x, double y, Turn expectedA, double expectedR, double precision = 0.000000001)
            {
                var point = new PointDouble(x, y);
                var polar = new PointPolar(point);

                Assert.AreEqual(expectedA.Turns, polar.A.Turns, precision);
                Assert.AreEqual(expectedR, polar.R, precision);
            }
        }

        [TestMethod]
        public void Add_two_polar_points()
        {
            var polarA = new PointPolar(Turn.FromDegrees(30), 1);
            var polarB = new PointPolar(Turn.FromDegrees(60), 1);
            var polarC = polarA + polarB;

            Console.WriteLine($"Polar point: {polarC}");
            var expectedA = Turn.FromTurns(1.0/8.0);
            var side = Math.Sqrt(3.0)/2.0 + 0.5;
            var expectedR = Math.Sqrt(2.0 * side * side);
            Assert.AreEqual(expectedA.Turns, polarC.A.Turns);
            Assert.AreEqual(expectedR, polarC.R);
        }
    }
}
