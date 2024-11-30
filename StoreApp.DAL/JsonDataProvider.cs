using System.Text.Json;
using StoreApp.Data.Entities;

namespace StoreApp.DAL
{
    public class JsonDataProvider
    {
        private readonly string _filePath;

        public JsonDataProvider(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<(IEnumerable<Store> Stores, IEnumerable<StoreProduct> Products)> LoadDataAsync()
        {
            if (!System.IO.File.Exists(_filePath))
                throw new FileNotFoundException($"File not found: {_filePath}");

            var jsonData = await System.IO.File.ReadAllTextAsync(_filePath);
            var data = JsonSerializer.Deserialize<JsonData>(jsonData);
            if (data == null)
                throw new Exception("Failed to deserialize data.");

            return (data.Stores, data.Products);
        }
    }

    public class JsonData
    {
        public List<Store> Stores { get; set; } = new();
        public List<StoreProduct> Products { get; set; } = new();
    }
}