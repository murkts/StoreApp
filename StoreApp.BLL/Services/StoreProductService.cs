namespace StoreApp.BLL.Services;

using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Interfaces;
using StoreApp.Data.Entities;

public class StoreProductService : IStoreProductService
{
    private readonly IStoreProductRepository _storeProductRepository;
    private readonly IProductRepository _productRepository;
    private readonly IStoreRepository _storeRepository;

    public StoreProductService(
        IStoreProductRepository storeProductRepository,
        IProductRepository productRepository,
        IStoreRepository storeRepository)
    {
        _storeProductRepository = storeProductRepository;
        _productRepository = productRepository;
        _storeRepository = storeRepository;
    }

    public Task AddStockAsync(Guid storeId, string productName, int quantity, decimal price)
        => _storeProductRepository.AddStockAsync(storeId, productName, quantity, price);

    public Task<IEnumerable<StoreProduct>> GetProductsByStoreAsync(Guid storeId)
        => _storeProductRepository.GetProductsByStoreAsync(storeId);

    public Task<StoreProduct?> GetProductByStoreAsync(Guid storeId, string productName)
        => _storeProductRepository.GetProductByStoreAsync(storeId, productName);

    public async Task<IEnumerable<Product>> GetAffordableProductsAsync(Guid storeId, decimal budget)
    {
        var storeProducts = await _storeProductRepository.GetProductsByStoreAsync(storeId);
        return storeProducts
            .Where(sp => sp.Price <= budget)
            .Select(sp => new Product { Name = sp.ProductName });
    }

    public async Task<decimal?> PurchaseProductsAsync(Guid storeId, Dictionary<string, int> productsToBuy)
    {
        decimal totalCost = 0;
        foreach (var (productName, quantity) in productsToBuy)
        {
            var storeProduct = await _storeProductRepository.GetProductByStoreAsync(storeId, productName);
            if (storeProduct == null || storeProduct.Quantity < quantity) return null;

            totalCost += storeProduct.Price * quantity;
            await _storeProductRepository.UpdateStockAsync(storeId, productName, storeProduct.Quantity - quantity);
        }
        return totalCost;
    }

    public async Task<(Guid storeId, decimal totalPrice)?> FindCheapestStoreForProductsAsync(Dictionary<string, int> productsToBuy)
    {
        var stores = await _storeRepository.GetAllAsync();
        (Guid storeId, decimal totalPrice)? cheapest = null;

        foreach (var store in stores)
        {
            decimal totalPrice = 0;
            bool canBuyAll = true;

            foreach (var (productName, quantity) in productsToBuy)
            {
                var storeProduct = await _storeProductRepository.GetProductByStoreAsync(store.StoreId, productName);
                if (storeProduct == null || storeProduct.Quantity < quantity)
                {
                    canBuyAll = false;
                    break;
                }
                totalPrice += storeProduct.Price * quantity;
            }

            if (canBuyAll && (cheapest == null || totalPrice < cheapest.Value.totalPrice))
            {
                cheapest = (store.StoreId, totalPrice);
            }
        }
        return cheapest;
    }

    public async Task<Store?> FindCheapestStoreForProductAsync(string productName)
    {
        var stores = await _storeRepository.GetAllAsync();
        Store? cheapestStore = null;
        decimal? cheapestPrice = null;

        foreach (var store in stores)
        {
            var storeProduct = await _storeProductRepository.GetProductByStoreAsync(store.StoreId, productName);
            if (storeProduct != null && (cheapestPrice == null || storeProduct.Price < cheapestPrice))
            {
                cheapestPrice = storeProduct.Price;
                cheapestStore = store;
            }
        }
        return cheapestStore;
    }
}
