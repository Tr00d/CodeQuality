using FluentAssertions;

namespace CodeQuality.Samples.TestDrivenDevelopment.MoneyKata;

public class PortfolioTest
{
    private readonly Portfolio portfolio = new();

    [Fact]
    public void EmptyPortfolio_ShouldReturnZero()
    {
        var targetCurrency = Currency.EUR;
        var amount = this.portfolio.Evaluate(targetCurrency);
        amount.Should().Be(new PortfolioMoney(0, targetCurrency));
    }

    [Theory]
    [InlineData(Currency.EUR)]
    [InlineData(Currency.USD)]
    public void Evaluate_ShouldReturnAmountInTargetCurrency_GivenPortfolioContainsSingleMoney(Currency currency)
    {
        this.portfolio.Add(new PortfolioMoney(10, currency));
        this.portfolio.Evaluate(currency).Should().Be(new PortfolioMoney(10, currency));
    }
    
    [Fact]
    public void Evaluate_ShouldReturnMoneyInTargetCurrency_GivenPortfolioHasMoneysInMultipleCurrencies()
    {
        var targetCurrency = Currency.EUR;
        this.portfolio.AddExchangeRate(new ExchangeRate(Currency.USD, targetCurrency, 0.82f));
        this.portfolio.Add(new PortfolioMoney(10, Currency.EUR));
        this.portfolio.Add(new PortfolioMoney(10, Currency.USD));
        var amount = this.portfolio.Evaluate(targetCurrency);
        amount.Should().Be(new PortfolioMoney(18.2f, targetCurrency));
    }
}