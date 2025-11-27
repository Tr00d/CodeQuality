using System.ComponentModel;

namespace CodeQuality.Samples.TestDrivenDevelopment.MoneyKata;

/// <summary>
///     Simulate a stock portfolio.
///     You can add amounts in your portfolio (ex: 10 EUR, 15 USD).
///     The portfolio will hold several "amounts" in different currencies.
///     We want to evaluate the portfolio in a specific currency:
///     what is the EUR value of my portfolio?
///     Here's an exchange rate table:
///     FROM    | TO    | RATE
///     EUR     USD     1.2
///     USD     EUR     0.82
///     USD     KRW     1100
///     KRW     EUR     0.0009
///     EUR     KRW     1344
/// </summary>
public class Portfolio
{
    private readonly List<ExchangeRate> rates = [];
    private readonly List<PortfolioMoney> moneys = [];
    public void Add(PortfolioMoney portfolioMoney) => this.moneys.Add(portfolioMoney);

    public void AddExchangeRate(ExchangeRate rate) => this.rates.Add(rate);

    public PortfolioMoney Evaluate(Currency currency) =>
        new(this.AggregateAmounts(currency), currency);

    private float AggregateAmounts(Currency currency)
    {
        return this.moneys
            .Select(money => money.ConvertTo(currency, this.FindRate(money.Currency, currency)))
            .Select(money => money.Amount)
            .Sum();
    }

    private ExchangeRate FindRate(Currency sourceCurrency, Currency targetCurrency) => this.rates.FirstOrDefault(rate => rate.CurrencyFrom == sourceCurrency && rate.CurrencyTo == targetCurrency);
}

public record PortfolioMoney(float Amount, Currency Currency)
{
    public PortfolioMoney ConvertTo(Currency targetCurrency, ExchangeRate rate) => this.Currency != targetCurrency ? new PortfolioMoney(this.Amount * rate.Rate, targetCurrency) : this;
}

public record ExchangeRate(Currency CurrencyFrom, Currency CurrencyTo, float Rate);

public enum Currency
{
    // ReSharper disable once InconsistentNaming
    [Description("Euros")]
    EUR,
    
    // ReSharper disable once InconsistentNaming
    [Description("US Dollars")]
    USD
}