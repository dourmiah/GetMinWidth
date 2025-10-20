namespace GetMinWidthAPI.Services.Calculation
{
    public class MugWidthCalculation : IWidthCalculation
    {
        private readonly int _stackSize;
        public MugWidthCalculation(int stackSize = 4) => _stackSize = stackSize;
        public double CalculateWidth(double width, int quantity)
        {
            try
            {
                var stack = Math.Ceiling(quantity / (double)_stackSize);
                return stack * width;
            }
            catch (Exception e)
            {
                Console.WriteLine("The application stopped. An error occured when calculating the mug(s) width");
                throw new Exception(e.Message);
            }
            
        }
    }
}
