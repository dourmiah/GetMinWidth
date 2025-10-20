namespace GetMinWidthAPI.Models
{
    /// <summary>
    /// Represents an order
    /// </summary>
    public class Order
    {
        // Order id
        public string Id { get; set; } = string.Empty;

        // Products of the order
        public Dictionary<string, int> products { get; set; } = new();

        // Minimum bin width for the products
        public double MinimalBinWidth { get; set; }
    }
}
