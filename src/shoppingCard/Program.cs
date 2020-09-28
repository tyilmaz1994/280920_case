using shoppingCard.core.container;
using shoppingCard.documents.entities;
using shoppingCard.documents.enums;
using shoppingCard.documents.interfaces.aggregates;
using System;
using System.Collections.Generic;

namespace shoppingCard
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerHelper.Install();

            Category category = new Category
            {
                Title = "food",
            };

            Product apple = new Product
            {
                Title = "Apple",
                Price = 100.0M,
                Category = category,
                Campaigns = new List<Campaign>
                {
                    new Campaign
                    {
                        Type = CampaignType.Price,
                        Discount = 2 // 2 tl indirim
                    }
                }
            };

            Product almond = new Product
            {
                Title = "Almonds",
                Price = 150.0M,
                Category = category
            };

            Cart shoppingCard = new Cart
            {
                ProductTransactions = new List<ProductTransaction>
                {
                    new ProductTransaction
                    {
                        Product = apple,
                        Quantity = 5,
                    },
                    new ProductTransaction
                    {
                        Product = almond,
                        Quantity = 4,
                    },
                },
                Coupons = new List<Coupon>
                {
                    new Coupon
                    {
                        Amount = 1,
                        Discount = 0.9M
                    }
                }
            };

            ICartWithCouponPriceAggregate cartWithCouponPriceAggregate = ContainerHelper.Resolve<ICartWithCouponPriceAggregate>();
            IDeliveryCostAggregate deliveryCostAggregate = ContainerHelper.Resolve<IDeliveryCostAggregate>();

            Console.WriteLine(string.Format("sepetteki ürünlerin toplam fiyatı: {0} tl", cartWithCouponPriceAggregate.Calculate(shoppingCard)));
            Console.WriteLine(string.Format("sepetteki ürünlerin teslimat ücreti: {0} tl", deliveryCostAggregate.Calculate(shoppingCard)));
        }
    }
}
