using Microsoft.VisualStudio.TestTools.UnitTesting;
using SturdyTribble.Primitive;
using System;

namespace SturdyTribble.Primitive.Tests
{
    [TestClass]
    public class TestAlgorithms
    {
        [TestMethod]
        public void ToRadians()
        {
            TestAngle(-180, -Math.PI);
            TestAngle(-90, -Math.PI/2);
            TestAngle(0.0, 0.0);
            TestAngle( 1.234567, 0.02154726, 0.00000001);
            TestAngle(60.000000, Math.PI/3);
            TestAngle(90, Math.PI/2);
            TestAngle(180, Math.PI);

            void TestAngle(double degrees, double expected, double precision = 0.000001)
            {
                var radians = Algorithms.ToRadians(degrees);
                Assert.AreEqual(expected, radians, precision);
            }
        }

        [TestMethod]
        public void ToDegrees()
        {
            TestAngle(-Math.PI, -180);
            TestAngle(0.0, 0.0);
            TestAngle(0.02154726, 1.234567);
            TestAngle(Math.PI/3, 60);
            TestAngle(Math.PI/2, 90);
            TestAngle(Math.PI, 180);

            void TestAngle(double radians, double expected, double precision = 0.000001)
            {
                var degrees = Algorithms.ToDegrees(radians);
                Assert.AreEqual(expected, degrees, precision);
            }
        }

        [TestMethod]
        public void Pythagoras()
        {
            TestPythagoras(3, 4, 5);
            TestPythagoras(5, 12, 13);
            TestPythagoras(9, 12, 15);

            void TestPythagoras(double x, double y, double expected, double precision = 0.000001)
            {
                var result = Algorithms.PythagoreanTheorem(x, y);
                Assert.AreEqual(expected, result, precision);
            }
        }
    }
}
