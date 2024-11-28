using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Interfaces;
using StoreApp.Entities;

namespace StoreApp.BLL
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public async Task<Store?> GetStoreByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя магазина не может быть пустым", nameof(name));
            }

            return await _storeRepository.GetByNameAsync(name); 
        }
        public async Task CreateStoreAsync(Store store)
        {
            if (store == null)
            {
                throw new ArgumentNullException(nameof(store));
            }

            await _storeRepository.CreateAsync(store); 
        }
        public async Task<IEnumerable<Store>> GetAllStoresAsync()
        {
            return await _storeRepository.GetAllAsync(); 
        }
    }
}