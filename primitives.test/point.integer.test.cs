using Microsoft.VisualStudio.TestTools.UnitTesting;
using SturdyTribble.Primitive;

namespace primitives.test
{
    [TestClass]
    public class TestPointInteger
    {
        [TestMethod]
        public void ToString_is_formatted_correctly()
        {
            var p = new PointInteger(3, 5);
            var s = p.ToString();
            Assert.AreEqual("(3, 5)", s);
        }
    }
}
