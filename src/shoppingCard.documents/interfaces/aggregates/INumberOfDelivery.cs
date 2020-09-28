using shoppingCard.documents.entities;

namespace shoppingCard.documents.interfaces.aggregates
{
    public interface INumberOfDelivery
    {
        /// <summary>
        /// sepetteki teslimat noktalarını hesaplar
        /// </summary>
        /// <param name="shoppingCard">sepet</param>
        /// <returns>toplam teslimat nokta sayısı</returns>
        int Calculate(Cart shoppingCard);
    }
}
