using CLEAN_ARCH.DOMAIN.Entities;

namespace CLEAN_ARCH.DOMAIN.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetByIdAsync(int? id);

        Task<Product> GetProductCategoryAsync(int? id);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<Product> RemoveAsync(Product product);
    }
}
