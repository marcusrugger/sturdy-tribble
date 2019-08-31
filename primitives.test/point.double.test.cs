using Microsoft.VisualStudio.TestTools.UnitTesting;
using SturdyTribble.Primitive;
using System;

namespace SturdyTribble.Primitive.Tests
{
    [TestClass]
    public class TestPointDouble
    {
        [TestMethod]
        public void ToString_is_formatted_correctly()
        {
            var point = new PointDouble(3.14, 5.7);
            var actual = point.ToString();
            var expected = "(3.14, 5.7)";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_two_points()
        {
            double ax = 3.14;
            double ay = 5.7;
            double bx = 7.13;
            double by = 11.17;

            var point1 = new PointDouble(ax, ay);
            var point2 = new PointDouble(bx, by);
            var actual = point1 + point2;

            Assert.AreEqual(ax + bx, actual.X);
            Assert.AreEqual(ay + by, actual.Y);
        }

        [TestMethod]
        public void Subtract_two_points()
        {
            double ax = 3.14;
            double ay = 5.7;
            double bx = 7.13;
            double by = 11.17;

            var point1 = new PointDouble(ax, ay);
            var point2 = new PointDouble(bx, by);
            var actual = point1 - point2;

            Assert.AreEqual(ax - bx, actual.X);
            Assert.AreEqual(ay - by, actual.Y);
        }

        [TestMethod]
        public void TestTypecastFromPoint()
        {
            var polar = new PointPolar(Turn.FromDegrees(30), 1);
            var cast = (PointDouble)polar;
            Assert.AreEqual(Math.Sqrt(3)/2, cast.X, 0.000000001);
        }
    }
}
