using GetMinWidthAPI.Models;

namespace GetMinWidthAPI.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
        Task<Order?> GetById(string id);
    }
}
