using GetMinWidthAPI.Models;
using GetMinWidthAPI.Repositories;
using GetMinWidthAPI.Services.Calculation;

namespace GetMinWidthAPITest
{
    /// <summary>
    /// Test Order Service
    /// </summary>
    public class OrderServiceTest
    {
        // Test the processing of an order
        [Fact]
        public async Task Order_Processing()
        {
            var productRepo = new ProductRepository();
            await productRepo.AddProduct(new Product { Id = "PhotoBook", Name = "Photo Book", Width = 19, Calculation = "Default" });
            await productRepo.AddProduct(new Product { Id = "Mug", Name = "Mug", Width = 94, Calculation = "MugCalculation" });

            var orderRepo = new OrderRepository();
            var factory = new WidthCalculationFactory();
            var calc = new WidthCalculator(productRepo, factory);
            var service = new OrderService(orderRepo, calc);

            var order = new Order { Id = "Order1", products = { { "PhotoBook", 1 }, { "Mug", 2 } } };
            var newOrder = await service.CreateOrder(order);
            Assert.Equal(113, newOrder.MinimalBinWidth);

            var getOrder = await service.GetOrder("Order1");
            Assert.NotNull(getOrder);
            Assert.Equal(113, getOrder!.MinimalBinWidth);
        
        }
    }
}
