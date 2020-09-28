using shoppingCard.documents.entities;

namespace shoppingCard.documents.interfaces.aggregates
{
    public interface IDeliveryCostAggregate
    {
        /// <summary>
        /// sepetin teslimat ücretini hesaplar
        /// </summary>
        /// <param name="shoppingCard">sepet</param>
        /// <returns>teslimat ücreti</returns>
        decimal Calculate(Cart shoppingCard);
    }
}
