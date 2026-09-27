using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Interface.Repositories;
using ProductApp.Domain.Entities;
using ProductApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
          return await context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Id == id); 
        }

        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public Task UpdateAsync(Product product)
        {
            context.Products.Update(product);
            return Task.CompletedTask;
        }


        public Task DeleteAsync(Product product)
        {
            context.Products.Remove(product);
            return Task.CompletedTask;
        }

    }
}
