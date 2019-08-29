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

        [TestMethod]
        public void Rotation()
        {
            var rotationA = Algorithms.ToRadians(30);
            var rotationM = Matrix33.Rotation(rotationA);

            Assert.AreEqual( Math.Cos(rotationA), rotationM.Matrix[0,0]);
            Assert.AreEqual(-Math.Sin(rotationA), rotationM.Matrix[0,1]);
            Assert.AreEqual( 0.0,                 rotationM.Matrix[0,2]);

            Assert.AreEqual( Math.Sin(rotationA), rotationM.Matrix[1,0]);
            Assert.AreEqual( Math.Cos(rotationA), rotationM.Matrix[1,1]);
            Assert.AreEqual( 0.0,                 rotationM.Matrix[1,2]);

            Assert.AreEqual(0.0, rotationM.Matrix[2,0]);
            Assert.AreEqual(0.0, rotationM.Matrix[2,1]);
            Assert.AreEqual(1.0, rotationM.Matrix[2,2]);
        }

        [TestMethod]
        public void Rotate_point_45_degrees()
        {
            var rotationA = Algorithms.ToRadians(45);
            var rotationM = Matrix33.Rotation(rotationA);

            var pointA = new PointDouble(1.0, 0.0);
            var pointB = rotationM.Transform(pointA);

            var expected = Math.Sqrt(2.0) / 2.0;
            var precision = 0.000000001;
            Assert.AreEqual(expected, pointB.X, precision);
            Assert.AreEqual(expected, pointB.Y, precision);

            var pointC = rotationM.Transform(pointB);
            Assert.AreEqual(0.0, pointC.X, precision);
            Assert.AreEqual(1.0, pointC.Y, precision);
        }
    }
}
