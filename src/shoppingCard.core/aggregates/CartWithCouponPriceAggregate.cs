using shoppingCard.core.helpers;
using shoppingCard.documents.entities;
using shoppingCard.documents.interfaces.aggregates;

namespace shoppingCard.core.aggregates.priceCalculation
{
    public class CartWithCouponPriceAggregate : ICartWithCouponPriceAggregate
    {
        private readonly ICartTotalPriceAggregate _cartPriceAggregate;

        public CartWithCouponPriceAggregate(ICartTotalPriceAggregate cartPriceAggregate)
        {
            _cartPriceAggregate = cartPriceAggregate;
        }

        public decimal Calculate(Cart shoppingCard)
        {
            var cartTotalPrice = _cartPriceAggregate.Calculate(shoppingCard);

            cartTotalPrice *= shoppingCard.Coupons.GetTotalCouponDiscount(shoppingCard.ProductTransactions.Count);

            return cartTotalPrice;
        }
    }
}

