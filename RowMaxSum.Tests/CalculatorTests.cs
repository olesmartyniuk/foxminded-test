using System;
using Xunit;

namespace RowMaxSum.Tests;

public class CalculatorTests
{
    [Fact]
    public void ShouldSucceedForValidRows()
    {
        var rows = new[] { "1,2", "2,3.5" };            
        var maxSumRow = Calculator.GetRowWithMaxSum(rows, out var brokenRows);

        Assert.Equal(1, maxSumRow);
        Assert.Empty(brokenRows);            
    }

    [Fact]
    public void ShouldSucceedForInvalidRows()
    {
        var rows = new[] { "2,3.L", "invalid,row"};            
        var maxSumRow = Calculator.GetRowWithMaxSum(rows, out var brokenRows);

        Assert.Null(maxSumRow);
        Assert.Equal(2, brokenRows.Count);
        Assert.Equal(0, brokenRows[0]);
        Assert.Equal(1, brokenRows[1]);
    }

    [Fact]
    public void ShouldSucceedForValidAndInvalidRows()
    {          
        var rows = new[] { "1,2,3,7", "2,3.5", "invalid,row", "3,7" };            
        var maxSumRow = Calculator.GetRowWithMaxSum(rows, out var brokenRows);

        Assert.Equal(0, maxSumRow);
        Assert.Single(brokenRows);
        Assert.Equal(2, brokenRows[0]);
    }

    [Fact]
    public void ShouldSucceedForEmptyList()
    {
        var rows = Array.Empty<string>();
        var maxSumRow = Calculator.GetRowWithMaxSum(rows, out var brokenRows);

        Assert.Null(maxSumRow);
        Assert.Empty(brokenRows);            
    }

    [Fact]
    public void ShouldSucceedForNumberThatExceedsMaxValue()
    {
        var rows = new[] 
        { 
            "1,2,3", 
            "2,3,4,7922816251426433759354395033579228162514264337593543950335792281625142643375935439503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503", 
            "3,4,5"
        };
        var maxSumRow = Calculator.GetRowWithMaxSum(rows, out var brokenRows);

        Assert.Equal(2, maxSumRow);
        Assert.Single(brokenRows);
        Assert.Equal(1, brokenRows[0]);            
    }

    [Fact]
    public void ShouldSucceedForNumberThatExceedsMinValue()
    {
        var rows = new[]
        {
            "1,2,3",
            "2,3,4,-7922816251426433759354395033579228162514264337593543950335792281625142643375935439503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503",
            "3,4,5"
        };
        var maxSumRow = Calculator.GetRowWithMaxSum(rows, out var brokenRows);

        Assert.Equal(2, maxSumRow);
        Assert.Single(brokenRows);
        Assert.Equal(1, brokenRows[0]);
    }

    [Fact]
    public void ShouldSucceedForNegativeValues()
    {
        var rows = new[] { "-1,-2", "-2,-3.5", "+1,-6" };
        var maxSumRow = Calculator.GetRowWithMaxSum(rows, out var brokenRows);

        Assert.Equal(0, maxSumRow);
        Assert.Empty(brokenRows);
    }

    [Fact]
    public void ShouldSucceedForValuesWith16DecimalPlaces()
    {
        var rows = new[] { "1.1234567890123457", "12345678901234567.1234567890123458"};
        var maxSumRow = Calculator.GetRowWithMaxSum(rows, out var brokenRows);

        Assert.Equal(1, maxSumRow);
        Assert.Empty(brokenRows);
    }
}