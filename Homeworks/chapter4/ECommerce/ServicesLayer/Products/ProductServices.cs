using System;

namespace ECommerce.ServicesLayer.Products
{
    public class ProductServices : IProductServices
    {
        private List<Product> _products = new List<Product>
        {
            new Product(1, "Apple iPod", 249.95m),
            new Product(2, "Surface Book", 1099.00m),
            new Product(3, "Huawei matebook", 2102.89m),
        };

        public IEnumerable<Product> GetProducts()
        {
            return this._products.AsReadOnly();
        }
        public Product GetProducts(int productId)
        {
            return this._products.SingleOrDefault(o => o.id == productId);
        }
    }
}
