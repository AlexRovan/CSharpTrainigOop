namespace ShapeTask.Shape
{
    public class Square : IShape
    {
        public double sideLength { get; set; }

        public Square(double length)
        {
            sideLength = length;
        }

        public double GetWidth()
        {
            return sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetArea()
        {
            return sideLength * sideLength;
        }

        public double GetPerimeter()
        {
            return 4 * sideLength;
        }

        public override string ToString()
        {
            return $"Квадрат с длиной сторон - {sideLength} ";
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

            return sideLength == square.sideLength;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + sideLength.GetHashCode();

            return hash;
        }
    }
}
