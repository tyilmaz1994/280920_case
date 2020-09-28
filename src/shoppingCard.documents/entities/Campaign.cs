using shoppingCard.documents.enums;

namespace shoppingCard.documents.entities
{
    public class Campaign
    {
        /// <summary>
        /// 0 ile 1 arası olabilir...
        /// örnek:
        ///     0.5 => %50 indirim demektir
        /// </summary>
        public decimal Discount { get; set; }

        public CampaignType Type { get; set; }
    }
}