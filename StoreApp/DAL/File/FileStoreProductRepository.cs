using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.DAL.Interfaces;
using StoreApp.Entities;

namespace StoreApp.DAL.File
{
    public class FileStoreProductRepository : IStoreProductRepository
    {
        private readonly string _filePath;

        public FileStoreProductRepository(string filePath)
        {
            _filePath = filePath;

            if (!System.IO.File.Exists(_filePath))
            {
                System.IO.File.WriteAllText(_filePath, ""); // Создаем пустой файл
            }
        }

        public async Task AddStockAsync(Guid storeId, string productName, int quantity, decimal price)
        {
            var line = $"{storeId},{productName},{quantity},{price}";
            await System.IO.File.AppendAllTextAsync(_filePath, line + Environment.NewLine);
        }

        public async Task<StoreProduct?> GetProductByStoreAsync(Guid storeId, string productName)
        {
            var products = await GetStoreProductsAsync();
            return products.FirstOrDefault(p =>
                p.StoreId == storeId && p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<StoreProduct>> GetProductsByStoreAsync(Guid storeId)
        {
            var products = await GetStoreProductsAsync();
            return products.Where(p => p.StoreId == storeId);
        }

        public async Task UpdateStockAsync(Guid storeId, string productName, int quantity)
        {
            var products = (await GetStoreProductsAsync()).ToList();

            var product = products.FirstOrDefault(p =>
                p.StoreId == storeId && p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (product == null)
                throw new InvalidOperationException("Продукт не найден в указанном магазине.");

            product.Quantity = quantity;

            // Перезаписываем весь файл с обновленными данными
            await RewriteFileAsync(products);
        }

        private async Task<List<StoreProduct>> GetStoreProductsAsync()
        {
            if (!System.IO.File.Exists(_filePath)) return new List<StoreProduct>();

            var lines = await System.IO.File.ReadAllLinesAsync(_filePath);

            return lines.Select(line =>
            {
                var parts = line.Split(',');

                if (parts.Length < 4) return null;

                return new StoreProduct
                {
                    StoreId = Guid.Parse(parts[0]),
                    ProductName = parts[1],
                    Quantity = int.Parse(parts[2]),
                    Price = decimal.Parse(parts[3])
                };
            }).Where(sp => sp != null).ToList()!;
        }

        private async Task RewriteFileAsync(IEnumerable<StoreProduct> products)
        {
            var lines = products.Select(p =>
                $"{p.StoreId},{p.ProductName},{p.Quantity},{p.Price}");

            await System.IO.File.WriteAllLinesAsync(_filePath, lines);
        }
    }
}
