using AutoMapper;
using ProductManagement.Web.DTOs;
using ProductManagement.Web.Models;
using ProductManagement.Web.Repositories.Interfaces;
using ProductManagement.Web.Services.Interfaces;

namespace ProductManagement.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> CreateProductAsync(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(ProductUpdateDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productDto.Id);
            if (existingProduct == null) return false;

            _mapper.Map(productDto, existingProduct);

            _productRepository.Update(existingProduct);
            return await _productRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            _productRepository.Delete(product);
            return await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}