using GetMinWidthAPI.Repositories;
using GetMinWidthAPI.Models;

namespace GetMinWidthAPI.Services.Calculation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly WidthCalculator _calculator;

        public OrderService(IOrderRepository repository, WidthCalculator calculator)
        {
            _calculator = calculator;
            _repository = repository;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            order.MinimalBinWidth = await _calculator.CalculateWidth(order.products);
            await _repository.CreateOrder(order);
            return order;
        }

        public Task<Order?> GetOrder(string id) => _repository.GetById(id);
    }
}
