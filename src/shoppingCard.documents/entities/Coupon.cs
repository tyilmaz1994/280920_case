using shoppingCard.documents.enums;

namespace shoppingCard.documents.entities
{
    public class Coupon
    {
        /// <summary>
        /// coupon has minimum cart amount constraint. 
        /// if cart amount is less than minimum, discount is not applied
        /// </summary>
        public int Amount { get; set; }

        public decimal Discount { get; set; }
    }
}