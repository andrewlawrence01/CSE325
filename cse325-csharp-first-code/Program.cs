
using System;

// Display a welcome message
Console.WriteLine(new string('-', 35));
Console.WriteLine("Welcome to the C# Greeting Program!");
Console.WriteLine(new string('-', 35));
Console.WriteLine();

// Ask for the user's name
Console.Write("What is your name? ");
string name = Console.ReadLine() ?? "";

// Ask for the user's age
Console.Write("How old are you? ");
string age = Console.ReadLine() ?? "";

// Display a personalized greeting
Console.WriteLine();
Console.WriteLine($"Hello, {name}! It's great to meet you.");
Console.WriteLine($"You are {age} years old.");

// Demonstrate string methods
Console.WriteLine();
Console.WriteLine("--- String Manipulation ---");
Console.WriteLine($"Uppercase: {name.ToUpper()}");
Console.WriteLine($"Lowercase: {name.ToLower()}");
Console.WriteLine($"Name length: {name.Length}");
Console.WriteLine($"Name with 'a' replaced by '@': {name.Replace("a", "@")}");

// Demonstrate escape characters
Console.WriteLine();
Console.WriteLine("--- Formatted Information ---");
Console.WriteLine($"Name:\t{name}");
Console.WriteLine($"Age:\t{age}");
Console.WriteLine("Thank you for trying this program!\n");

// Display a closing message
Console.WriteLine(new string('-', 35));
Console.WriteLine("End of Program");
Console.WriteLine(new string('-', 35));