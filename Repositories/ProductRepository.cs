using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Web.Data;
using ProductManagement.Web.Models;
using ProductManagement.Web.Repositories.Interfaces;

namespace ProductManagement.Web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Products.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.

        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}