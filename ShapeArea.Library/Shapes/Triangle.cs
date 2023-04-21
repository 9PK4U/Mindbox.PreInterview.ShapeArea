namespace ShapeArea.Library.Shapes;

public record struct Triangle : IShape2D
{
    public readonly double A { get; }
    public readonly double B { get; }
    public readonly double C { get; }

    private double? _area = null; // parody of lazy

    /// <exception cref="ArgumentException"></exception>
    public Triangle(double a, double b, double c)
    {
        //exceptions in constructor generate empty objects (extra gb work)
        A = ValidateHelper.EnsureNotNegativeValue(a, nameof(a));
        B = ValidateHelper.EnsureNotNegativeValue(b, nameof(b));
        C = ValidateHelper.EnsureNotNegativeValue(c, nameof(c));

        if (!IsValidSides(A, B, C))
            throw new ArgumentException(
                "Impossible to create a triangle according to the given parameters");
    }

    public double Area => _area ?? CalculateArea();

    public double Perimeter => A + B + C;

    public bool IsRight => IsRightTriangle(A, B, C);

    public static bool IsValidSides(double a, double b, double c) =>
        a + b > c && a + c > b && b + c > a;

    public static bool IsRightTriangle(double a, double b, double c) =>
        (a* a + b* b == c* c) ||
        (a* a + c* c == b* b) ||
        (c* c + b* b == a* a);


    private double CalculateArea()
    {
        var p = Perimeter / 2;
        _area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));

        ValidateHelper.EnsureNotInfinityValue(_area.Value);

        return _area.Value;
    }
}