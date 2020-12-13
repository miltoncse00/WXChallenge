using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Enums;

namespace WooliesxChallenge.Application
{
    public interface IProductService
    {
        public Task<IList<Product>> GetProductAsync(SortOption parsedSortOption);

    }
}
