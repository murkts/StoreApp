namespace StoreApp.BLL.Services;

using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Interfaces;
using StoreApp.Data.Entities;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task CreateProductAsync(string name)
    {
        var product = new Product { Name = name };
        await _productRepository.CreateAsync(product);
    }

    public Task<Product?> GetProductByNameAsync(string name)
        => _productRepository.GetByNameAsync(name);

    public Task<IEnumerable<Product>> GetAllProductsAsync()
        => _productRepository.GetAllAsync();
}