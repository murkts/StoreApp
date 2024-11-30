namespace StoreApp.DAL.Interfaces;

using StoreApp.Data.Entities;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    Task<Product?> GetByNameAsync(string name);
    Task<IEnumerable<Product>> GetAllAsync();
}