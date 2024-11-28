using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Interfaces;
using StoreApp.Entities;

namespace StoreApp.BLL
{
    public class StoreProductService : IStoreProductService
    {
        private readonly IStoreProductRepository _storeProductRepository;

        public StoreProductService(IStoreProductRepository storeProductRepository)
        {
            _storeProductRepository = storeProductRepository;
        }

        public async Task<IEnumerable<StoreProduct>> GetStoreProductsAsync(Guid storeId)
        {
            return await _storeProductRepository.GetProductsByStoreAsync(storeId);
        }

        public async Task AddStockAsync(Guid storeId, string productName, int quantity, decimal price)
        {
            var storeProduct = new StoreProduct
            {
                StoreId = storeId,
                ProductName = productName,
                Quantity = quantity,
                Price = price
            };

            await _storeProductRepository.AddStockAsync(storeProduct);
        }

        public async Task<StoreProduct?> GetStoreProductAsync(Guid storeId, string productName)
        {
            return await _storeProductRepository.GetProductByStoreAsync(storeId, productName);
        }

        public async Task UpdateStockAsync(Guid storeId, string productName, int quantity)
        {
            var storeProduct = await GetStoreProductAsync(storeId, productName);
            if (storeProduct != null)
            {
                storeProduct.Quantity += quantity;
                await _storeProductRepository.UpdateStockAsync(storeId, productName, storeProduct.Quantity);
            }
        }
    }
}