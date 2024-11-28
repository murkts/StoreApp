using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.DAL.Interfaces;
using StoreApp.Entities;

namespace StoreApp.DAL.File
{
    public class FileStoreRepository : IStoreRepository
    {
        private readonly string _filePath;

        public FileStoreRepository(string filePath)
        {
            _filePath = filePath;

            if (!System.IO.File.Exists(_filePath))
            {
                System.IO.File.WriteAllText(_filePath, ""); 
            }
        }

        public async Task CreateAsync(Store store)
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store));
            var existingStore = await GetByIdAsync(store.Id) ?? await GetByNameAsync(store.Name);
            if (existingStore != null)
                throw new InvalidOperationException("Магазин с таким именем или ID уже существует.");

            string line = $"{store.Id},{store.Name},{store.Address}";
            await System.IO.File.AppendAllTextAsync(_filePath, line + Environment.NewLine);
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            if (!System.IO.File.Exists(_filePath)) return Enumerable.Empty<Store>();

            var lines = await System.IO.File.ReadAllLinesAsync(_filePath);

            return lines.Select(line =>
            {
                var parts = line.Split(',');

                if (parts.Length < 3) return null;

                return new Store
                {
                    Id = Guid.Parse(parts[0]),
                    Name = parts[1],
                    Address = parts[2]
                };
            }).Where(s => s != null).ToList()!;
        }

        public async Task<Store?> GetByIdAsync(Guid id)
        {
            var stores = await GetAllAsync();
            return stores.FirstOrDefault(s => s.Id == id);
        }

        public async Task<Store?> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя магазина не может быть пустым.", nameof(name));

            var stores = await GetAllAsync();
            return stores.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
