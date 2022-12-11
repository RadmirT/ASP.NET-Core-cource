namespace SampleApplication.ServicesLayer
{
    public class CurrencyProvider : ICurrencyProvider
    {
        public string[] GetCurrencies()
        {
            // Здесь может быть загрузка данных из БД или удаленного сервиса
            return new string[] { "GBP", "USD", "EUR", "CAD" };
        }
    }
}
