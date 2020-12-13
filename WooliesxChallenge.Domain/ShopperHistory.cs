using System.Collections.Generic;

namespace WooliesxChallenge.Domain
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
