using System;
using Xunit;

namespace RowMaxSum.Tests;

public class CalculatorTests
{
    [Fact]
    public void ShouldSucceedForValidRows()
    {        
        var calc = new Calculator(new[] { "1,2", "2,3.5" });        

        Assert.Equal(2, calc.RowWithMaxSum);
        Assert.Empty(calc.BrokenRows);            
    }

    [Fact]
    public void ShouldSucceedForInvalidRows()
    {        
        var calc = new Calculator(new[] { "2,3.L", "invalid,row" });            

        Assert.Null(calc.RowWithMaxSum);
        Assert.Equal(2, calc.BrokenRows.Count);
        Assert.Equal(1, calc.BrokenRows[0]);
        Assert.Equal(2, calc.BrokenRows[1]);
    }

    [Fact]
    public void ShouldSucceedForValidAndInvalidRows()
    {                  
        var calc = new Calculator(new[] { "1,2,3,7", "2,3.5", "invalid,row", "3,7" });

        Assert.Equal(1, calc.RowWithMaxSum);
        Assert.Single(calc.BrokenRows);
        Assert.Equal(3, calc.BrokenRows[0]);
    }

    [Fact]
    public void ShouldSucceedForEmptyList()
    {
        var calc = new Calculator(Array.Empty<string>());

        Assert.Null(calc.RowWithMaxSum);
        Assert.Empty(calc.BrokenRows);            
    }

    [Fact]
    public void ShouldSucceedForNumberThatExceedsMaxValue()
    {        
        var calc = new Calculator(
            new[]
            {
                "1,2,3",
                "2,3,4,7922816251426433759354395033579228162514264337593543950335792281625142643375935439503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503",
                "3,4,5"
            }
        );

        Assert.Equal(3, calc.RowWithMaxSum);
        Assert.Single(calc.BrokenRows);
        Assert.Equal(2, calc.BrokenRows[0]);            
    }

    [Fact]
    public void ShouldSucceedForNumberThatExceedsMinValue()
    {        
        var calc = new Calculator(new[]
        {
            "1,2,3",
            "2,3,4,-7922816251426433759354395033579228162514264337593543950335792281625142643375935439503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503503357922816251426433759354395033579228162514264337593543950335792281625142643375935439503",
            "3,4,5"
        });

        Assert.Equal(3, calc.RowWithMaxSum);
        Assert.Single(calc.BrokenRows);
        Assert.Equal(2, calc.BrokenRows[0]);
    }

    [Fact]
    public void ShouldSucceedForNegativeValues()
    {
        var calc = new Calculator(new[] { "-1,-2", "-2,-3.5", "+1,-6" });

        Assert.Equal(1, calc.RowWithMaxSum);
        Assert.Empty(calc.BrokenRows);
    }

    [Fact]
    public void ShouldSucceedForValuesWith16DecimalPlaces()
    {
        var calc = new Calculator(new[] { "1.1234567890123457", "12345678901234567.1234567890123458" });

        Assert.Equal(2, calc.RowWithMaxSum);
        Assert.Empty(calc.BrokenRows);
    }

    [Fact]
    public void ShouldSucceedFor2RowsWithSameSum()
    {
        var calc = new Calculator(new[]
        {
            "1,2,3",
            "2,3,4",
            "3,4,2"
        });

        Assert.Equal(2, calc.RowWithMaxSum);
        Assert.Empty(calc.BrokenRows);
    }
}