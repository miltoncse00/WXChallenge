using System.Collections.Generic;

namespace WooliesxChallenge.Domain.Models
{
    public class TrolleySpecialModel
    {
        public IEnumerable<TrolleyQuantityModel> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}
