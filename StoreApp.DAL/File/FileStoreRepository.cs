namespace StoreApp.DAL.File;

using StoreApp.DAL.Interfaces;
using StoreApp.Data.Entities;
using System.IO;
using System.Text.Json;

public class FileStoreRepository : IStoreRepository
{
    private readonly string _filePath = "stores.json";

    public async Task CreateAsync(Store store)
    {
        var stores = await GetAllAsync();
        var storeList = stores.ToList();
        storeList.Add(store);
        await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(storeList));
    }

    public async Task<Store?> GetByIdAsync(Guid storeId)
        => (await GetAllAsync()).FirstOrDefault(s => s.StoreId == storeId);

    public async Task<Store?> GetByNameAsync(string storeName)
        => (await GetAllAsync()).FirstOrDefault(s => s.Name == storeName);

    public async Task<IEnumerable<Store>> GetAllAsync()
    {
        if (!File.Exists(_filePath)) return Enumerable.Empty<Store>();
        var content = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<IEnumerable<Store>>(content) ?? Enumerable.Empty<Store>();
    }
}