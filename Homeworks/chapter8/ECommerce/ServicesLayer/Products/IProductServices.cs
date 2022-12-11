using ECommerce.DataLayer;

namespace ECommerce.ServicesLayer.Products;

public interface IProductsService
{
    IEnumerable<ProductViewModel> GetProducts();
    public ProductViewModel GetProduct(int productId);
    public void UpdateProduct(int id, string name, decimal price);
    public ProductViewModel AddProduct(string name, decimal price);
}
