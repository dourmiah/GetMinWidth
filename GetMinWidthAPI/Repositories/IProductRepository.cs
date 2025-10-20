using GetMinWidthAPI.Models;

namespace GetMinWidthAPI.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetById(string id);
        Task AddProduct(Product product);
        Task<IEnumerable<Product>> GetAll();
    }
}
