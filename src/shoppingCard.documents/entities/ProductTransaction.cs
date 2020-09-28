using System.Collections.Generic;

namespace shoppingCard.documents.entities
{
    public class ProductTransaction
    {
        public Product Product { get; set; }

        public decimal Quantity { get; set; }
    }
}