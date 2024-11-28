using System.Threading.Tasks;
using StoreApp.Entities;

namespace StoreApp.BLL.Interfaces
{
    public interface IStoreService
    {
        Task<Store?> GetStoreByNameAsync(string name); 
        Task CreateStoreAsync(Store store); 
        Task<IEnumerable<Store>> GetAllStoresAsync();
    }
}