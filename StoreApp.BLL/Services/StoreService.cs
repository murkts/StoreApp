namespace StoreApp.BLL.Services;

using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Interfaces;
using StoreApp.Data.Entities;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;

    public StoreService(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task CreateStoreAsync(string name, string address)
    {
        var store = new Store { StoreId = Guid.NewGuid(), Name = name, Address = address };
        await _storeRepository.CreateAsync(store);
    }

    public Task<Store?> GetStoreByIdAsync(Guid id)
        => _storeRepository.GetByIdAsync(id);

    public Task<Store?> GetStoreByNameAsync(string name)
        => _storeRepository.GetByNameAsync(name);

    public Task<IEnumerable<Store>> GetAllStoresAsync()
        => _storeRepository.GetAllAsync();
}