namespace CodeQuality.Samples.TestDrivenDevelopment.FizzBuzz;

public class FizzBuzz
{
    private const string Buzz = "Buzz";
    private const string Fizz = "Fizz";

    /// <summary>
    ///     Should return "Fizz" when number can be divided by 3.
    ///     Should return "Buzz" when number can be divided by 5.
    ///     Should return "FizzBuzz" when number can be divided by 3 and 5.
    ///     Should return number.ToString if can't be divided by either 3 or 5.
    /// </summary>
    public string Announce(int number)
    {
        if (ModuloThree(number) && ModuloFive(number))
            return Fizz + Buzz;
        if (ModuloThree(number))
            return Fizz;
        if (ModuloFive(number))
            return Buzz;
        return number.ToString();
    }

    private static bool ModuloFive(int number) => number % 5 == 0;

    private static bool ModuloThree(int number) => number % 3 == 0;
}