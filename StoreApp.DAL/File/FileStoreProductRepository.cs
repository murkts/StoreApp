namespace StoreApp.DAL.File;

using StoreApp.DAL.Interfaces;
using StoreApp.Data.Entities;
using System.IO;
using System.Text.Json;

public class FileStoreProductRepository : IStoreProductRepository
{
    private readonly string _filePath = "storeProducts.json";

    public async Task AddStockAsync(Guid storeId, string productName, int quantity, decimal price)
    {
        var storeProducts = await GetProductsByStoreAsync(storeId);
        var productList = storeProducts.ToList();

        var existingProduct = productList.FirstOrDefault(p => p.ProductName == productName);
        if (existingProduct != null)
        {
            existingProduct.Quantity += quantity;
            existingProduct.Price = price;
        }
        else
        {
            productList.Add(new StoreProduct
            {
                StoreId = storeId,
                ProductName = productName,
                Quantity = quantity,
                Price = price
            });
        }

        await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(productList));
    }

    public async Task<StoreProduct?> GetProductByStoreAsync(Guid storeId, string productName)
        => (await GetProductsByStoreAsync(storeId)).FirstOrDefault(p => p.ProductName == productName);

    public async Task<IEnumerable<StoreProduct>> GetProductsByStoreAsync(Guid storeId)
    {
        if (!File.Exists(_filePath)) return Enumerable.Empty<StoreProduct>();
        var content = await File.ReadAllTextAsync(_filePath);
        var storeProducts = JsonSerializer.Deserialize<IEnumerable<StoreProduct>>(content);
        return storeProducts?.Where(sp => sp.StoreId == storeId) ?? Enumerable.Empty<StoreProduct>();
    }

    public async Task UpdateStockAsync(Guid storeId, string productName, int quantity)
    {
        var storeProducts = await GetProductsByStoreAsync(storeId);
        var productList = storeProducts.ToList();

        var existingProduct = productList.FirstOrDefault(p => p.ProductName == productName);
        if (existingProduct != null)
        {
            existingProduct.Quantity = quantity;
            await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(productList));
        }
    }
}
