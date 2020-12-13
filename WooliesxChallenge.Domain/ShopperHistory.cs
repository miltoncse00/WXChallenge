using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesxChallenge.Domain
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
