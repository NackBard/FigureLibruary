using FigureLibruary.Interface;

namespace FigureLibruary.Figure
{
    public sealed class Triangle : ITriangle
    {
        private const double Epsilon = 0.00001;
        private double[] sides;

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Стороны треугольника должны быть больше нуля");

            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Треугольник не существует");

            sides = new[] { a, b, c };

            // сортирую массив, для уменьшения кол-ва кода,
            // что бы выявить большую сторону
            Array.Sort(sides);
        }

        public bool IsRectangle()
        {
            double firstSide = Math.Pow(sides[0], 2);
            double secondSide = Math.Pow(sides[1], 2);
            double hypotenuse = Math.Pow(sides[2], 2);
            return Math.Pow(firstSide + secondSide - hypotenuse, 2) < Epsilon;
        }

        public double GetArea()
        {
            double semiperimeter = sides.Sum() / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - sides[0])
                * (semiperimeter - sides[1]) * (semiperimeter - sides[2]));
        }
    }
}
