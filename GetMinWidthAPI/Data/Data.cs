using GetMinWidthAPI.Models;
using GetMinWidthAPI.Repositories;

namespace GetMinWidthAPI.Data
{
    public static class Data
    {
        /// <summary>
        /// Feed the Product repository with data
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task FeedData(IProductRepository repository)
        {
            Product[] products = 
            {
                new Product { Id = "PhotoBook", Name = "Photo Book", Width = 19, Calculation = "Default" },
                new Product { Id = "Calendar", Name = "Calendar", Width = 10, Calculation = "Default" },
                new Product { Id = "Canvas", Name = "Canvas", Width = 16, Calculation = "Default" },
                new Product { Id = "Cards", Name = "Greeting Cards", Width = 4.7, Calculation = "Default" },
                new Product { Id = "Mug", Name = "Mug", Width = 94, Calculation = "MugCalculation" }
            };

            foreach (var product in products)
            {
                await repository.AddProduct(product);
            }
        }
    }
}
