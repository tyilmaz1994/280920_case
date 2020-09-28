using System.Collections.Generic;

namespace shoppingCard.documents.entities
{
    public class Product
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public List<Campaign> Campaigns { get; set; }
    }
}