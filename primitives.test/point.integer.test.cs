using Microsoft.VisualStudio.TestTools.UnitTesting;
using SturdyTribble.Primitive;

namespace SturdyTribble.Primitive.Tests
{
    [TestClass]
    public class TestPointInteger
    {
        [TestMethod]
        public void ToString_is_formatted_correctly()
        {
            var point = new PointInteger(3, 5);
            var actual = point.ToString();
            var expected = "(3, 5)";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_two_points()
        {
            int ax = 3;
            int ay = 5;
            int bx = 7;
            int by = 11;

            var point1 = new PointInteger(ax, ay);
            var point2 = new PointInteger(bx, by);
            var actual = point1 + point2;

            Assert.AreEqual(ax + bx, actual.X);
            Assert.AreEqual(ay + by, actual.Y);
        }

        [TestMethod]
        public void Subtract_two_points()
        {
            int ax = 3;
            int ay = 5;
            int bx = 7;
            int by = 11;

            var point1 = new PointInteger(ax, ay);
            var point2 = new PointInteger(bx, by);
            var actual = point1 - point2;

            Assert.AreEqual(ax - bx, actual.X);
            Assert.AreEqual(ay - by, actual.Y);
        }
    }
}
