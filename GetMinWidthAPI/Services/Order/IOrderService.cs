using GetMinWidthAPI.Models;

namespace GetMinWidthAPI.Services.Calculation
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        Task<Order?> GetOrder(string id);
    }
}
