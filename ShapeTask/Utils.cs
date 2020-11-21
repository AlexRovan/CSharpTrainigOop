using System;
using ShapeTask.Comparators;

namespace ShapeTask
{
    class Utils
    {
        public static void PrintShapeInfo(IShape shape)
        {
            Console.WriteLine($"Название фигуры - {shape}");
            Console.WriteLine($"Выстота - {shape.GetHeight()}");
            Console.WriteLine($"Ширина - {shape.GetWidth()}");
            Console.WriteLine($"Площадь - {shape.GetArea()}");
            Console.WriteLine($"Периметр - {shape.GetPerimeter()}");
        }

        public static IShape GetShapeByNumberAreaSize(IShape[] shapeArray, int number)
        {
            if (shapeArray.Length == 0)
            {
                throw new ArgumentException($"Массив не может быть пустым. Длина массива - {shapeArray.Length}", nameof(shapeArray.Length));
            }

            if (number < 1 || number >= shapeArray.Length)
            {
                throw new ArgumentException($"Порядковый номер фигуры по площади может быть только от 1 до {shapeArray.Length}. Введён - {number}", nameof(number));
            }

            Array.Sort(shapeArray, new ShapeAreaComparer());

            return shapeArray[shapeArray.Length - number];
        }

        public static IShape GetShapeByNumberPerimeterSize(IShape[] shapeArray, int number)
        {
            if (shapeArray.Length == 0)
            {
                throw new ArgumentException($"Массив не может быть пустым. Длина массива - {shapeArray.Length}", nameof(shapeArray.Length));
            }

            if (number < 1 || number >= shapeArray.Length)
            {
                throw new ArgumentException($"Порядковый номер фмгуры по периметру может быть только от 1 до {shapeArray.Length}. Введён - {number}", nameof(number));
            }

            Array.Sort(shapeArray, new ShapePerimeterComparer());

            return shapeArray[shapeArray.Length - number];
        }
    }
}
