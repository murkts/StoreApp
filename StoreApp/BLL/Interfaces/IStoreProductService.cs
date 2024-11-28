using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApp.Entities;

namespace StoreApp.BLL.Interfaces
{
    public interface IStoreProductService
    {
        Task<IEnumerable<StoreProduct>> GetStoreProductsAsync(Guid storeId); 
        Task AddStockAsync(Guid storeId, string productName, int quantity, decimal price); 
        Task<StoreProduct?> GetStoreProductAsync(Guid storeId, string productName); 
        Task UpdateStockAsync(Guid storeId, string productName, int quantity); 
    }
}