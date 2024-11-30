namespace StoreApp.BLL.Interfaces;

using StoreApp.Data.Entities;

public interface IProductService
{
    Task CreateProductAsync(string name);
    Task<Product?> GetProductByNameAsync(string name);
    Task<IEnumerable<Product>> GetAllProductsAsync();
}