// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace WooliesxChallenge.Proxy.Resource.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DeveloperExerciseModelsSortShopperOrders
    {
        /// <summary>
        /// Initializes a new instance of the
        /// DeveloperExerciseModelsSortShopperOrders class.
        /// </summary>
        public DeveloperExerciseModelsSortShopperOrders()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// DeveloperExerciseModelsSortShopperOrders class.
        /// </summary>
        public DeveloperExerciseModelsSortShopperOrders(int? customerId = default(int?), IList<DeveloperExerciseModelsSortProduct> products = default(IList<DeveloperExerciseModelsSortProduct>))
        {
            CustomerId = customerId;
            Products = products;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customerId")]
        public int? CustomerId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "products")]
        public IList<DeveloperExerciseModelsSortProduct> Products { get; set; }

    }
}