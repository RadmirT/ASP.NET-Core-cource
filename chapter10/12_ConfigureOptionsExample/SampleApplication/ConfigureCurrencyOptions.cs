using CustomConfiguration;
using Microsoft.Extensions.Options;
using SampleApplication.ServicesLayer;

namespace SampleApplication
{
    public class ConfigureCurrencyOptions : IConfigureOptions<CurrencyOptions>
    {
        private readonly ICurrencyProvider currencyProvider;
        public ConfigureCurrencyOptions(ICurrencyProvider currencyProvider)
        {
            this.currencyProvider = currencyProvider;
        }

        public void Configure(CurrencyOptions options)
        {
            options.Currencies = this.currencyProvider.GetCurrencies();
        }
    }
}
