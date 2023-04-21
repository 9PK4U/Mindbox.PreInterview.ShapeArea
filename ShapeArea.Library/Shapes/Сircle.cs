using System;

namespace ShapeArea.Library.Shapes;

/// <exception cref = "ArgumentException" ></ exception > 
public record struct Circle(double Radius) : IShape2D
{
    public double Radius { get; } = ValidateHelper.EnsureNotNegativeValue(Radius);

    public double Area =>
        ValidateHelper.EnsureNotInfinityValue(Radius * Radius * Math.PI);

}