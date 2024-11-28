using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApp.Entities;

namespace StoreApp.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product); 
        Task<IEnumerable<Product>> GetAllAsync(); 
        Task<Product?> GetByNameAsync(string name); 
    }
}