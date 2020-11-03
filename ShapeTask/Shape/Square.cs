namespace ShapeTask.Shape
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
            return $"Квадрат с длиной сторон - {Width} ";
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
}
