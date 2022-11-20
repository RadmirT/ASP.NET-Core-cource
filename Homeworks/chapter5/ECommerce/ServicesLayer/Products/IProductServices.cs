namespace ECommerce.ServicesLayer.Products;

public interface IProductsService
{
    IEnumerable<Product> GetProducts();
    public Product GetProduct(int productId);
    public void UpdateProduct(int id, string name, decimal price);
    public Product AddProduct(string name, decimal price);
}
