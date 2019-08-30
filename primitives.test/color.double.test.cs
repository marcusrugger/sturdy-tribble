using Microsoft.VisualStudio.TestTools.UnitTesting;
using SturdyTribble.Primitive;

namespace SturdyTribble.Primitive.Tests
{
    [TestClass]
    public class TestColorDouble
    {
        [TestMethod]
        public void New_color_from_greyscale()
        {
            double greyscale = 127;
            var color = new ColorDouble(greyscale);

            Assert.AreEqual(greyscale, color.Red);
            Assert.AreEqual(greyscale, color.Green);
            Assert.AreEqual(greyscale, color.Blue);
        }
    }
}
