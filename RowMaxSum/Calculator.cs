
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RowMaxSum;

public static class Calculator
{
    public static int? GetRowWithMaxSum(string[] rows, out List<int> brokenRows)
    {
        var rowsWithSum = rows
            .Select((row, index) => 
            {
                var sum = CalculateSum(row, out bool isValid);                                        
                return new { Index = index, Sum = sum, IsValid = isValid };
            })
            .ToList();

        brokenRows = rowsWithSum
            .Where(row => !row.IsValid)
            .Select(row => row.Index)
            .ToList();

        var validRows = rowsWithSum
            .Where(row => row.IsValid);

        if (!validRows.Any())
        {
            return null;
        }

        return validRows
            .Aggregate((r1, r2) => r2.Sum > r1.Sum ? r2 : r1)
            .Index;                
    }       

    private static double? CalculateSum(string row, out bool isValid)
    {        
        var parsedNumbers = row
            .Split(',')
            .Select(Parse);

        if (parsedNumbers.Any(num => num == null || double.IsInfinity(num.Value)))
        {
            isValid = false;
            return null;
        }

        isValid = true;
        return parsedNumbers.Sum();
    }

    private static double? Parse(string number)
    {
        if (double.TryParse(
            number,
            NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
            CultureInfo.InvariantCulture,
            out double parsedNumber))
        {
            return parsedNumber;
        }

        return null;
    }
}