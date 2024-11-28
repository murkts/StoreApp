using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.DAL.Interfaces;
using StoreApp.Entities;

namespace StoreApp.DAL.File
{
    public class FileProductRepository : IProductRepository
    {
        private readonly string _filePath;

        public FileProductRepository(string filePath)
        {
            _filePath = filePath;

            if (!System.IO.File.Exists(_filePath))
            {
                System.IO.File.WriteAllText(_filePath, ""); 
            }
        }

        public async Task CreateAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            var existingProduct = await GetByNameAsync(product.Name);
            if (existingProduct != null)
                throw new InvalidOperationException("Продукт с таким именем уже существует.");

            string line = product.Name;
            await System.IO.File.AppendAllTextAsync(_filePath, line + Environment.NewLine);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            if (!System.IO.File.Exists(_filePath)) return Enumerable.Empty<Product>();

            var lines = await System.IO.File.ReadAllLinesAsync(_filePath);

            return lines.Select(line => new Product { Name = line }).ToList();
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя продукта не может быть пустым.", nameof(name));

            var products = await GetAllAsync();
            return products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}