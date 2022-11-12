namespace ListBindings.ServicesLayer
{
    public class CurrencyService
    {
        public readonly Dictionary<string, decimal> AllCurrencies =
            new Dictionary<string, decimal>
            {
                {"GBP", 1.00m},
                {"USD", 1.22m},
                {"CAD", 1.64m},
                {"EUR", 1.15m},
            };
    }
}
