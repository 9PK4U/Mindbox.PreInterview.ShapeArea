using FluentAssertions;
using ShapeArea.Library.Shapes;
using System.Drawing;

namespace ShapeArea.Library.UnitTests;

public class ShapeTests
{
    [Test]
    public void ShouldReturnCorrectCircleArea()
    {
        var circle = new Circle(5);
        var circle2 = new Circle(10.5);
        var circle3 = new Circle(1);

        circle.Area.Should().Be(78.53981633974483);
        circle2.Area.Should().Be(346.3605900582747);
        circle3.Area.Should().Be(Math.PI);
    }


    [Test]
    public void ShouldReturnCorrectTriangleArea()
    {
        var triangle = new Triangle(1, 1, 1);
        var triangle2 = new Triangle(10, 12, 11);
        var triangle3 = new Triangle(168.5, 166.1, 4.8);


        triangle.Area.Should().Be(0.4330127018922193);
        triangle2.Area.Should().Be(51.521233486786784);
        triangle3.Area.Should().Be(347.6907384443861);
    }

    [Test]
    public void ShouldReturnCorrectTriangleIsRight()
    {
        var triangle = new Triangle(1, 1, 1);
        var triangle2 = new Triangle(3.5, 2.1, 2.8);


        triangle.IsRight.Should().Be(false);
        triangle2.IsRight.Should().Be(true);
    }

    [Test]
    public void ShouldThrowOverflowExceptionCircleArea()
    {
        FluentActions.Invoking(() => new Circle(double.MaxValue).Area)
            .Should().Throw<OverflowException>();

        FluentActions.Invoking(() => new Triangle(double.MaxValue, double.MaxValue, double.MaxValue).Area)
            .Should().Throw<OverflowException>();
    }

    [Test]
    public void ShouldThrowArgumentExceptionCircleArea()
    {
        FluentActions.Invoking(() => new Circle(-1))
            .Should().Throw<ArgumentException>();

        FluentActions.Invoking(() => new Triangle(-1, 1, 1))
            .Should().Throw<ArgumentException>();

        FluentActions.Invoking(() => new Triangle(1, 2, 4))
            .Should().Throw<ArgumentException>();
    }
}