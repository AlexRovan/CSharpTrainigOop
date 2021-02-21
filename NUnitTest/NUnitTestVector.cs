using NUnit.Framework;
using VectorTask;

namespace NUnitTest
{
    [TestFixture]
    public class NUnitTestVector
    {
        [Test]
        public void Vector_GetSum_EmptyVectorFirstArgument()
        {
            var vector1 = new Vector(4);
            var vector2 = new Vector(new[] { 3.0, 4.0, 8.0, 11.0 });

            var result = new Vector(new[] { 3.0, 4.0, 8.0, 11.0 });

            Assert.AreEqual(Vector.GetSum(vector1, vector2), result, "should be {3.0,4.0,8.0,11.0}");
        }

        [Test]
        public void Vector_GetSum_EmptyVectorSecondArgument()
        {
            var vector1 = new Vector(new[] { 7.0, 2.0, 3.0, 5.0 });
            var vector2 = new Vector(4);

            var result = new Vector(new[] { 7.0, 2.0, 3.0, 5.0 });

            Assert.AreEqual(Vector.GetSum(vector1, vector2), result, "should be {7.0,2.0,3.0,5.0}");
        }

        [Test]
        public void Vector_GetSum_EmptyVectorsArguments()
        {
            var vector1 = new Vector(4);
            var vector2 = new Vector(4);

            var result = new Vector(new[] { 0.0, 0.0, 0.0, 0.0 });

            Assert.AreEqual(Vector.GetSum(vector1, vector2), result, "should be {0.0,0.0,0.0,0.0}");
        }

        [Test]
        public void Vector_GetSum_VectorsOtherDimensionsArguments()
        {
            var vector1 = new Vector(new[] { 7.0, 2.0, 3.0, 5.0 });
            var vector2 = new Vector(new[] { 3.0, 4.0 });

            var result = new Vector(new[] { 10.0, 6.0, 3.0, 5.0 });

            Assert.AreEqual(Vector.GetSum(vector1, vector2), result, "{10.0,6.0,3.0,5.0}");
        }

        [Test]
        public void Vector_GetSum_VectorsSameDimensionsArgument()
        {
            var vector1 = new Vector(new[] { 7.0, 2.0, 3.0, 5.0 });
            var vector2 = new Vector(new[] { 3.0, 4.0, 8.0, 11.0 });

            var result = new Vector(new[] { 10.0, 6.0, 11.0, 16.0 });

            Assert.AreEqual(Vector.GetSum(vector1, vector2), result, "should be {10.0,6.0,11.0,16.0}");
        }

        [Test]
        public void Vector_GetScalarProduct_EmptyVectorFirstArgument()
        {
            var vector1 = new Vector(4);
            var vector2 = new Vector(new[] { 3.0, 4.0, 8.0, 11.0 });

            const int result = 0;

            Assert.AreEqual(Vector.GetScalarProduct(vector1, vector2), result, "should be 0");
        }

        [Test]
        public void Vector_GetScalarProduct_EmptyVectorSecondArgument()
        {
            var vector1 = new Vector(new[] { 7.0, 2.0, 3.0, 5.0 });
            var vector2 = new Vector(4);

            const double result = 0;

            Assert.AreEqual(Vector.GetScalarProduct(vector1, vector2), result, "should be 0");
        }

        [Test]
        public void Vector_GetScalarProduct_EmptyVectorsArguments()
        {
            var vector1 = new Vector(4);
            var vector2 = new Vector(4);

            const int result = 0;

            Assert.AreEqual(Vector.GetScalarProduct(vector1, vector2), result, "should be 0");
        }

        [Test]
        public void Vector_GetScalarProduct_VectorsOtherDimensionsArguments()
        {
            var vector1 = new Vector(new[] { 7.0, 2.0, 3.0, 5.0 });
            var vector2 = new Vector(new[] { 3.0, 4.0 });

            const double result = 29;

            Assert.AreEqual(Vector.GetScalarProduct(vector1, vector2), result, "should be 29");
        }

        [Test]
        public void Vector_GetScalarProduct_VectorsSameDimensionsArgument()
        {
            var vector1 = new Vector(new[] { 7.0, 2.0, 3.0, 5.0 });
            var vector2 = new Vector(new[] { 3.0, 4.0, 8.0, 11.0 });

            const double result = 108;

            Assert.AreEqual(Vector.GetScalarProduct(vector1, vector2), result, "should be 108");
        }
    }
}
