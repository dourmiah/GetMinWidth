namespace GetMinWidthAPI.Models
{
    /// <summary>
    /// Represents a product
    /// </summary>
    public class Product
    {
        // Product id
        public string Id
        {
            get;
            set;
        }

        // Product name
        public string Name
        {
            get;
            set;
        } = string.Empty;

        // Product width
        public double Width { get; set; }

        // Method for calculating the surface area occupied by the product
        public string Calculation { get; set; } = "Default";
    }
}
