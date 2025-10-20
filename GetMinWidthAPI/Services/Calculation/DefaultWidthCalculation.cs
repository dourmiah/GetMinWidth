namespace GetMinWidthAPI.Services.Calculation
{
    public class DefaultWidthCalculation : IWidthCalculation
    {
        public double CalculateWidth(double width, int quantity)
        {
            try
            {
                return quantity * width;
            }
            catch (Exception e)
            {
                Console.WriteLine("The application stopped. An error occured when calculating the default width");
                throw new Exception(e.Message);
            }
            
        }
    }
}
