using System;
using ECommerce.DataLayer;

namespace ECommerce.ServicesLayer.Products
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext dbContext;

        public ProductsService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<ProductViewModel> GetProducts()
        {
            return this.dbContext.Products.Select(o => new ProductViewModel(o.Id, o.Name, o.Price)).ToList();
        }
        public ProductViewModel GetProduct(int productId)
        {
            return this.dbContext.Products
                .Where(o => o.Id == productId)
                .Select(o => new ProductViewModel(o.Id, o.Name, o.Price))
                .SingleOrDefault();
        }

        public void UpdateProduct(int id, string name, decimal price)
        {
            var product= this.dbContext.Products.Find(id);
            if (product == null)
            {
                throw new InvalidOperationException("Can't find the product");
            }

            product.Name = name;
            product.Price = price;
            this.dbContext.SaveChanges();
        }

        public ProductViewModel AddProduct(string name, decimal price)
        {
            var product = new Product{Name = name, Price = price};
            this.dbContext.Add(product);
            this.dbContext.SaveChanges();
            return new ProductViewModel(product.Id, product.Name, product.Price);
        }

        /// <inheritdoc />
        public bool DoesRecipeExist(int productId)
        {
            return this.dbContext.Products.Any(o => o.Id == productId);
        }
    }
}
