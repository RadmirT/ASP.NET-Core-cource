namespace ECommerce.ServicesLayer.Products
{
    public class  Product
    {
        public Product(int id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public Product()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
