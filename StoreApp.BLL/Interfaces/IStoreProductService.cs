namespace StoreApp.BLL.Interfaces;

using StoreApp.Data.Entities;

public interface IStoreProductService
{
    Task AddStockAsync(Guid storeId, string productName, int quantity, decimal price);
    Task<IEnumerable<StoreProduct>> GetProductsByStoreAsync(Guid storeId);
    Task<StoreProduct?> GetProductByStoreAsync(Guid storeId, string productName);
    Task<IEnumerable<Product>> GetAffordableProductsAsync(Guid storeId, decimal budget);
    Task<decimal?> PurchaseProductsAsync(Guid storeId, Dictionary<string, int> productsToBuy);
    Task<(Guid storeId, decimal totalPrice)?> FindCheapestStoreForProductsAsync(Dictionary<string, int> productsToBuy);
    Task<Store?> FindCheapestStoreForProductAsync(string productName);
}