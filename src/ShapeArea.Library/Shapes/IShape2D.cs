namespace ShapeArea.Library.Shapes;

public interface IShape2D // area is behavior of 2d objects
{
    /// <exception cref="OverflowException"></exception>
    public double Area { get; }

}