using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Enums;
using WooliesxChallenge.Domain.Interfaces;

namespace WooliesxChallenge.Application
{
    public class ProductService : IProductService
    {
        private readonly IDevChallengeResourceProxy _devChallengeResourceProxy;
        private readonly UserSetting _userSetting;

        public ProductService(IDevChallengeResourceProxy devChallengeResourceProxy, IOptions<UserSetting> userSettingOptions)
        {
            _devChallengeResourceProxy = devChallengeResourceProxy;
            _userSetting = userSettingOptions.Value;
        }
        public async Task<IList<Product>> GetProductAsync(SortOption sortOption)
        {
            if (sortOption == SortOption.Recommended)
                return await GetRecommendedProductAsync();

            return await GetProductSortedAsync(sortOption);
        }

        private async Task<IList<Product>> GetProductSortedAsync(SortOption sortOption)
        {
            var products = (await _devChallengeResourceProxy.GetProductAsync(_userSetting.Token)).ToList();
            if (products.Count == 0)
            {
                return products;
            }

            var result = new List<Product>();
            switch (sortOption)
            {
                case SortOption.High:
                    result = products.OrderByDescending(s => s.Price).ToList();
                    break;
                case SortOption.Low:
                    result = products.OrderBy(s => s.Price).ToList();
                    break;
                case SortOption.Ascending:
                    result = products.OrderBy(s => s.Name).ToList();
                    break;
                case SortOption.Descending:
                    result = products.OrderByDescending(s => s.Name).ToList();
                    break;
            }

            return result;
        }

        private async Task<IList<Product>> GetRecommendedProductAsync()
        {
            var shopperHistories = await _devChallengeResourceProxy.GetShopperHistoryAsync(_userSetting.Token);
            var products = shopperHistories.SelectMany(s => s.Products).GroupBy(s => s.Name).Select(r =>
                    new
                    {
                        Product =
                            new Product {Name = r.Key, Price = r.First().Price, Quantity = r.Sum(x => x.Quantity)},
                        SaleCount = r.Count()
                    }
                ).OrderByDescending(r => r.SaleCount).ThenByDescending(x => x.Product.Quantity).Select(x => x.Product)
                .ToList();
            return products;
        }
    }
}