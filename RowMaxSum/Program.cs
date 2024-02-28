using System;
using System.IO;

namespace RowMaxSum;

class Program
{
    static void Main(string[] args)
    {
        var fileName = GetFileName(args);
        var rows = File.ReadAllLines(fileName);
        var calc = new Calculator(rows);

        Console.WriteLine($"Row with maximum sum: {calc.RowWithMaxSum}");
        Console.WriteLine($"Broken rows: {string.Join(',', calc.BrokenRows)}");            
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
