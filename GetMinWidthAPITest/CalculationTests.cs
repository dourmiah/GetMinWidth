using GetMinWidthAPI.Services.Calculation;

namespace GetMinWidthAPITest
{
    /// <summary>
    /// Test Default and Mug calculations
    /// </summary>
    public class CalculationTests
    {
        [Fact]
        public void DefaultCalculation()
        {
            var calc = new DefaultWidthCalculation();
            Assert.Equal(30, calc.CalculateWidth(10, 3));
        }

        [Fact]
        public void MugCalculation()
        {
            var calc = new MugWidthCalculation();
            Assert.Equal(94, calc.CalculateWidth(94, 1));
            Assert.Equal(94, calc.CalculateWidth(94, 4));
            Assert.Equal(188, calc.CalculateWidth(94, 5));
        }
    }
}