using CLEAN_ARCH.DOMAIN.Entities;
using CLEAN_ARCH.DOMAIN.Interfaces;
using CLEAN_ARCH.INFRA.DATA.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEAN_ARCH.INFRA.DATA.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();  
            return product;
        }   

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product?> GetProductCategoryAsync(int? id)
        {
            return await _context.Products.Include(x => x.Category).SingleOrDefaultAsync(pd => pd.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
