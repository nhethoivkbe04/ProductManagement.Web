using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.Web.DTOs;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> CreateProductAsync(ProductCreateDto productDto);
        Task<bool> UpdateProductAsync(ProductUpdateDto productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}