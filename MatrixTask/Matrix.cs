using System;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] matrixRows;

        public Matrix(int numberRows, int numberColumns)
        {
            if (numberRows < 1 || numberColumns < 1)
            {
                throw new ArgumentException($"Размер матрицы должен быть больше 0, передан размер {numberRows}*{numberColumns}");
            }

            matrixRows = new Vector[numberRows];

            for (int i = 0; i < numberRows; i++)
            {
                matrixRows[i] = new Vector(numberColumns);
            }
        }

        public Matrix(Matrix matrix)
        {
            matrixRows = new Vector[matrix.matrixRows.Length];

            for (int i = 0; i < matrix.GetCountRows(); i++)
            {
                matrixRows[i] = new Vector(matrix.GetLine(i));
            }
        }

        public Matrix(double[,] matrix)
        {
            if (matrix.Length == 0)
            {
                throw new ArgumentException("В матрице нет элементов для копированя.");
            }

            matrixRows = new Vector[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double[] array = new double[matrix.GetLength(1)];

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[j] = matrix[i, j];
                }

                matrixRows[i] = new Vector(array);
            }
        }

        public Matrix(Vector[] vectors)
        {
            matrixRows = new Vector[vectors.Length];
            int rowSize = GetMaxRowSize(vectors);

            for (int i = 0; i < vectors.Length; i++)
            {
                double[] array = new double[rowSize];

                for (int j = 0; j < vectors[i].GetSize(); j++)
                {
                    array[j] = vectors[i].GetElementByIndex(j);

                }

                matrixRows[i] = new Vector(array);
            }
        }

        static private int GetMaxRowSize(Vector[] vectors)
        {
            int max = 0;

            foreach (Vector vector in vectors)
            {
                if (max < vector.GetSize())
                {
                    max = vector.GetSize();
                }
            }

            return max;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            foreach (Vector e in matrixRows)
            {
                sb.Append(e.ToString()).Append(", ");
            }

            return sb.Remove(sb.Length - 2, 2).Append("}").ToString();
        }

        public int GetCountRows()
        {
            return matrixRows.Length;
        }

        public int GetCountColumns()
        {
            if (matrixRows.Length == 0)
            {
                throw new InvalidOperationException("Нельзя получить кол-во столбцов для пустой матрицы");
            }

            return matrixRows[0].GetSize();
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index > GetCountColumns() - 1)
            {
                throw new ArgumentOutOfRangeException($"Столбца с индексом {index} нет в матрице. Досупен диапазаон: от 0 до {GetCountColumns() - 1}", nameof(index));
            }

            double[] array = new double[matrixRows.Length];

            for (int i = 0; i < GetCountRows(); i++)
            {
                array[i] = matrixRows[i].GetElementByIndex(index);
            }

            return new Vector(array);
        }

        public Vector GetLine(int index)
        {
            if (index < 0 || index > GetCountRows() - 1)
            {
                throw new ArgumentOutOfRangeException($"Строки с индексом {index} нет в матрице. Досупен диапазаон: от 0 до {GetCountRows() - 1}", nameof(index));
            }

            return new Vector(matrixRows[index]);
        }

        public void Transpose()
        {
            Matrix newMatrix = new Matrix(GetCountColumns(), GetCountRows());

            for (int i = 0; i < GetCountColumns(); i++)
            {
                for (int j = 0; j < GetCountRows(); j++)
                {
                    double temp = matrixRows[j].GetElementByIndex(i);
                    newMatrix.matrixRows[i].SetElementByIndex(j, temp);
                }
            }

            matrixRows = newMatrix.matrixRows;
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (vector.GetSize() != GetCountColumns())
            {
                throw new ArgumentException($"Размер вектора {vector.GetSize()} должен совпадать с количеством стобцов матрицы {GetCountColumns()}.");
            }

            double[] array = new double[vector.GetSize()];

            for (int i = 0; i < vector.GetSize(); i++)
            {
                array[i] = Vector.GetScalarProduct(matrixRows[i], vector);
            }

            return new Vector(array);
        }

        public void MultiplyByScalar(double number)
        {
            for (int i = 0; i < matrixRows.Length; i++)
            {
                matrixRows[i].MultiplyByScalar(number);
            }
        }

        public void Add(Matrix matrix)
        {
            СheckMatrixDimension(matrix);

            for (int i = 0; i < matrixRows.Length; i++)
            {
                matrixRows[i].Add(matrix.matrixRows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            СheckMatrixDimension(matrix);

            for (int i = 0; i < matrixRows.Length; i++)
            {
                matrixRows[i].Subtract(matrix.matrixRows[i]);
            }
        }

        public double GetDeterminant()
        {
            if (GetCountColumns() != GetCountRows())
            {
                throw new InvalidOperationException($"Найти оперделитель можно только для квадратной матрицы. Текущий размер: {GetCountColumns()}*{GetCountRows()}");
            }

            if (GetCountRows() == 1)
            {
                return matrixRows[0].GetElementByIndex(0);
            }

            if (GetCountRows() == 2)
            {
                return matrixRows[0].GetElementByIndex(0) * matrixRows[1].GetElementByIndex(1) - matrixRows[0].GetElementByIndex(1) * matrixRows[1].GetElementByIndex(0);
            }

            double result = 0;
            for (int i = 0; i < GetCountRows(); i++)
            {
                for (int j = 0; j < GetCountRows(); j++)
                {
                    Matrix minorMatrix = GetMatrixMinor(i, j);
                    result += ((i + 1) % 2 == 0 ? 1 : -1) * matrixRows[1].GetElementByIndex(i) * minorMatrix.GetDeterminant();
                }
            }

            return result;
        }

        private Matrix GetMatrixMinor(int rowIndex, int columnIndex)
        {
            double[,] array = new double[GetCountRows() - 1, GetCountColumns() - 1];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i < columnIndex && j < rowIndex)
                    {
                        array[i, j] = matrixRows[i].GetElementByIndex(j);
                    }
                    else if (i >= columnIndex && j < rowIndex)
                    {
                        array[i, j] = matrixRows[i + 1].GetElementByIndex(j);
                    }
                    else if (i < columnIndex && j >= rowIndex)
                    {
                        array[i, j] = matrixRows[i].GetElementByIndex(j + 1);
                    }
                    else
                    {
                        array[i, j] = matrixRows[i + 1].GetElementByIndex(j + 1);
                    }
                }
            }

            return new Matrix(array);
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            СheckMatrixDimension(matrix1, matrix2);

            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Add(matrix2);

            return resultMatrix;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            СheckMatrixDimension(matrix1, matrix2);

            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Subtract(matrix2);

            return resultMatrix;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            СheckMatrixDimension(matrix1, matrix2);

            double[,] array = new double[matrix1.GetCountRows(), matrix2.GetCountColumns()];

            for (int i = 0; i < matrix1.GetCountRows(); i++)
            {
                for (int j = 0; j < matrix1.GetCountColumns(); j++)
                {
                    array[j, i] = Vector.GetScalarProduct(matrix2.GetColumn(i), matrix1.GetLine(j));
                }
            }

            return new Matrix(array);
        }

        private void СheckMatrixDimension(Matrix matrix)
        {
            if (matrix.GetCountRows() != GetCountRows() || matrix.GetCountColumns() != GetCountColumns())
            {
                throw new ArgumentException($"Операцию можно выполнять с матрицей рамзерности {GetCountColumns()}*{GetCountRows()}." +
                $"Размерносить полученной матрицы {matrix.GetCountRows()}*{matrix.GetCountColumns()}");
            }
        }

        private static void СheckMatrixDimension(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetCountRows() != matrix2.GetCountRows() || matrix1.GetCountColumns() != matrix2.GetCountColumns())
            {
                throw new ArgumentException($"Нельзя выполнять операцию с матрицами размерами {matrix2.GetCountRows()}*{matrix2.GetCountColumns()}" +
                    $"на {matrix1.GetCountColumns()}*{matrix1.GetCountRows()}. Количество строк матрицы 1 должно быть равным количеству столбцов матрицы 2");
            }
        }
    }
}
