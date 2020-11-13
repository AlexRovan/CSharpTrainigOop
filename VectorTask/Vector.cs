using System;
using System.Linq;

namespace VectorTask
{
    class Vector
    {
        private double[] elements;

        public Vector(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException($"Размерность вектора должна быть больше 1, получено - {nameof(length)}", nameof(length));
            }

            elements = new double[length];
        }

        public Vector(Vector vector)
        {
            elements = new double[vector.elements.Length];
            Array.Copy(vector.elements, elements, vector.elements.Length);
            //elements = (double[])vector.elements.Clone();
        }

        public Vector(double[] array)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException($"Размерность массива для создания вектора должна быть больше 0, получено - {nameof(array.Length)}", nameof(array.Length));
            }

            elements = new double[array.Length];
            Array.Copy(array, elements, array.Length);
        }

        public Vector(double[] array, int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException($"Размерность должна быть больше 1, получено - {nameof(length)}", nameof(length));
            }

            if (array.Length < 1)
            {
                throw new ArgumentException($"Размерность массива для создания вектора должна быть больше 0, получено - {nameof(array.Length)}", nameof(array.Length));
            }

            elements = new double[length];
            Array.Copy(array, elements, array.Length);
        }

        public int GetSize()
        {
            return elements.Length;
        }

        public void Add(Vector vector)
        {
            double[] copyElements = new double[vector.elements.Length];
            Array.Copy(vector.elements, copyElements, copyElements.Length);

            if (elements.Length < vector.elements.Length)
            {
                Array.Resize(ref elements, copyElements.Length);
            }

            for (int i = 0; i < copyElements.Length; i++)
            {
                elements[i] += copyElements[i];
            }
        }

        public void Subtract(Vector vector)
        {
            double[] copyElements = new double[vector.elements.Length];
            Array.Copy(vector.elements, copyElements, copyElements.Length);

            if (elements.Length < vector.elements.Length)
            {
                Array.Resize(ref elements, copyElements.Length);
            }

            for (int i = 0; i < copyElements.Length; i++)
            {
                elements[i] -= copyElements[i];
            }
        }

        public void MultiplyScalar(double number)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] *= number;
            }
        }

        public void Reverse()
        {
            MultiplyScalar(-1);
        }

        public double GetLength()
        {
            double sum = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                sum += Math.Pow(elements[i], 2);
            }

            return Math.Sqrt(sum);
        }

        public void SetComponentByIndex(int index, double value)
        {
            elements[index] = value;
        }

        public double GetComponentByIndex(int index)
        {
            return elements[index];
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", elements)}}}";
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

            return GetSize() == vector.GetSize() && elements.SequenceEqual(vector.elements);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            foreach (double e in elements)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1);
            resultVector.Add(vector2);

            return resultVector;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1);
            resultVector.Subtract(vector2);

            return resultVector;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            return vector1.GetLength() * vector2.GetLength();
        }
    }
}