using System;
using System.Linq;

namespace VectorTask
{
    class Vector
    {
        public double[] VectorElements { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность не можеть быть меньше 1");
            }

            VectorElements = new double[n];
        }

        public Vector(Vector vector)
        {
            VectorElements = (double[])vector.VectorElements.Clone();
        }

        public Vector(double[] array)
        {
            VectorElements = array;
        }

        public Vector(double[] array, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность не можеть быть меньше 1");
            }

            VectorElements = new double[n];

            for (int i = 0; i < array.Length; i++)
            {
                VectorElements[i] = array[i];
            }
        }

        public int GetSize()
        {
            return VectorElements.Length;
        }

        public void AddVector(Vector vector)
        {
            if (VectorElements.Length < vector.VectorElements.Length)
            {
                IncreaseVectorLentghWithZeros(this, vector.VectorElements.Length);
            }

            for (int i = 0; i < vector.VectorElements.Length; i++)
            {
                VectorElements[i] = VectorElements[i] + vector.VectorElements[i];
            }
        }

        public void SubtractionVector(Vector vector)
        {
            if (VectorElements.Length < vector.VectorElements.Length)
            {
                IncreaseVectorLentghWithZeros(this, vector.VectorElements.Length);
            }

            for (int i = 0; i < vector.VectorElements.Length; i++)
            {
                VectorElements[i] = VectorElements[i] - vector.VectorElements[i];
            }
        }

        public void ScalarMultiplication(Vector vector)
        {
            if (VectorElements.Length < vector.VectorElements.Length)
            {
                IncreaseVectorLentghWithZeros(this, vector.VectorElements.Length);

                for (int i = 0; i < VectorElements.Length; i++)
                {
                    VectorElements[i] = vector.VectorElements[i] * VectorElements[i];
                }
            }
            else if (VectorElements.Length > vector.VectorElements.Length)
            {
                Vector copiedVector = new Vector(vector);
                IncreaseVectorLentghWithZeros(copiedVector, VectorElements.Length);

                for (int i = 0; i < VectorElements.Length; i++)
                {
                    VectorElements[i] = copiedVector.VectorElements[i] * VectorElements[i];
                }
            }
            else
            {
                for (int i = 0; i < VectorElements.Length; i++)
                {
                    VectorElements[i] = vector.VectorElements[i] * VectorElements[i];
                }
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < VectorElements.Length; i++)
            {
                VectorElements[i] = -1 * VectorElements[i];
            }
        }

        public double GetLength()
        {
            double vectorLength = 0;

            for (int i = 0; i < VectorElements.Length; i++)
            {
                vectorLength += Math.Pow(VectorElements[i], 2);
            }

            return Math.Sqrt(vectorLength);
        }

        public void SetComponentByIndex(int index, double value)
        {
            VectorElements[index] = value;
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", VectorElements)}}}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            return GetSize() == vector.GetSize() && Enumerable.SequenceEqual(VectorElements, vector.VectorElements);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + GetSize().GetHashCode();

            foreach (double e in VectorElements)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        private static void IncreaseVectorLentghWithZeros(Vector vector, int length)
        {
            Vector copiedVector = new Vector(vector);
            vector.VectorElements = new double[length];

            for (int i = 0; i < copiedVector.VectorElements.Length; i++)
            {
                vector.VectorElements[i] = copiedVector.VectorElements[i];
            }
        }

        public static Vector Addition(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1);
            resultVector.AddVector(vector2);

            return resultVector;
        }

        public static Vector Subtracting(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1);
            resultVector.SubtractionVector(vector2);

            return resultVector;
        }

        public static Vector ScalarMultiplication(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1);
            resultVector.ScalarMultiplication(vector2);

            return resultVector;
        }
    }
}