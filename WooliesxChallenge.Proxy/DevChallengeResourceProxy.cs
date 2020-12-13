using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Interfaces;
using WooliesxChallenge.Proxy.Resource;
using WooliesxChallenge.Proxy.Resource.Models;

namespace WooliesxChallenge.Proxy
{
    public class DevChallengeResourceProxy : IDevChallengeResourceProxy
    {
        private readonly IDevChallengeResourceClient _devChallengeResourceClient;

        public DevChallengeResourceProxy(IDevChallengeResourceClient devChallengeResourceClient)
        {
            _devChallengeResourceClient = devChallengeResourceClient;
        }

        public async Task<IList<Product>> GetProductAsync(Guid token)
        {
            return (await _devChallengeResourceClient.ApiResourceProductsGetAsync(token)).Select(s =>
                new Product
                {
                    Name = s.Name,
                    Price = (decimal)(s.Price ?? 0),
                    Quantity = (decimal)(s.Quantity ?? 0)
                }
                ).ToList();
        }

        public async Task<IList<ShopperHistory>> GetShopperHistoryAsync(Guid token)
        {
            return (await _devChallengeResourceClient.ApiResourceShopperHistoryGetAsync(token)).Select(
                s => new ShopperHistory
                {
                    CustomerId = s.CustomerId ?? 0,
                    Products = new List<Product>(s.Products.Select(r =>
                        new Product
                        {
                            Name = r.Name,
                            Price = (decimal)(r.Price ?? 0),
                            Quantity = (decimal)(r.Quantity ?? 0)
                        }))
                }
                ).ToList();
        }
    }
}
