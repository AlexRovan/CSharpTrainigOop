using System;
using System.Collections.Generic;
using VectorTask;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] elements;

        public Matrix(int n, int m)
        {
            if (n < 1 || m < 1)
            {
                throw new ArgumentException($"Размер матрицы должен быть больше 0, передан размер {n}*{m}");
            }

            elements = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                elements[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            elements = new Vector[matrix.elements.Length];
            Array.Copy(matrix.elements, elements, matrix.elements.Length);
        }

        public Matrix(double[,] matrix)
        {
            if (matrix.Length == 0)
            {
                throw new ArgumentException();
            }

            elements = new Vector[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double[] array = new double[matrix.GetLength(1)];

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[j] = matrix[i, j];
                }

                elements[i] = new Vector(array);
            }
        }

        public Matrix(Vector[] vectors)
        {
            elements = new Vector[vectors.Length];
            int lineSize = GetMaxLineSize(vectors);

            for (int i = 0; i < vectors.Length; i++)
            {
                double[] array = new double[lineSize];

                for (int j = 0; j < vectors[i].GetSize(); j++)
                {
                    array[j] = vectors[i].GetElementByIndex(j);

                }

                elements[i] = new Vector(array);
            }
        }

        private int GetMaxLineSize(Vector[] vectors)
        {
            int size = 0;

            for (int i = 0; i < vectors.Length; i++)
            {
                if (size < vectors[i].GetSize())
                {
                    size = vectors[i].GetSize();
                }
            }

            return size;
        }

        public override string ToString()
        {
            List<string> stringListElements = new List<string>(elements.Length);

            foreach (Vector e in elements)
            {
                stringListElements.Add(e.ToString());
            }

            return $"{{{string.Join(", ", stringListElements)}}}";
        }

        public int GetLineSize()
        {
            return elements.Length;
        }

        public int GetColumnSize()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException("Нельзя получить кол-во столбцов для пустой матрицы");
            }

            return elements[0].GetSize();
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index > GetColumnSize())
            {
                throw new ArgumentException($"Столбца с индексом {index} нет в матрице. Досупен диапазаон: от 0 до {GetColumnSize()}", nameof(index));
            }

            double[] array = new double[elements.Length];

            for (int i = 0; i < GetLineSize(); i++)
            {
                for (int j = 0; j < GetColumnSize(); j++)
                {
                    if (index == j)
                    {
                        array[i] = elements[i].GetElementByIndex(j);
                    }
                }
            }

            return new Vector(array);
        }

        public Vector GetLine(int index)
        {
            if (index < 0 || index > GetLineSize())
            {
                throw new ArgumentException($"Строки с индексом {index} нет в матрице. Досупен диапазаон: от 0 до {GetLineSize()}", nameof(index));
            }

            return elements[index];
        }

        public void Transpose()
        {
            if (GetColumnSize() != GetLineSize())
            {
                throw new InvalidOperationException($"Транспонировать можно только квадратную матрицу. Текущий размер: {GetColumnSize()}*{GetLineSize()}");
            }

            for (int i = 0; i < GetColumnSize(); i++)
            {
                for (int j = i; j < GetLineSize(); j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    double val = elements[j].GetElementByIndex(i);
                    elements[j].SetElementByIndex(i, elements[i].GetElementByIndex(j));
                    elements[i].SetElementByIndex(j, val);
                }
            }
        }

        public void MultiplyOnVector(Vector vector)
        {
            if (vector.GetSize() != GetColumnSize())
            {
                throw new ArgumentException($"Размер вектора {vector.GetSize()} должен совпадать с количеством стобцов матрицы {GetColumnSize()}.");
            }

            double[] array = new double[vector.GetSize()];

            for (int i = 0; i < vector.GetSize(); i++)
            {
                array[i] = Vector.GetScalarComposition(elements[i], vector);
            }

            elements = new Vector[1] { new Vector(array) };
        }

        public void MultiplyOnScalar(double number)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i].MultiplyOnScalar(number);
            }
        }

        public void Add(Matrix matrix)
        {
            if (matrix.GetLineSize() != GetLineSize() || matrix.GetColumnSize() != GetColumnSize())
            {
                throw new ArgumentException($"Операцию сложения можно выполнять с матрицей рамзерности {GetColumnSize()}*{GetLineSize()}." +
                    $"Размерносить полученной матрицы {matrix.GetColumnSize()}*{matrix.GetLineSize()}");
            }

            for (int i = 0; i < matrix.elements.Length; i++)
            {
                elements[i].Add(matrix.elements[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            throw new ArgumentException($"Операцию разности можно выполнять с матрицей рамзерности {GetColumnSize()}*{GetLineSize()}." +
                $"Размерносить полученной матрицы {matrix.GetColumnSize()}*{matrix.GetLineSize()}");

            for (int i = 0; i < matrix.elements.Length; i++)
            {
                elements[i].Subtract(matrix.elements[i]);
            }
        }

        public double GetDeterminant()
        {
            if (GetColumnSize() != GetLineSize())
            {
                throw new InvalidOperationException($"Найти оперделитель можно только для квадратной матрицуы Текущий размер: {GetColumnSize()}*{GetLineSize()}");
            }

            if (GetLineSize() == 1)
            {
                return elements[0].GetElementByIndex(0);
            }

            if (GetLineSize() == 2)
            {
                return elements[0].GetElementByIndex(0) * elements[1].GetElementByIndex(1) - elements[0].GetElementByIndex(1) * elements[1].GetElementByIndex(0);
            }

            double result = 0;

            for (int i = 0; i < GetLineSize(); i++)
            {
                Matrix minorMatrix = GetMatrixMinor(1, i);
                result += ((i + 1) % 2 == 0 ? 1 : -1) * elements[1].GetElementByIndex(i) * minorMatrix.GetDeterminant();
            }

            return result;
        }

        private Matrix GetMatrixMinor(int numberLine, int numberColumn)
        {
            double[,] array = new double[GetLineSize() - 1, GetColumnSize() - 1];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i < numberColumn && j < numberLine)
                    {
                        array[i, j] = elements[i].GetElementByIndex(j);
                    }
                    else if (i >= numberColumn && j < numberLine)
                    {
                        array[i, j] = elements[i + 1].GetElementByIndex(j);
                    }
                    else if (i < numberColumn && j >= numberLine)
                    {
                        array[i, j] = elements[i].GetElementByIndex(j + 1);
                    }
                    else
                    {
                        array[i, j] = elements[i + 1].GetElementByIndex(j + 1);
                    }
                }
            }

            return new Matrix(array);
        }

        static public Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Add(matrix2);

            return resultMatrix;
        }

        static public Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Subtract(matrix2);

            return resultMatrix;
        }

        static public Matrix GetComposition(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetLineSize() != matrix2.GetColumnSize())
            {
                throw new ArgumentException($"Количество строк матрицы1 {matrix1.GetLineSize()} должен совпадать с количеством стобцов матрицы2 {matrix2.GetColumnSize()}.");
            }

            double[,] array = new double[matrix1.GetLineSize(), matrix2.GetColumnSize()];

            for (int i = 0; i < matrix2.GetColumnSize(); i++)
            {
                for (int j = 0; j < matrix1.GetLineSize(); j++)
                {
                    double val = 0;
                    for (int k = 0; k < matrix2.GetLineSize(); k++)
                    {
                        val += matrix2.elements[k].GetElementByIndex(i) * matrix1.elements[j].GetElementByIndex(k);
                    }
                    array[j, i] = val;
                }
            }

            return new Matrix(array);
        }
    }
}
