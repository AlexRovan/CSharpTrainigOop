using System;

namespace VectorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(new double[4] { 7.0, 2.0, 3.0, 5.0 });
            Vector vector2 = new Vector(new double[6] { 3.0, 4.0, 8.0, 11.0, 9.2, 11 });
            Vector vector3 = new Vector(vector2);
            Vector vector4 = new Vector(new double[4] { 3.0, 1.0, 3.0, 5.0 });
            Vector vector5 = new Vector(new double[4] { 1.0, 1.0, 2.0, 1.0 }, 10);

            Console.WriteLine($"Элементы вектора1 - {vector1}");
            Console.WriteLine($"Элементы вектора2 - {vector2}");
            Console.WriteLine($"Элементы вектора3 - {vector3}");
            Console.WriteLine($"Элементы вектора4 - {vector4}");
            Console.WriteLine($"Элементы вектора4 - {vector5}");
            Console.WriteLine();

            vector1.AddVector(vector2);
            Console.WriteLine($"Прибавим к вектору1 вектор2 - {vector1}");

            vector1.SubtractionVector(vector2);
            Console.WriteLine($"Отнимим от вектора1  вектору2 - {vector1}");

            vector1.ScalarMultiplication(vector2);
            Console.WriteLine($"Умножим вектор1 на вектору2 - {vector1}");

            Console.WriteLine($"Получим длинну вектора1 - {vector1.GetLength()}");

            vector1.Reverse();
            Console.WriteLine($"Разворот вектора1 - {vector1}");

            Console.WriteLine($"Сравнение вектора1 и вектора2 - {vector1.Equals(vector2)}");
            Console.WriteLine($"Сравнение вектора2 и вектора3 - {vector2.Equals(vector3)}");

            Console.WriteLine($"Хэш код вектора1 - {vector1.GetHashCode()}");
            Console.WriteLine($"Хэш код вектора2  - {vector2.GetHashCode()}");
            Console.WriteLine($"Хэш код вектора3  - {vector3.GetHashCode()}");

            Console.WriteLine();
            Console.WriteLine($"Сумма векторов  - {Vector.Addition(vector2, vector4)}");
            Console.WriteLine($"Разность вектора - {Vector.Subtracting(vector2, vector4)}");
            Console.WriteLine($"Произведение векторов - {Vector.ScalarMultiplication(vector2, vector4)}");
        }
    }
}
