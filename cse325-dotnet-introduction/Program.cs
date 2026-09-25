// CSE 325 - Introduction to .NET

Console.WriteLine("Welcome to .NET!");
Console.WriteLine();

Console.Write("What is your name? ");
string? name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
{
    name = "Student";
}

Console.Write("What is your favorite number? ");
string? numberInput = Console.ReadLine();

if (int.TryParse(numberInput, out int favoriteNumber))
{
    Console.WriteLine();
    Console.WriteLine($"Hello, {name}!");
    Console.WriteLine($"Your favorite number is {favoriteNumber}.");
    Console.WriteLine(
        $"Your favorite number multiplied by 2 is {favoriteNumber * 2}.");
}
else
{
    Console.WriteLine();
    Console.WriteLine($"Hello, {name}!");
    Console.WriteLine("That was not a valid number.");
}

Console.WriteLine();
Console.WriteLine("This application is running with .NET.");