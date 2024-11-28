using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApp.Entities;

namespace StoreApp.DAL.Interfaces
{
    public interface IStoreRepository
    {
        Task CreateAsync(Store store); 
        Task<IEnumerable<Store>> GetAllAsync();
        Task<Store?> GetByIdAsync(Guid id);
        Task<Store?> GetByNameAsync(string name); 
    }
}