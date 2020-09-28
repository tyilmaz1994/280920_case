using shoppingCard.documents.entities;
using shoppingCard.documents.interfaces.aggregates;

namespace shoppingCard.core.aggregates.priceCalculation
{
    public class ProductTotalPriceAggregate : IProductTotalPriceAggregate
    {
        public virtual decimal Calculate(ProductTransaction productTransaction)
        {
            return productTransaction.Quantity * productTransaction.Product.Price;
        }
    }
}