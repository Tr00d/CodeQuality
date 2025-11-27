namespace CodeQuality.Samples.TestDrivenDevelopment.FizzBuzz;

public class FizzBuzzTest
{
    private readonly FizzBuzz fizzBuzz = new();

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void MultipleOfFiveReturnsFizz(int number)
    {
        var result = this.fizzBuzz.Announce(number);
        Assert.Equal("Buzz", result);
    }

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    public void MultipleOfThreeAndFiveReturnsFizzBuzz(int number)
    {
        var result = this.fizzBuzz.Announce(number);
        Assert.Equal("FizzBuzz", result);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(9)]
    public void MultipleOfThreeReturnsFizz(int number)
    {
        var result = this.fizzBuzz.Announce(number);
        Assert.Equal("Fizz", result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void OtherNumberReturnsNumber(int number)
    {
        var result = this.fizzBuzz.Announce(number);
        Assert.Equal(number.ToString(), result);
    }
}