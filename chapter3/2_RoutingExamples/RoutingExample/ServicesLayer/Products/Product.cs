namespace RoutingExample.ServicesLayer.Products
{
    public class Product
    {
        public string Category { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Product(string category, string name, decimal price)
        {
            Category = name;
            Name = name;
            Price = price;
        }
    }
}
