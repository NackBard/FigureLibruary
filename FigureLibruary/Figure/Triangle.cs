using FigureLibruary.Interface;

namespace FigureLibruary.Figure
{
    public class Triangle : IFigure
    {
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
            Array.Reverse(sides);
        }

        public bool IsRectangle()
        {
            return sides[1] * sides[1] + sides[2] * sides[2] == sides[0] * sides[0];
        }

        public double GetArea()
        {
            double semiperimeter = sides.Sum() / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - sides[0])
                * (semiperimeter - sides[1]) * (semiperimeter - sides[2]));
        }

    }
}
