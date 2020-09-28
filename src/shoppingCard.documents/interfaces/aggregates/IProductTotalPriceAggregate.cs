using shoppingCard.documents.entities;

namespace shoppingCard.documents.interfaces.aggregates
{
    public interface IProductTotalPriceAggregate
    {
        /// <summary>
        /// verilen ürünün toplam fiyatını hesaplar
        /// NOT : miktar * fiyat
        /// </summary>
        /// <param name="productTransaction">septe eklenen ürün</param>
        /// <returns>ürünün toplam fiyatı</returns>
        decimal Calculate(ProductTransaction productTransaction);
    }
}
