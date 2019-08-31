using Microsoft.VisualStudio.TestTools.UnitTesting;
using SturdyTribble.Primitive;
using System;

namespace SturdyTribble.Primitive.Tests
{
    [TestClass]
    public class TestColorRgba
    {
        [TestMethod]
        public void New_color_from_greyscale()
        {
            float greyscale = 0.25f;
            var color = new ColorRgba(greyscale);

            Assert.AreEqual(greyscale, color.R);
            Assert.AreEqual(greyscale, color.G);
            Assert.AreEqual(greyscale, color.B);
        }

        [TestMethod]
        public void TestBlend()
        {
            var foreground = new ColorRgba(1f, 0f, 0f, 0.75f);
            var background = new ColorRgba(0f, 1f, 0f, 1f);
            var result = background + foreground;

            Assert.AreEqual(0.75f, result.R);
            Assert.AreEqual(0.25f, result.G);
            Assert.AreEqual(0.00f, result.B);
            Assert.AreEqual(1.00f, result.A);
        }
    }
}
