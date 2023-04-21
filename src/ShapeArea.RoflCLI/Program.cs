using ShapeArea.RoflCLI;
using ShapeArea.Library.Shapes;
using System.Reflection;

var currentAssemblyTypes = Assembly.GetExecutingAssembly().GetTypes();

var shapeAssignableTypes = Assembly
    .GetAssembly(typeof(IShape2D))?
    .GetTypes()
    .Union(currentAssemblyTypes) // For square
    .Where(type => type.IsAssignableTo(typeof(IShape2D)) && !type.IsInterface)
    .ToArray();

while (true)
{
    try
    {
        Type selectedType = ConsoleHelper.ConsoleSelect(shapeAssignableTypes!, "shape type", x => x.Name);

        Console.WriteLine($"Selected {selectedType.Name}");

        var ctor = selectedType.GetConstructors().FirstOrDefault()
            ?? throw new InvalidProgramException("No constructor found for this type");

        var enteredParams = ConsoleHelper.ConsoleInputParams(ctor);

        var obj = ctor.Invoke(enteredParams.ToArray());

        var typeProperties = selectedType.GetProperties().ToArray();

        var selectedProp = ConsoleHelper.ConsoleSelect(typeProperties, "property", x => x.Name);

        Console.WriteLine($"{selectedProp.Name} is {selectedProp.GetValue(obj)}");
    }
    catch (TargetInvocationException ex)
    {
        Console.Error.WriteLine(ex.InnerException?.Message);
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
    }

    Console.WriteLine("Press to continue");
    Console.ReadLine();
    Console.Clear();
}









