using GetMinWidthAPI.Models;
using GetMinWidthAPI.Repositories;
using GetMinWidthAPI.Services.Calculation;
using System.Threading.Tasks;

namespace GetMinWidthAPITest
{
    /// <summary>
    /// Test Width Calculator
    /// </summary>
    public class CalculatorTests
    {
        // Test sum calculation with products except mugs
        [Fact]
        public async Task Calculate_Sum_Products_Except_Mugs()
        {
            var repo = new ProductRepository();
            await repo.AddProduct(new Product { Id = "PhotoBook", Name = "Photo Book", Width = 19, Calculation = "Default" });
            var factory = new WidthCalculationFactory();
            var calculator = new WidthCalculator(repo, factory);
            var total = await calculator.CalculateWidth(new Dictionary<string, int> { { "PhotoBook", 3 }});
            Assert.Equal(57, total);
        }

        // Test sum calculation with mugs
        [Fact]
        public async Task Calculate_Sum_Products_Mugs()
        {
            var repo = new ProductRepository();
            await repo.AddProduct(new Product { Id = "Mug", Name = "Mug", Width = 94, Calculation = "MugCalculation" });
            var factory = new WidthCalculationFactory();
            var calculator = new WidthCalculator(repo, factory);
            var total = await calculator.CalculateWidth(new Dictionary<string, int> { { "Mug", 5 } });
            Assert.Equal(188, total);
        }
    }
}
