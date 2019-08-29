using Microsoft.VisualStudio.TestTools.UnitTesting;
using SturdyTribble.Primitive;
using System;

namespace SturdyTribble.Primitive.Tests
{
    [TestClass]
    public class TestMatrix33
    {
        [TestMethod]
        public void Scaling()
        {
            var scaleP = new PointDouble(2, 3);
            var scaleM = Matrix33.Scaling(scaleP);

            Assert.AreEqual(2.0, scaleM.Matrix[0,0]);
            Assert.AreEqual(0.0, scaleM.Matrix[0,1]);
            Assert.AreEqual(0.0, scaleM.Matrix[0,2]);

            Assert.AreEqual(0.0, scaleM.Matrix[1,0]);
            Assert.AreEqual(3.0, scaleM.Matrix[1,1]);
            Assert.AreEqual(0.0, scaleM.Matrix[1,2]);

            Assert.AreEqual(0.0, scaleM.Matrix[2,0]);
            Assert.AreEqual(0.0, scaleM.Matrix[2,1]);
            Assert.AreEqual(1.0, scaleM.Matrix[2,2]);
        }

        [TestMethod]
        public void Translation()
        {
            var translateP = new PointDouble(2, 3);
            var translateM = Matrix33.Translation(translateP);

            Assert.AreEqual(1.0, translateM.Matrix[0,0]);
            Assert.AreEqual(0.0, translateM.Matrix[0,1]);
            Assert.AreEqual(2.0, translateM.Matrix[0,2]);

            Assert.AreEqual(0.0, translateM.Matrix[1,0]);
            Assert.AreEqual(1.0, translateM.Matrix[1,1]);
            Assert.AreEqual(3.0, translateM.Matrix[1,2]);

            Assert.AreEqual(0.0, translateM.Matrix[2,0]);
            Assert.AreEqual(0.0, translateM.Matrix[2,1]);
            Assert.AreEqual(1.0, translateM.Matrix[2,2]);
        }
    }
}
