using shoppingCard.documents.entities;

namespace shoppingCard.documents.interfaces.aggregates
{
    public interface ICartTotalPriceAggregate
    {
        /// <summary>
        /// sepetin içindeki ürünlerin toplam fiyatını hesaplar
        /// </summary>
        /// <param name="shoppingCard">sepet</param>
        /// <returns>sepetin toplam tutarı</returns>
        decimal Calculate(Cart shoppingCard);
    }
}
