using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Interfaces;
using StoreApp.Entities;

namespace StoreApp.BLL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync(); 
        }
        public async Task<Product?> GetProductByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя продукта не может быть пустым", nameof(name));
            }

            return await _productRepository.GetByNameAsync(name); 
        }
        public async Task CreateProductAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя продукта не может быть пустым", nameof(name));
            }

            var product = new Product { Name = name }; 
            await _productRepository.CreateAsync(product);
        }
    }
}