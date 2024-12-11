using FigureLibruary.Interface;

namespace FigureLibruary.Figure
{
    public class Circle : IFigure
    {
        private double radius;

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус дольже быть положительным числом");

            this.radius = radius;
        }

        public double GetArea() => Math.PI * radius * radius;
    }
}
