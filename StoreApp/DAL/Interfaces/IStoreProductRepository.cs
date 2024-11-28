using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApp.Entities;

namespace StoreApp.DAL.Interfaces
{
    public interface IStoreProductRepository
    {
        Task AddStockAsync(Guid storeId, string productName, int quantity, decimal price);
        Task<IEnumerable<StoreProduct>> GetProductsByStoreAsync(Guid storeId);
        Task<StoreProduct?> GetProductByStoreAsync(Guid storeId, string productName);
        Task UpdateStockAsync(Guid storeId, string productName, int quantity);
    }
}