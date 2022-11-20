using System;

namespace ECommerce.ServicesLayer.Products
{
    public class ProductsService : IProductsService
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
        public Product GetProduct(int productId)
        {
            return this._products.SingleOrDefault(o => o.Id == productId);
        }

        public void UpdateProduct(int id, string name, decimal price)
        {
            var product= this._products.SingleOrDefault(o => o.Id == id);
            if (product == null)
            {
                throw new InvalidOperationException("Can't find the product");
            }

            product.Name = name;
            product.Price = price;
        }

        public Product AddProduct(string name, decimal price)
        {
            var product = new Product(this._products.Count + 1, name, price);
            return product;
        }
    }
}
