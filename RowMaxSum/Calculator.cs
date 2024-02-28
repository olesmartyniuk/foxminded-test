
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RowMaxSum;

public class Calculator
{
    public int? RowWithMaxSum { get; private set; }

    public List<int> BrokenRows { get; private set; }

    public Calculator(string[] rows)
    {
        var rowsWithSum = rows
            .Select((row, index) =>
            {
                var sum = CalculateSum(row, out bool isValid);
                return new { Index = index, Sum = sum, IsValid = isValid };
            })
            .ToList();

        BrokenRows = rowsWithSum
            .Where(row => !row.IsValid)
            .Select(row => row.Index + 1)
            .ToList();

        var validRows = rowsWithSum
            .Where(row => row.IsValid);

        if (validRows.Any())
        {
            RowWithMaxSum = validRows
                .Aggregate((r1, r2) => r2.Sum > r1.Sum ? r2 : r1)
                .Index + 1;
        }
        else
        {
            RowWithMaxSum = null;            
        }
    }

    private double? CalculateSum(string row, out bool isValid)
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

    private double? Parse(string number)
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