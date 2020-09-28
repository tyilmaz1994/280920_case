using shoppingCard.documents.entities;

namespace shoppingCard.documents.interfaces.aggregates
{
    public interface INumberOfProduct
    {
        /// <summary>
        /// sepetteki değişken ürün sayısını hesaplar
        /// </summary>
        /// <param name="shoppingCard">sepet</param>
        /// <returns>sepetteki toplam ürün sayısı</returns>
        int Calculate(Cart shoppingCard);
    }
}
