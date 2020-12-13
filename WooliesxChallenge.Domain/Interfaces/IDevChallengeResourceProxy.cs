using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WooliesxChallenge.Domain.Interfaces
{
    public interface IDevChallengeResourceProxy
    {
        Task<IList<Product>> GetProductAsync(Guid token);

        Task<IList<ShopperHistory>> GetShopperHistoryAsync(Guid token);
    }
}