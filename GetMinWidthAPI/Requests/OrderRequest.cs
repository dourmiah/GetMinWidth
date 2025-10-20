namespace GetMinWidthAPI.Requests
{
    /// <summary>
    /// Represents the data sent by the client to the API
    /// </summary>
    public class OrderRequest
    {
        public string Id { get; set; } = string.Empty;
        public Dictionary<string, int> Products { get; set; } = new();
    }
}
