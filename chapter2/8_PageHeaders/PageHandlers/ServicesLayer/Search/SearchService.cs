using System.Collections.Generic;
using System.Linq;

namespace PageHandlers.ServicesLayer.Search
{
    public class SearchService : ISearchService
    {
        private static readonly List<Product> _items = new List<Product>
        {
            new Product{Name="iPad"},
            new Product{Name="iPod"},
            new Product{Name="iMac"},
            new Product{Name="Mac Pro"},
            new Product{Name="Mac mini"},
        };

        public List<Product> SearchProducts(string term)
        {
            return _items.Where(x => x.Name.Contains(term)).ToList();
        }
    }
}
