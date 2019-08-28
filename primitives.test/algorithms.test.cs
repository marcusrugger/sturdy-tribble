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
            TestAngle( 1.234567, 0.021547);
            TestAngle(60.000000, Math.PI/3);
            TestAngle(90, Math.PI/2);
            TestAngle(180, Math.PI);

            void TestAngle(double degrees, double expected, double precision = 0.000001)
            {
                var radians = Algorithms.ToRadians(degrees);
                Assert.AreEqual(expected, radians, precision);
            }
        }
    }
}
