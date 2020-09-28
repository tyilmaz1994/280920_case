using shoppingCard.core.helpers;
using shoppingCard.documents.entities;
using shoppingCard.documents.enums;
using shoppingCard.documents.interfaces.aggregates;
using System.Collections.Generic;

namespace shoppingCard.core.aggregates.priceCalculation
{
    public class ProductWithCampaignPriceAggregate : ProductTotalPriceAggregate, IProductWithCampaignPriceAggregate
    {
        /// <summary>
        /// ürünün gerçek fiyatına indirim uygular
        /// </summary>
        public override decimal Calculate(ProductTransaction productTransaction)
        {
            var productPrice = base.Calculate(productTransaction);

            return CalculateReducedPrice(productTransaction, productPrice);
        }

        /// <summary>
        /// ürünün indirimli fiyatını hesaplar
        /// </summary>
        private decimal CalculateReducedPrice(ProductTransaction productTransaction, decimal productPrice)
        {
            productPrice = CalculateCategoryCampaign(productTransaction, productPrice);

            var campaigns = productTransaction.Product.Campaigns;

            productPrice = campaigns.GetRateReducedPrice(productPrice);
            productPrice = campaigns.GetReducedPrice(productPrice);

            return productPrice;
        }

        /// <summary>
        /// kategoriye uygulanan indirimi ürüne uygular
        /// </summary>
        /// <param name="productTransaction">ürün hareketi</param>
        /// <param name="productPrice">ürün fiyatı</param>
        /// <returns>ürünün kategorisine yapılmış indirimin çıkartılmış fiyatı</returns>
        private decimal CalculateCategoryCampaign(ProductTransaction productTransaction, decimal productPrice)
        {
            List<Campaign> campaigns = new List<Campaign>();

            //yüzdeli indirim
            campaigns.GetCategoryCampaigns(productTransaction.Product.Category, CampaignType.Rate);

            productPrice = campaigns.GetRateReducedPrice(productPrice);

            //fiyat üzerinden indirim
            campaigns.GetCategoryCampaigns(productTransaction.Product.Category, CampaignType.Price);

            productPrice = campaigns.GetReducedPrice(productPrice);

            return productPrice;
        }
    }
}
