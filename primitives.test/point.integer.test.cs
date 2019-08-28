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
            var point1 = new PointInteger(3, 5);
            var point2 = new PointInteger(7, 11);
            var actual = point1 + point2;
            Assert.AreEqual(3 + 7, actual.X);
            Assert.AreEqual(5 + 11, actual.Y);
        }

        [TestMethod]
        public void Subtract_two_points()
        {
            var point1 = new PointInteger(3, 5);
            var point2 = new PointInteger(7, 11);
            var actual = point1 - point2;
            Assert.AreEqual(3 - 7, actual.X);
            Assert.AreEqual(5 - 11, actual.Y);
        }
    }
}
