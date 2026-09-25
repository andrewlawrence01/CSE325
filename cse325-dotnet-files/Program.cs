using System.Globalization;
using System.Text;

// CSE 325 - Work with Files and Directories
// Includes the required Sales Summary Report addition.

string salesDirectory = Path.Combine(
    Directory.GetCurrentDirectory(),
    "sales-data");

string reportsDirectory = Path.Combine(
    Directory.GetCurrentDirectory(),
    "reports");

string summaryFile = Path.Combine(
    reportsDirectory,
    "sales-summary.txt");

// Make sure required directories exist.
Directory.CreateDirectory(salesDirectory);
Directory.CreateDirectory(reportsDirectory);

// Create sample sales files if they don't already exist.
// These make the project immediately runnable.
CreateSampleSalesFiles(salesDirectory);

// Display the sales files.
Console.WriteLine("Sales Files");
Console.WriteLine("----------------------------");

string[] salesFiles = Directory.GetFiles(
    salesDirectory,
    "*.txt");

foreach (string file in salesFiles)
{
    Console.WriteLine(Path.GetFileName(file));
}

Console.WriteLine();

// Read and calculate the sales from each file.
Dictionary<string, decimal> salesByFile =
    new Dictionary<string, decimal>();

foreach (string file in salesFiles)
{
    decimal total = CalculateFileSales(file);

    salesByFile[Path.GetFileName(file)] = total;

    Console.WriteLine(
        $"{Path.GetFileName(file)}: {total:C}");
}

Console.WriteLine();

// Generate the required sales summary report.
GenerateSalesSummary(summaryFile, salesByFile);

Console.WriteLine("Sales summary report created.");
Console.WriteLine($"Report: {summaryFile}");

Console.WriteLine();
Console.WriteLine("Report Contents");
Console.WriteLine("----------------------------");

Console.WriteLine(File.ReadAllText(summaryFile));


// ------------------------------------------------------------
// Creates sample sales files so the project works immediately.
// ------------------------------------------------------------
static void CreateSampleSalesFiles(string directory)
{
    string file1 = Path.Combine(directory, "sales-01.txt");
    string file2 = Path.Combine(directory, "sales-02.txt");
    string file3 = Path.Combine(directory, "sales-03.txt");

    if (!File.Exists(file1))
    {
        File.WriteAllLines(file1, new[]
        {
            "100.00",
            "250.00",
            "75.00",
            "125.00"
        });
    }

    if (!File.Exists(file2))
    {
        File.WriteAllLines(file2, new[]
        {
            "150.00",
            "300.00",
            "125.00"
        });
    }

    if (!File.Exists(file3))
    {
        File.WriteAllLines(file3, new[]
        {
            "200.00",
            "175.00",
            "225.00"
        });
    }
}


// ------------------------------------------------------------
// Reads a sales file and calculates its total.
// ------------------------------------------------------------
static decimal CalculateFileSales(string filePath)
{
    decimal total = 0;

    string[] lines = File.ReadAllLines(filePath);

    foreach (string line in lines)
    {
        if (decimal.TryParse(
            line,
            NumberStyles.Currency,
            CultureInfo.InvariantCulture,
            out decimal sale))
        {
            total += sale;
        }
    }

    return total;
}


// ------------------------------------------------------------
// REQUIRED ASSIGNMENT ADDITION
//
// Creates a sales summary report containing:
// - Overall sales total
// - Total for each sales file
// ------------------------------------------------------------
static void GenerateSalesSummary(
    string outputFile,
    Dictionary<string, decimal> salesByFile)
{
    decimal totalSales = salesByFile.Values.Sum();

    StringBuilder report = new StringBuilder();

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine($"Total Sales: {totalSales:C}");
    report.AppendLine();
    report.AppendLine("Details:");

    foreach (var sale in salesByFile.OrderBy(item => item.Key))
    {
        report.AppendLine(
            $"{sale.Key}: {sale.Value:C}");
    }

    File.WriteAllText(
        outputFile,
        report.ToString());
}