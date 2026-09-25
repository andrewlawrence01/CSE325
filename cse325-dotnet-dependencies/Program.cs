using System.Text.Json;

// CSE 325 - .NET Dependencies

Console.WriteLine("CSE 325 Dependency Example");
Console.WriteLine();

var student = new
{
    Name = "Andrew",
    Course = "CSE 325",
    Language = "C#"
};

string json = JsonSerializer.Serialize(
    student,
    new JsonSerializerOptions
    {
        WriteIndented = true
    });

Console.WriteLine("Serialized object:");
Console.WriteLine(json);

Console.WriteLine();
Console.WriteLine("System.Text.Json is being used as a .NET library.");