namespace ECommerce.ServicesLayer.Products;

public interface IProductServices
{
    IEnumerable<Product> GetProducts();
    public Product GetProducts(int productId);
}