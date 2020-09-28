using shoppingCard.documents.entities;
using shoppingCard.documents.interfaces.aggregates;

namespace shoppingCard.core.aggregates.priceCalculation
{
    public class CartTotalPriceAggregate : ICartTotalPriceAggregate
    {
        private readonly IProductWithCampaignPriceAggregate _productTotalPriceAggregate;

        public CartTotalPriceAggregate(IProductWithCampaignPriceAggregate productTotalPriceAggregate)
        {
            _productTotalPriceAggregate = productTotalPriceAggregate;
        }

        public decimal Calculate(Cart shoppingCard)
        {
            decimal shoppingCardPrice = decimal.Zero;

            foreach (ProductTransaction productTransaction in shoppingCard.ProductTransactions)
                shoppingCardPrice += _productTotalPriceAggregate.Calculate(productTransaction);

            return shoppingCardPrice;
        }
    }
}
