using System;

namespace ShapeTask.Shape
{
    public class Triangle : IShape
    {
        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        public double X3 { get; set; }

        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            return GetLength(X1, X2, X3);
        }

        public double GetHeight()
        {
            return GetLength(Y1, Y2, Y3);
        }

        public double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - GetLengthSide(X1, X2, Y1, Y2)) * (halfPerimeter - GetLengthSide(X1, X3, Y1, Y3)) * (halfPerimeter - GetLengthSide(X2, X3, Y2, Y3)));
        }

        public double GetPerimeter()
        {
            return GetLengthSide(X1, X2, Y1, Y2) + GetLengthSide(X1, X3, Y1, Y3) + GetLengthSide(X2, X3, Y2, Y3);
        }

        private static double GetLengthSide(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        private static double GetLength(double x1, double x2, double x3)
        {
            return GetMaxNumber(x1, x2, x3) - GetMinNumber(x1, x2, x3);
        }

        private static double GetMaxNumber(double number1, double number2, double number3)
        {
            return Math.Max(number1, Math.Max(number2, number3));
        }

        private static double GetMinNumber(double number1, double number2, double number3)
        {
            return Math.Min(number1, Math.Min(number2, number3));
        }

        public override string ToString()
        {
            return $"Треугольник с вершинами в координатах ({X1}, {Y1}), ({X2}, {Y2}) и ({X3}, {Y3})";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return X1 == triangle.X1 && Y1 == triangle.Y1 && X2 == triangle.X2 && Y2 == triangle.Y2 && X3 == triangle.X3 && Y3 == triangle.Y3;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}
