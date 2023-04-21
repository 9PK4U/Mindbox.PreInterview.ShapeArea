using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeArea.Library;

public class ValidateHelper
{
    // For .net 7 +
    //public static T EnsureNotNegativeValue<T>(T value) where T : INumber<T>
    //{
    //    return T.IsNegative(value)
    //        ? throw new ArgumentException("Argument cannot be negative.")
    //        : value;
    //}

    //public static T EnsureNotInfinityValue<T>(T value) where T : INumber<T> =>
    //    T.IsInfinity(value) ? throw new OverflowException() : value;

    /// <exception cref="ArgumentException"></exception>
    public static double EnsureNotNegativeValue(double value, string? paramName = null)
    {
        return double.IsNegative(value)
            ? throw new ArgumentException("Argument cannot be negative.", paramName)
            : value;
    }



    /// <exception cref="OverflowException"></exception>
    public static double EnsureNotInfinityValue(double value) =>
        double.IsInfinity(value) ? throw new OverflowException() : value;


}
