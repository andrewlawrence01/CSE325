// CSE 325 - Write Your First C# Code

Console.WriteLine("Hello, World!");
Console.WriteLine();

// Variables and data types
string firstName = "Andrew";
int age = 25;
decimal accountBalance = 1250.75m;
bool isStudent = true;

// Display variable values
Console.WriteLine($"Name: {firstName}");
Console.WriteLine($"Age: {age}");
Console.WriteLine($"Account Balance: {accountBalance:C}");
Console.WriteLine($"Student: {isStudent}");
Console.WriteLine();

// Arithmetic
int firstNumber = 10;
int secondNumber = 5;

Console.WriteLine($"Addition: {firstNumber + secondNumber}");
Console.WriteLine($"Subtraction: {firstNumber - secondNumber}");
Console.WriteLine($"Multiplication: {firstNumber * secondNumber}");
Console.WriteLine($"Division: {firstNumber / secondNumber}");
Console.WriteLine();

// Conditional statement
if (age >= 18)
{
    Console.WriteLine($"{firstName} is an adult.");
}
else
{
    Console.WriteLine($"{firstName} is a minor.");
}

// Loop
Console.WriteLine();
Console.WriteLine("Counting:");

for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}