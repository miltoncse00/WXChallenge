using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesxChallenge.Domain.Models
{
    public class TrolleySpecialModel
    {
        public IEnumerable<TrolleyQuantityModel> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}
