using System.Collections.Generic;

namespace PageHandlers.ServicesLayer.Search;

public interface ISearchService
{
    List<Product> SearchProducts(string term);
}