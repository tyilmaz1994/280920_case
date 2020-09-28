using shoppingCard.documents.entities;
using shoppingCard.documents.interfaces.aggregates;

namespace shoppingCard.core.aggregates
{
    public class NumberOfDelivery : INumberOfDelivery
    {
        public int Calculate(Cart shoppingCard)
        {
            return shoppingCard.ProductTransactions.Count;
        }
    }
}
