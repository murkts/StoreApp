namespace StoreApp.DAL.File;

using StoreApp.DAL.Interfaces;
using StoreApp.Data.Entities;
using System.IO;
using System.Text.Json;

public class FileProductRepository : IProductRepository
{
    private readonly string _filePath = "products.json";

    public async Task CreateAsync(Product product)
    {
        var products = await GetAllAsync();
        var productList = products.ToList();
        productList.Add(product);
        await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(productList));
    }

    public async Task<Product?> GetByNameAsync(string name)
        => (await GetAllAsync()).FirstOrDefault(p => p.Name == name);

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        if (!File.Exists(_filePath)) return Enumerable.Empty<Product>();
        var content = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<IEnumerable<Product>>(content) ?? Enumerable.Empty<Product>();
    }
}