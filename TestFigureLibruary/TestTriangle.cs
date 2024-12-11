using FigureLibruary.Figure;
using Xunit;

namespace TestFigureLibruary
{
    public class TestTriangle
    {
        [Fact]
        public void GetArea_ReturnCorrectValue()
        {
            Assert.Equal(1.984313483298443, new Triangle(2, 2, 3).GetArea());
            Assert.Equal(6, new Triangle(3, 4, 5).GetArea());
        }

        [Fact]
        public void Contructor_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 0));
            Assert.Throws<ArgumentException>(() => new Triangle(1, 0, 1));
            Assert.Throws<ArgumentException>(() => new Triangle(0, 1, 1));

            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3));
            Assert.Throws<ArgumentException>(() => new Triangle(2, 1, 3));
            Assert.Throws<ArgumentException>(() => new Triangle(3, 2, 1));
        }

        [Fact]
        public void IsRectangle_ReturnCorrectValue()
        {
            Assert.False(new Triangle(2, 2, 3).IsRectangle());
            Assert.True(new Triangle(3, 4, 5).IsRectangle());
        }
    }
}
