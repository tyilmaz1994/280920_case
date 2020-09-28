using System.Collections.Generic;

namespace shoppingCard.documents.entities
{
    public class Category
    {
        public string Title { get; set; }

        public Category ParentCategory { get; set; }

        public List<Campaign> Campaigns { get; set; }
    }
}