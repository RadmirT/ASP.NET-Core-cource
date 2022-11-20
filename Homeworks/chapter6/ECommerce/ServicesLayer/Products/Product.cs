namespace ECommerce.ServicesLayer.Products
{
    public record Product(int Id, string Name, decimal Price)
    {
        public int Id { get; init; } = Id;
        public string Name { get; internal set; } = Name;
        public decimal Price { get; internal set; } = Price;
    }
}
