using System;
using VectorTask;

namespace MatrixTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(new double[3] { 2, 5, 9 });
            Vector vector2 = new Vector(new double[3] { 3, 4, 4 });
            Vector vector3 = new Vector(new double[3] { 7, 2, 3 });
            Vector vector4 = new Vector(new double[7]);

            double[,] array =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9}
            };

            Matrix matrix1 = new Matrix(new Vector[3] { vector1, vector2, vector3 });
            Console.WriteLine($"Матрица1: {matrix1}");

            Matrix matrix2 = new Matrix(array);
            Console.WriteLine($"Матрица2: {matrix2}");

            Matrix matrix3 = new Matrix(3, 3);
            Console.WriteLine($"Матрица3: {matrix3}");

            Matrix copyMatrix = new Matrix(matrix1);
            Console.WriteLine($"Копия матрицы1: {copyMatrix}");

            Console.WriteLine($"Определитель матрицы1: {matrix1.GetDeterminant()}");
            Console.WriteLine($"Определитель матрицы2: {matrix2.GetDeterminant()}");

            Console.WriteLine($"Столбец 2 матрицы1 {matrix1.GetColumn(2)}");
            Console.WriteLine($"Строка 3 матрицы1 {matrix1.GetRow(2)}");

            matrix1.Transpose();
            Console.WriteLine($"Транспонированая матрица1: {matrix1}");

            matrix3.Add(matrix2);
            Console.WriteLine($"К матрице3 прибавли матрицу2: {matrix3}");

            matrix3.Subtract(matrix1);
            Console.WriteLine($"От матрицы3 отняли матрицу1: {matrix3}");

            matrix3.MultiplyByScalar(2);
            Console.WriteLine($"Матрицу3 умножили на 2: {matrix3}");

            Console.WriteLine($"Матрицу3 умножили на вектор1: {matrix3.MultiplyByVector(vector3)}");

            Console.WriteLine($"Произведение матриц 1 и 2 {Matrix.GetProduct(matrix1, matrix2)}");
            Console.WriteLine($"Сумма матриц 1 и 2 {Matrix.GetSum(matrix1, matrix2)}");
            Console.WriteLine($"Разность матриц 1 и 2 {Matrix.GetDifference(matrix1, matrix2)}");
        }
    }
}
