using shoppingCard.documents.entities;
using shoppingCard.documents.enums;
using System.Collections.Generic;
using System.Linq;

namespace shoppingCard.core.helpers
{
    public static class PriceCalculateHelper
    {
        /// <summary>
        /// ürüne yapılmış indirimleri çarparak toplam indirimi hesaplar
        /// 
        /// NOT: CampaignType Rate olmalı...
        /// </summary>
        /// <param name="campaigns">ürüne yapılmış indirimler</param>
        /// <returns>toplam indirim</returns>
        public static decimal GetTotalCampaignRate(this List<Campaign> campaigns)
        {
            decimal totalCampaign = decimal.One;

            if (campaigns == null || !campaigns.Any())
                return totalCampaign;

            foreach (Campaign campaign in campaigns.Where(x => x.Type == CampaignType.Rate))
                totalCampaign *= campaign.Discount;

            return totalCampaign;
        }

        /// <summary>
        /// ürüne yapılmış indirimleri toplayarak, toplam indirimi hesaplar
        /// 
        /// NOT: CampaignType Amount olmalı...
        /// </summary>
        /// <param name="campaigns">ürüne yapılmış indirimler</param>
        /// <returns>toplam indirim</returns>
        public static decimal GetTotalCampaignPrice(this List<Campaign> campaigns)
        {
            decimal totalCampaign = decimal.Zero;

            if (campaigns == null || !campaigns.Any())
                return totalCampaign;

            foreach (Campaign campaign in campaigns.Where(x => x.Type == CampaignType.Price))
                totalCampaign += campaign.Discount;

            return totalCampaign;
        }


        /// <summary>
        /// indirimli fiyatı yüzde üzerinden hesaplar
        /// </summary>
        /// <param name="productPrice">ürünün fiyatı</param>
        /// <returns>indirimli fiyat</returns>
        public static decimal GetRateReducedPrice(this List<Campaign> campaigns, decimal productPrice)
        {
            if (campaigns == null || !campaigns.Any())
                return productPrice;

            decimal totalCampaign = campaigns.GetTotalCampaignRate();

            return productPrice * totalCampaign;
        }

        /// <summary>
        /// fiyat üzerinden direk indirim hesaplar
        /// örnek: 10 tl indirim gibi...
        /// </summary>
        /// <param name="productPrice">ürünün fiyatı</param>
        /// <returns>indirimli fiyat</returns>
        public static decimal GetReducedPrice(this List<Campaign> campaigns, decimal productPrice)
        {
            if (campaigns == null || !campaigns.Any())
                return productPrice;

            decimal totalCampaign = campaigns.GetTotalCampaignPrice();

            return productPrice - totalCampaign;
        }

        /// <summary>
        /// kategoriye uygulanan kampanyaları recursive çeker, @campaigns değişkenine atar
        /// </summary>
        /// <param name="campaigns">kampanyalar</param>
        /// <param name="category">kategori</param>
        public static void GetCategoryCampaigns(this List<Campaign> campaigns, Category category, CampaignType campaignType)
        {
            if (category == null)
                return;

            if(category.Campaigns != null)
                campaigns.AddRange(category.Campaigns.Where(x => x.Type == campaignType));

            GetCategoryCampaigns(campaigns, category.ParentCategory, campaignType);
        }

        /// <summary>
        /// sepete uygulanmış kuponun indirim yüzdesini hesaplar
        /// </summary>
        /// <param name="coupons">kuponlar</param>
        /// <param name="countOfCartProducts">sepetteki ürün sayısı</param>
        /// <returns>sepete uygulanmış toplam kupon indirimi</returns>
        public static decimal GetTotalCouponDiscount(this List<Coupon> coupons, int countOfCartProducts)
        {
            decimal totalDiscount = decimal.One;

            if (coupons == null)
                return totalDiscount;

            foreach (Coupon coupon in coupons.Where(x => x.Amount < countOfCartProducts))
                totalDiscount *= coupon.Discount;

            return totalDiscount;
        }
    }
}