using System.Collections.Generic;

namespace shoppingCard.documents.entities
{
    public class Cart
    {
        public List<ProductTransaction> ProductTransactions { get; set; }

        public List<Coupon> Coupons { get; set; }
    }
}