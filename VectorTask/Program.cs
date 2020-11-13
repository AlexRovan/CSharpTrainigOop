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
            Console.WriteLine($"Элементы вектора5 - {vector5}");
            Console.WriteLine();

            vector1.Add(vector2);
            Console.WriteLine($"Прибавим к вектору1 вектор2 - {vector1}");

            vector1.Subtract(vector2);
            Console.WriteLine($"Отнимим от вектора1  вектор2 - {vector1}");

            vector1.MultiplyScalar(4);
            Console.WriteLine($"Умножим вектор1 на скаляр 4 - {vector1}");

            Console.WriteLine($"Получим длинну вектора1 - {vector1.GetLength()}");

            vector2.Reverse();
            Console.WriteLine($"Разворот вектора2 - {vector2}");

            Console.WriteLine($"Сравнение вектора1 и вектора2 - {vector1.Equals(vector2)}");
            Console.WriteLine($"Сравнение вектора2 и вектора3 - {vector2.Equals(vector3)}");

            Console.WriteLine($"Хэш код вектора1 - {vector1.GetHashCode()}");
            Console.WriteLine($"Хэш код вектора2  - {vector2.GetHashCode()}");
            Console.WriteLine($"Хэш код вектора3  - {vector3.GetHashCode()}");

            Console.WriteLine();
            Console.WriteLine($"Сумма векторов 2 и 4  - {Vector.GetSum(vector2, vector4)}");
            Console.WriteLine($"Разность векторов 2 и 4 - {Vector.GetDifference(vector2, vector4)}");
            Console.WriteLine($"Произведение векторов 2 и 5 - {Vector.GetScalarMultiplication(vector2, vector4)}");
        }
    }
}
