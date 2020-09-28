using shoppingCard.documents.entities;
using shoppingCard.documents.interfaces.aggregates;

namespace shoppingCard.core.aggregates.priceCalculation
{
    public class DeliveryCostAggregate : IDeliveryCostAggregate
    {
        private readonly INumberOfDelivery _numberOfDelivery;
        private readonly INumberOfProduct _numberOfProduct;

        public decimal MinDeliveryCost { get; set; } = 5; // varsayılan taban 5tl teslimat ücreti

        public DeliveryCostAggregate(INumberOfProduct numberOfProduct, INumberOfDelivery numberOfDelivery)
        {
            _numberOfDelivery = numberOfDelivery;
            _numberOfProduct = numberOfProduct;
        }

        public decimal Calculate(Cart shoppingCard)
        {
            return _numberOfProduct.Calculate(shoppingCard) + _numberOfDelivery.Calculate(shoppingCard) + MinDeliveryCost;
        }
    }
}