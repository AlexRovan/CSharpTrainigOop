using System;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] rows;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount < 1 || columnsCount < 1)
            {
                throw new ArgumentException($"Размер матрицы должен быть больше 0, передан размер {rowsCount}*{columnsCount}");
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.rows.Length];

            for (int i = 0; i < matrix.rows.Length; i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        public Matrix(double[,] matrix)
        {
            if (matrix.Length == 0)
            {
                throw new ArgumentException("В матрице нет элементов для копирования.");
            }

            rows = new Vector[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Vector row = new Vector(matrix.GetLength(1));

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row.SetElementByIndex(j, matrix[i, j]);
                }

                rows[i] = new Vector(row);
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors.Length == 0)
            {
                throw new ArgumentException("В векторе нет элементов для копирования.");
            }

            rows = new Vector[vectors.Length];
            int rowSize = GetMaxRowSize(vectors);

            for (int i = 0; i < vectors.Length; i++)
            {
                double[] array = new double[rowSize];

                for (int j = 0; j < vectors[i].GetSize(); j++)
                {
                    array[j] = vectors[i].GetElementByIndex(j);
                }

                rows[i] = new Vector(array);
            }
        }

        private static int GetMaxRowSize(Vector[] vectors)
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
            foreach (Vector e in rows)
            {
                sb.Append(e).Append(", ");
            }

            return sb.Remove(sb.Length - 2, 2).Append("}").ToString();
        }

        public int GetRowsCount()
        {
            return rows.Length;
        }

        public int GetColumnsCount()
        {
            return rows[0].GetSize();
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= GetColumnsCount())
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Столбца с индексом {index} нет в матрице. Доступен диапазон: от 0 до {GetColumnsCount() - 1}");
            }

            double[] array = new double[rows.Length];

            for (int i = 0; i < GetRowsCount(); i++)
            {
                array[i] = rows[i].GetElementByIndex(index);
            }

            return new Vector(array);
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index > GetRowsCount() - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Строки с индексом {index} нет в матрице. Досупен диапазаон: от 0 до {GetRowsCount() - 1}");
            }

            return new Vector(rows[index]);
        }

        public void Transpose()
        {
            Vector[] transposedRows = new Vector[GetColumnsCount()];

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                transposedRows[i] = GetColumn(i);
            }

            rows = transposedRows;
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (vector.GetSize() != GetColumnsCount())
            {
                throw new ArgumentException($"Размер вектора {vector.GetSize()} должен совпадать с количеством стобцов матрицы {GetColumnsCount()}.");
            }

            double[] array = new double[vector.GetSize()];

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                array[i] = Vector.GetScalarProduct(rows[i], vector);
            }

            return new Vector(array);
        }

        public void MultiplyByScalar(double number)
        {
            foreach (Vector e in rows)
            {
                e.MultiplyByScalar(number);
            }
        }

        public void Add(Matrix matrix)
        {
            CheckMatrixDimension(matrix);

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            CheckMatrixDimension(matrix);

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public double GetDeterminant()
        {
            if (GetColumnsCount() != GetRowsCount())
            {
                throw new InvalidOperationException($"Найти определитель можно только для квадратной матрицы. Текущий размер: {GetColumnsCount()}*{GetRowsCount()}");
            }

            if (GetRowsCount() == 1)
            {
                return rows[0].GetElementByIndex(0);
            }

            if (GetRowsCount() == 2)
            {
                return rows[0].GetElementByIndex(0) * rows[1].GetElementByIndex(1) - rows[0].GetElementByIndex(1) * rows[1].GetElementByIndex(0);
            }

            double result = 0;

            for (int i = 0; i < GetRowsCount(); i++)
            {
                for (int j = 0; j < GetRowsCount(); j++)
                {
                    Matrix minorMatrix = GetMatrixMinor(i, j);
                    result += ((i + 1) % 2 == 0 ? 1 : -1) * rows[1].GetElementByIndex(i) * minorMatrix.GetDeterminant();
                }
            }

            return result;
        }

        private Matrix GetMatrixMinor(int rowIndex, int columnIndex)
        {
            double[,] array = new double[GetRowsCount() - 1, GetColumnsCount() - 1];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i < columnIndex && j < rowIndex)
                    {
                        array[i, j] = rows[i].GetElementByIndex(j);
                    }
                    else if (i >= columnIndex && j < rowIndex)
                    {
                        array[i, j] = rows[i + 1].GetElementByIndex(j);
                    }
                    else if (i < columnIndex && j >= rowIndex)
                    {
                        array[i, j] = rows[i].GetElementByIndex(j + 1);
                    }
                    else
                    {
                        array[i, j] = rows[i + 1].GetElementByIndex(j + 1);
                    }
                }
            }

            return new Matrix(array);
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            CheckMatrixDimension(matrix1, matrix2);

            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Add(matrix2);

            return resultMatrix;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            CheckMatrixDimension(matrix1, matrix2);

            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Subtract(matrix2);

            return resultMatrix;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException($"Количество столбцов матрицы1 {matrix1.GetColumnsCount()} должен совпадать с количеством строк матрицы2 {matrix2.GetRowsCount()}.");
            }

            double[,] array = new double[matrix2.GetRowsCount(), matrix1.GetColumnsCount()];

            for (int i = 0; i < matrix2.GetRowsCount(); i++)
            {
                for (int j = 0; j < matrix1.GetColumnsCount(); j++)
                {
                    array[j, i] = Vector.GetScalarProduct(matrix2.GetColumn(i), matrix1.rows[j]);
                }
            }

            return new Matrix(array);
        }

        private void CheckMatrixDimension(Matrix matrix)
        {
            if (matrix.GetRowsCount() != GetRowsCount() || matrix.GetColumnsCount() != GetColumnsCount())
            {
                throw new ArgumentException($"Операцию можно выполнять с матрицей рамзерности {GetColumnsCount()}*{GetRowsCount()}." +
                $"Размерносить полученной матрицы {matrix.GetRowsCount()}*{matrix.GetColumnsCount()}");
            }
        }

        private static void CheckMatrixDimension(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetRowsCount() != matrix2.GetRowsCount() || matrix1.GetColumnsCount() != matrix2.GetColumnsCount())
            {
                throw new ArgumentException($"Нельзя выполнять операцию с матрицами размерами {matrix2.GetRowsCount()}*{matrix2.GetColumnsCount()}" +
                    $"и {matrix1.GetColumnsCount()}*{matrix1.GetRowsCount()}. Количество строк и столбцов матрицы 1 должно быть равным количеству строк и столбцов матрицы 2");
            }
        }
    }
}
