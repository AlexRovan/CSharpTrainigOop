using System;
using System.Linq;

namespace VectorTask
{
    public class Vector
    {
        private double[] elements;

        public Vector(double[] array)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException($"Размерность массива для создания вектора должна быть больше 0, получено: {array.Length}", nameof(array.Length));
            }

            elements = new double[array.Length];
            Array.Copy(array, elements, array.Length);
        }

        public Vector(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException($"Размерность для создания вектора должна быть больше 0, получено: {size}", nameof(size));
            }

            elements = new double[size];
        }

        public Vector(Vector vector)
        {
            elements = new double[vector.elements.Length];
            Array.Copy(vector.elements, elements, vector.elements.Length);
        }

        public Vector(double[] array, int size)
        {
            if (size < 1)
            {
                throw new ArgumentException($"Размерность для создания вектора должна быть больше 0, получено: {size}", nameof(size));
            }

            if (size < array.Length)
            {
                throw new ArgumentException($"Размер массива {array.Length} не может быть меньше заданного размера вектора: {size}.", nameof(array.Length));
            }

            elements = new double[size];
            Array.Copy(array, elements, array.Length);
        }

        public double GetElementByIndex(int index)
        {
            return elements[index];
        }

        public void SetElementByIndex(int index, double value)
        {
            elements[index] = value;
        }

        public int GetSize()
        {
            return elements.Length;
        }

        public void Add(Vector vector)
        {
            if (elements.Length < vector.elements.Length)
            {
                double[] copyElements = new double[vector.elements.Length];
                Array.Copy(vector.elements, copyElements, copyElements.Length);

                Array.Resize(ref elements, copyElements.Length);

                for (int i = 0; i < copyElements.Length; i++)
                {
                    elements[i] += copyElements[i];
                }
            }
            else
            {
                for (int i = 0; i < vector.elements.Length; i++)
                {
                    elements[i] += vector.elements[i];
                }
            }
        }

        public void Subtract(Vector vector)
        {
            if (elements.Length < vector.elements.Length)
            {
                double[] copyElements = new double[vector.elements.Length];
                Array.Copy(vector.elements, copyElements, copyElements.Length);

                Array.Resize(ref elements, copyElements.Length);

                for (int i = 0; i < copyElements.Length; i++)
                {
                    elements[i] -= copyElements[i];
                }
            }
            else
            {
                for (int i = 0; i < vector.elements.Length; i++)
                {
                    elements[i] -= vector.elements[i];
                }
            }
        }

        public void MultiplyOnScalar(double number)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] *= number;
            }
        }

        public void Reverse()
        {
            MultiplyOnScalar(-1);
        }

        public double GetLength()
        {
            double sum = 0;

            foreach (double e in elements)
            {
                sum += Math.Pow(e, 2);
            }

            return Math.Sqrt(sum);
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

        public static double GetScalarComposition(Vector vector1, Vector vector2)
        {
            double result = 0;

            for (int i = 0; i < Math.Min(vector1.elements.Length, vector2.elements.Length); i++)
            {
                result += (vector1.elements[i] * vector2.elements[i]);
            }

            return result;
        }
    }
}