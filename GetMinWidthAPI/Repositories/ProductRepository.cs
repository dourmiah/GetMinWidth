using GetMinWidthAPI.Models;
using System.Collections.Concurrent;

namespace GetMinWidthAPI.Repositories
{
    /// <summary>
    /// Store for the products
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<string, Product> _repository = new();

        public Task AddProduct(Product product)
        {
            _repository[product.Id] = product;
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAll() => Task.FromResult(_repository.Values.AsEnumerable());

        public Task<Product?> GetById(string id)
        {
            _repository.TryGetValue(id, out Product? product);
            return Task.FromResult(product);
        }
    }
}
