using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
        Task<bool> SaveChangesAsync();
    }
}