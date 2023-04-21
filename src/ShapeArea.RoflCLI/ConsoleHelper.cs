using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace ShapeArea.RoflCLI
{
    internal class ConsoleHelper
    {
        public static T ConsoleSelect<T>(T[] values, string selectableName, Func<T, string> stringConvert)
        {
            if (!values.Any())
            {
                throw new ArgumentException("values array is empty");
            }

            Console.WriteLine($"Select {selectableName} number:");

            while (true)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {stringConvert.Invoke(values[i])}");
                }

                Console.Write("Input: ");
                if (!int.TryParse(Console.ReadLine(), out int selectedNumber)
                || selectedNumber > values.Count()
                || selectedNumber <= 0)
                {
                    Console.WriteLine($"Invalid, please enter a number from 1 to {values.Length}");
                    continue;
                }

                return values[selectedNumber - 1];
            }
        }

        public static object[] ConsoleInputParams(ConstructorInfo ctor)
        {
            var ctorParams = ctor.GetParameters();

            var inputParamsValues = new List<object>();

            var culture = new CultureInfo("en");

            foreach (var param in ctorParams)
            {
                var converter = TypeDescriptor.GetConverter(param.ParameterType);

                if (converter is null)
                    throw new InvalidProgramException("No converter found for interacting with the console");

                while (true)
                {
                    Console.WriteLine($"Input {param.Name} ({param.ParameterType.Name})");
                    try
                    {
                        Console.Write($"{param.Name}: ");
                        var result = converter.ConvertFromString(
                            null,
                            culture,
                            Console.ReadLine()?.Replace(',', '.') ?? string.Empty);

                        if (result == null) throw new ArgumentException();

                        inputParamsValues.Add(result);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Incorrect");
                        continue;
                    }

                    break;
                }
            }

            return inputParamsValues.ToArray();
        }
    }
}
