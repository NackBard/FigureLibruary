using FigureLibruary.Interface;

namespace FigureLibruary.Figure
{
    public class Triangle : IFigure
    {
        private double[] sides;

        public bool IsRight => Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Стороны треугольника должны быть положительным числом");

            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Треугольник не существует");

            sides = new[] { a, b, c };
        }

        public double GetArea()
        {
            double p = sides.Sum() / 2;
            return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
        }
    }
}
