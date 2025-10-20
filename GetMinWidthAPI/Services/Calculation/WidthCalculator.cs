using GetMinWidthAPI.Repositories;

namespace GetMinWidthAPI.Services.Calculation
{
    public class WidthCalculator
    {
        private readonly IProductRepository _repository;
        private readonly WidthCalculationFactory _factory;

        public WidthCalculator(IProductRepository repository, WidthCalculationFactory factory)
        {
            _factory = factory;
            _repository = repository;
        }

        public async Task<double> CalculateWidth(Dictionary<string, int> products)
        {
            double totalWidth = 0;
            try
            {
                foreach (var prod in products)
                {
                    var id = prod.Key;
                    var quantity = prod.Value;
                    if (quantity == 0)
                        continue;
                    var product = await _repository.GetById(id);
                    if (product == null)
                        continue;
                    var calculationMethod = _factory.CreateCalculationMethod(product.Calculation ?? "Default");
                    totalWidth += calculationMethod.CalculateWidth(product.Width, quantity);
                }
                return totalWidth;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
            
        }
    }
}
