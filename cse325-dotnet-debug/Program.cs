// CSE 325 - .NET Debugging

Console.WriteLine("CSE 325 Debugging Practice");
Console.WriteLine();

int[] numbers = { 10, 20, 30, 40, 50 };

int total = CalculateTotal(numbers);

Console.WriteLine($"Total: {total}");

double average = CalculateAverage(numbers);

Console.WriteLine($"Average: {average:F2}");

static int CalculateTotal(int[] values)
{
    int total = 0;

    foreach (int value in values)
    {
        total += value;
    }

    return total;
}

static double CalculateAverage(int[] values)
{
    if (values.Length == 0)
    {
        return 0;
    }

    int total = CalculateTotal(values);

    return (double)total / values.Length;
}