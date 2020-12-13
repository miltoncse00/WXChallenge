using System.Collections.Generic;
using WooliesxChallenge.Domain.Models;

namespace WooliesxChallenge.Domain
{
    public class TrolleyRequest
    {
        public IEnumerable<TrolleyProductModel> Products { get; set; }
        public IEnumerable<TrolleySpecialModel> Specials { get; set; }
        public IEnumerable<TrolleyQuantityModel> Quantities { get; set; }

    }
}
