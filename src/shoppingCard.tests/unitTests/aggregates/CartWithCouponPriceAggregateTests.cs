using shoppingCard.documents.entities;
using shoppingCard.documents.enums;
using shoppingCard.documents.interfaces.aggregates;
using System.Collections.Generic;
using Xunit;

namespace shoppingCard.tests.unitTests.aggregates
{
    public class CartWithCouponPriceAggregateTests : AbstractTests
    {
        [Fact]
        public void Calculate_no_campaign_no_coupon_tests()
        {
            ICartWithCouponPriceAggregate cartWithCouponPriceAggregate = Resolve<ICartWithCouponPriceAggregate>();

            var actualPrice = cartWithCouponPriceAggregate.Calculate(EmptyCardData());

            Assert.Equal(250.43M, actualPrice);
        }

        [Fact]
        public void Calculate_coupon_under_amount_tests()
        {
            ICartWithCouponPriceAggregate cartWithCouponPriceAggregate = Resolve<ICartWithCouponPriceAggregate>();

            var cart = EmptyCardData();

            cart.Coupons = new List<Coupon>
            {
                new Coupon
                {
                    Amount = 3,
                    Discount = 0.9M,
                }
            };

            var actualPrice = cartWithCouponPriceAggregate.Calculate(cart);

            Assert.Equal(250.43M, actualPrice);
        }

        [Fact]
        public void Calculate_coupon_amount_tests()
        {
            ICartWithCouponPriceAggregate cartWithCouponPriceAggregate = Resolve<ICartWithCouponPriceAggregate>();

            var cart = EmptyCardData();

            cart.Coupons = new List<Coupon>
            {
                new Coupon
                {
                    Amount = 2,
                    Discount = 0.9M,
                }
            };

            var actualPrice = cartWithCouponPriceAggregate.Calculate(cart);

            Assert.Equal(225.387M, actualPrice);
        }

        [Fact]
        public void Calculate_coupon_and_product_campaign_tests()
        {
            ICartWithCouponPriceAggregate cartWithCouponPriceAggregate = Resolve<ICartWithCouponPriceAggregate>();

            var cart = EmptyCardData();

            cart.Coupons = new List<Coupon>
            {
                new Coupon
                {
                    Amount = 2,
                    Discount = 0.9M,
                }
            };

            cart.ProductTransactions[0].Product.Campaigns = new List<Campaign>
            {
                new Campaign
                {
                    Discount = 0.9M,
                    Type = CampaignType.Rate,
                }
            };

            var actualPrice = cartWithCouponPriceAggregate.Calculate(cart);

            Assert.Equal(219.9888M, actualPrice);
        }
    }
}
