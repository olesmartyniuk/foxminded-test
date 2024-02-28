using System;
using System.IO;

namespace RowMaxSum;

class Program
{
    static void Main(string[] args)
    {
        var fileName = GetFileName(args);
        var rows = File.ReadAllLines(fileName);
        var maxRow = Calculator.GetRowWithMaxSum(rows, out var brokenRows);

        Console.WriteLine($"Row with maximum sum: {maxRow}");
        Console.WriteLine($"Broken rows: {string.Join(',', brokenRows)}");            
    }

    private static string GetFileName(string[] args)
    {
        if (args.Length > 0)
        {
            return args[0];
        }

        Console.Write("Enter the filename: ");
        return Console.ReadLine();            
    }
}
