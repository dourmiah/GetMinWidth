using GetMinWidthAPI.Models;
using System.Collections.Concurrent;

namespace GetMinWidthAPI.Repositories
{
    /// <summary>
    /// Store for the orders
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly ConcurrentDictionary<string, Order> _repository = new();
        public Task CreateOrder(Order order)
        {
            _repository[order.Id] = order;
            return Task.CompletedTask;
        }

        public Task<Order?> GetById(string id)
        {
            _repository.TryGetValue(id, out Order? order);
            return Task.FromResult(order);
        }
    }
}
