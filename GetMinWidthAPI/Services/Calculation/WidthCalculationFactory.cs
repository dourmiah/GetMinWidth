namespace GetMinWidthAPI.Services.Calculation
{
    /// <summary>
    /// Factory for the calculation method 
    /// </summary>
    public class WidthCalculationFactory
    {
        public IWidthCalculation CreateCalculationMethod(string calculation)
        {
            return calculation switch
            {
                "MugCalculation" => new MugWidthCalculation(4),
                _ => new DefaultWidthCalculation()
            };
        }
    }
}
