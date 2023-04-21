using ShapeArea.Library;
using ShapeArea.Library.Shapes;
using System;

namespace ShapeArea.CLI
{
    internal record struct Square(double A, double B) : IShape2D
    {
        public double A { get; } = ValidateHelper.EnsureNotNegativeValue(A, nameof(A));
        public double B { get; } = ValidateHelper.EnsureNotNegativeValue(B, nameof(B));
        public double Area => ValidateHelper.EnsureNotInfinityValue(A * B);
    }
}
