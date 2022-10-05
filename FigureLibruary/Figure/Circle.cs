using FigureLibruary.Interface;

namespace FigureLibruary.Figure
{
    public class Circle : IFigure
    {
        // Радиус окружности
        private double r;

        /// <summary>Конструктор окружности</summary>
        /// <param name="r">Радиус окружности</param> 
        public Circle(double r)
        {
            if (r <= 0)
                throw new ArgumentException("Радиус дольже быть положительным числом");

            this.r = r;
        }

        // Метод подсчёта площади окружности
        public double GetArea() => Math.PI * r * r;
    }
}
