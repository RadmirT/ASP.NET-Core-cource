using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingExample.ServicesLayer.Products
{
    public class ProductService
    {
        private static readonly IDictionary<string, Product> _allProducts
            = new Dictionary<string, Product>
            {
                {"big-widget", new Product("Widget", "Big Widget", 123) },
                {"super-fancy-widget", new Product("Widget", "Super fancy widget", 456) },
                {"big-gadget", new Product("Gadget", "Big Gadget", 789) },
            };
        public Product GetProduct(string name)
        {
            if (_allProducts.TryGetValue(name, out var product))
            {
                return product;
            }

            return null;
        }

        public List<Product> Search(string term, StringComparison comparisonType)
        {
            return _allProducts
                .Where(x => x.Value.Name.Contains(term, comparisonType))
                .Select(x => x.Value)
                .ToList();
        }
    }
}
