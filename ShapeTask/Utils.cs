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
            Array.Sort(shapeArray, new ShapeAreaComparer());

            return shapeArray[number];
        }

        public static IShape GetShapeByNumberPerimeterSize(IShape[] shapeArray, int number)
        {
            Array.Sort(shapeArray, new ShapePerimeterComparer());

            return shapeArray[number];
        }
    }
}
