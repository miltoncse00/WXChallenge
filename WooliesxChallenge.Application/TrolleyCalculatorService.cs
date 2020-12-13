using System.Collections.Generic;
using System.Linq;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Models;

namespace WooliesxChallenge.Application
{
    public class TrolleyCalculatorService : ITrolleyCalculatorService
    {
        public decimal CalculateTotal(TrolleyRequest trolleyRequest)
        {
            decimal minTotal;
            var productPriceMap = trolleyRequest.Products.ToDictionary(r => r.Name, r => r.Price);
            var sums = new List<decimal>();
            decimal maxTotal = 0;
            foreach (var quantity in trolleyRequest.Quantities)
            {
                maxTotal += quantity.Quantity * productPriceMap[quantity.Name];
            }
            sums.Add(maxTotal);

            var quantityMap = trolleyRequest.Quantities.ToDictionary(r => r.Name, r => r.Quantity);


            foreach (var special in trolleyRequest.Specials)
            {
                decimal specialTotal = 0;
                var minSpecialMultiplier = GetMinSpecialMultiplier(special, quantityMap);
                foreach (var spectialQuantity in special.Quantities)
                {
                    var quantityRemaining = (quantityMap[spectialQuantity.Name] - spectialQuantity.Quantity * minSpecialMultiplier);
                    specialTotal += productPriceMap[spectialQuantity.Name] *
                                    (quantityRemaining > 0 ? quantityRemaining : 0);
                }
                sums.Add(specialTotal + special.Total* minSpecialMultiplier);
            }

            minTotal = sums.Min();

            return minTotal;
        }

        /// <summary>
        /// Calculate mininum times of special quantities can be taken 
        /// </summary>
        /// <param name="special"></param>
        /// <param name="quantityMap"></param>
        /// <returns></returns>
        private static int GetMinSpecialMultiplier(TrolleySpecialModel special, Dictionary<string, int> quantityMap)
        {
            var minSpecialMultiplier = special.Quantities.Min(r =>
                quantityMap[r.Name] <= r.Quantity ? 1 : quantityMap[r.Name] / r.Quantity);
            return minSpecialMultiplier;
        }
    }
}