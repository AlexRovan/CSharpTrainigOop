using System;
using ShapeTask.Shape;

namespace ShapeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapesArray =
            {
                new Square(5.0),
                new Rectangle(5.0, 10.0),
                new Circle(7.0),
                new Triangle(-1.0, -2.0, 1.0, 4.0, 8.0, 6.0),
                new Square(5.8),
                new Rectangle(3.0, 12.5),
                new Circle(4.0),
                new Triangle(0.0, 0.0, -1.0, -4.0, 3.0, 6.0)
            };

            Console.WriteLine("Информация о фигуре с самой большой площадью:");
            Utils.PrintShapeInfo(Utils.GetShapeByNumberAreaSize(shapesArray, shapesArray.Length - 1));

            Console.WriteLine();
            Console.WriteLine("Информация о фигуре со вторым по величиене периметром");
            Utils.PrintShapeInfo(Utils.GetShapeByNumberPerimeterSize(shapesArray, shapesArray.Length - 2));
        }
    }
}
