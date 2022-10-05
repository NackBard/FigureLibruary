using FigureLibruary.Figure;
using Xunit;

namespace TestFigureLibruary
{
    public class TestCircle
    {
        [Fact]
        public void GetArea_ReturnCorrectValue()
        {
            Assert.Equal(3.1415926535897931, new Circle(1).GetArea());
        }

        [Fact]
        public void Contructor_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Circle(0));
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }
    }
}
