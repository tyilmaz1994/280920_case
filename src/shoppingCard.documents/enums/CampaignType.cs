namespace shoppingCard.documents.enums
{
    public enum CampaignType
    {
        /// <summary>
        /// yüzde üzerinden kampanya
        /// 
        /// örnek:
        ///  fiyatta %10 indirim (discount: 0.9 olur)
        /// </summary>
        Rate = 1,
        /// <summary>
        ///  ücret üzerinden kampanya
        ///  
        /// örnek:
        ///  100 tl lik ürüne 5 tl indirim yap (discount: 5 olur)
        /// </summary>
        Price = 2,
    }
}
