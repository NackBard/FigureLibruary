using FigureLibruary.Interface;

namespace FigureLibruary.Figure
{
    public class Triangle : IFigure
    {
        // Стороны треугольника
        double[] Sides;

        // Проверка, является ли треугольник прямоугольным
        // Не использовал метод Math.Pow для достижения максимальной скорости вычисления
        public bool IsRight => Sides[0] * Sides[0] + Sides[1] * Sides[1] == Sides[2] * Sides[2];

        /// <summary>Конструктор треугольника</summary>
        /// <param name="a">Сторона треугольника А</param>
        /// <param name="b">Сторона треугольника B</param>
        /// <param name="c">Сторона треугольника C</param>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Стороны треугольника должны быть положительным числом");

            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Треугольник не существует");

            Sides = new[] { a, b, c };
        }

        // Метод подсчёта площади треугольника
        public double GetArea()
        {
            var p = Sides.Sum() / 2;
            return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
        }

    }
}
