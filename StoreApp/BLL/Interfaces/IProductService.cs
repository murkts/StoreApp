using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApp.Entities;

namespace StoreApp.BLL.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByNameAsync(string name); 
        Task CreateProductAsync(string name); 
    }
}