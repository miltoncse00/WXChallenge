using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Models;

namespace WooliesxChallenge.Application
{
    public class TrolleyCalculatorService : ITrolleyCalculatorService
    {
        public decimal CalculateTotal(TrolleyRequest trolleyRequest)
        {
            var productPriceMap = trolleyRequest.Products.ToDictionary(r => r.Name, r => r.Price);
            var sums = new List<decimal>();
            decimal maxTotal = 0;
            foreach (var quantity in trolleyRequest.Quantities)
            {
                maxTotal += quantity.Quantity * productPriceMap[quantity.Name];
            }
            sums.Add(maxTotal);

            var quantityMap = trolleyRequest.Quantities.ToDictionary(r => r.Name, r => r.Quantity);

            var productNames = trolleyRequest.Products.Select(r => r.Name).ToList();

            foreach (var special in trolleyRequest.Specials)
            {
                if (CheckSpecialMatchesAllProducts(special, productNames))
                    continue;

                decimal totalWithoutSpecialPrice = 0;
                var minSpecialMultiplier = GetMinSpecialMultiplier(special, quantityMap);
                foreach (var spectialQuantity in special.Quantities)
                {
                    var quantityRemaining = (GetQuantityByName(quantityMap, spectialQuantity.Name) - spectialQuantity.Quantity * minSpecialMultiplier);
                    
                    totalWithoutSpecialPrice += GetPriceByName(productPriceMap, spectialQuantity.Name) *
                                    (quantityRemaining > 0 ? quantityRemaining : 0);
                }
                sums.Add(totalWithoutSpecialPrice + special.Total * minSpecialMultiplier);
            }

            var minTotal = sums.Min();

            return minTotal;
        }

        private static bool CheckSpecialMatchesAllProducts(TrolleySpecialModel special, List<string> productNames)
        {
            return special.Quantities.Any(r => !productNames.Contains(r.Name, StringComparer.InvariantCultureIgnoreCase));
        }

        private static decimal GetPriceByName(Dictionary<string, decimal> productPriceMap, string name)
        {
            if (!productPriceMap.ContainsKey(name))
                throw new ValidationException($"Can not find Product price of item {name}");
            return productPriceMap[name];
        }

        private static int GetQuantityByName(Dictionary<string, int> quantityMap, string name)
        {
            if (!quantityMap.ContainsKey(name))
                throw new ValidationException($"Can not find Quantity value of item {name}");
            return quantityMap[name];
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
                quantityMap[r.Name] <= r.Quantity ? 1 : GetQuantityByName(quantityMap, r.Name) / r.Quantity);
            return minSpecialMultiplier;
        }
    }
}