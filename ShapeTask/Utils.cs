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
            if (number < 1)
            {
                throw new ArgumentException($"Порядковый номер не может быть меньше 1. Введён - {number}", nameof(number));
            }

            if(shapeArray.Length == 0)
            {
                throw new ArgumentException($"Массив не может быть пустым. Длина массива - {shapeArray.Length}", nameof(shapeArray.Length));
            }

            Array.Sort(shapeArray, new ShapeAreaComparer());

            return shapeArray[shapeArray.Length - number];
        }

        public static IShape GetShapeByNumberPerimeterSize(IShape[] shapeArray, int number)
        {
            if (number < 1)
            {
                throw new ArgumentException($"Порядковый номер не может быть меньше 1. Введён - {number}", nameof(number));
            }

            if (shapeArray.Length == 0)
            {
                throw new ArgumentException($"Массив не может быть пустым. Длина массива - {shapeArray.Length}", nameof(shapeArray.Length));
            }

            Array.Sort(shapeArray, new ShapePerimeterComparer());

            return shapeArray[shapeArray.Length - number];
        }
    }
}
