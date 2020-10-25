using System;

namespace ShapeTask
{
    public class Square : IShape
    {
        public double Width { get; set; }

        public Square(double width)
        {
            Width = width;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Width;
        }

        public double GetArea()
        {
            return Width * Width;
        }
        public double GetPerimeter()
        {
            return 4 * Width;
        }

        public override string ToString()
        {
            return "Квадрат";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Square square = (Square)obj;

            return Width == square.Width;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Width.GetHashCode();

            return hash;
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return "Прямоугольник";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Rectangle rectangle = (Rectangle)obj;

            return Width == rectangle.Width && Height == rectangle.Height;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Height.GetHashCode();

            return hash;
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }

        public double GetHeight()
        {
            return 2 * Radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return "Круг";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Circle circle = (Circle)obj;

            return Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Radius.GetHashCode();
         
            return hash;
        }
    }
    public class Triangle : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }

        public double Side1 { get; }
        public double Side2 { get; }
        public double Side3 { get; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;

            Side1 = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            Side2 = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));
            Side3 = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
        }

        public double GetWidth()
        {
            return GetMaxPoint(X1, X2, X3) - GetMinPoint(X1, X2, X3);
        }

        public double GetHeight()
        {
            return GetMaxPoint(Y1, Y2, Y3) - GetMinPoint(Y1, Y2, Y3);
        }

        public double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - Side1) * (halfPerimeter - Side2) * (halfPerimeter - Side3));
        }

        public double GetPerimeter()
        {
            return Side1 + Side2 + Side3;
        }

        private double GetMaxPoint(double point1, double point2, double point3)
        {
            return Math.Max(point1, Math.Max(point2, point3));
        }

        private double GetMinPoint(double point1, double point2, double point3)
        {
            return Math.Min(point1, Math.Min(point2, point3));
        }

        public override string ToString()
        {
            return "Треугольник";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return Side1 == triangle.Side1 && Side2 == triangle.Side2 && Side3 == triangle.Side3;
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
            hash = prime * hash + Side1.GetHashCode();
            hash = prime * hash + Side2.GetHashCode();
            hash = prime * hash + Side3.GetHashCode();

            return hash;
        }
    }
}
