using shoppingCard.core.helpers;
using shoppingCard.documents.entities;
using shoppingCard.documents.enums;
using System.Collections.Generic;
using Xunit;

namespace shoppingCard.tests.unitTests.helpers
{
    public class PriceCalculateHelperTests : AbstractTests
    {
        [Fact]
        public void GetTotalCampaignRate_null_campaigns_tests()
        {
            List<Campaign> campaigns = null;

            decimal productCampaignRate = campaigns.GetTotalCampaignRate();

            Assert.Equal(decimal.One, productCampaignRate);
        }

        [Fact]
        public void GetTotalCampaignRate_1element_tests()
        {
            List<Campaign> campaigns = new List<Campaign>
            {
                new Campaign
                {
                    Discount = 0.9M, //%10 indirim
                    Type = CampaignType.Rate,
                },
            };

            decimal productCampaignRate = campaigns.GetTotalCampaignRate();

            Assert.Equal(0.9M, productCampaignRate);
        }

        [Fact]
        public void GetTotalCampaignRate_2element_tests()
        {
            List<Campaign> campaigns = new List<Campaign>
            {
                new Campaign
                {
                    Discount = 0.9M, //%10 indirim
                    Type = CampaignType.Rate,
                },
                new Campaign
                {
                    Discount = 0.9M,
                    Type = CampaignType.Rate,
                },
                new Campaign
                {
                    Discount = 0.9M,
                    Type = CampaignType.Price,
                },
            };

            decimal productCampaignRate = campaigns.GetTotalCampaignRate();

            Assert.Equal(0.81M, productCampaignRate);
        }

        [Fact]
        public void GetTotalCampaignPrice_null_campaigns_tests()
        {
            List<Campaign> campaigns = null;

            decimal productCampaignPrice = campaigns.GetTotalCampaignPrice();

            Assert.Equal(decimal.Zero, productCampaignPrice);
        }

        [Fact]
        public void GetTotalCampaignPrice_1element_tests()
        {
            List<Campaign> campaigns = new List<Campaign>
            {
                new Campaign
                {
                    Discount = 5, //%10 indirim
                    Type = CampaignType.Price,
                },
            };

            decimal productCampaignRate = campaigns.GetTotalCampaignPrice();

            Assert.Equal(5M, productCampaignRate);
        }

        [Fact]
        public void GetTotalCampaignPrice_2element_tests()
        {
            List<Campaign> campaigns = new List<Campaign>
            {
                new Campaign
                {
                    Discount = 0.9M, //%10 indirim
                    Type = CampaignType.Rate,
                },
                new Campaign
                {
                    Discount = 3,
                    Type = CampaignType.Price,
                },
                new Campaign
                {
                    Discount = 6,
                    Type = CampaignType.Price,
                },
            };

            decimal productCampaignRate = campaigns.GetTotalCampaignPrice();

            Assert.Equal(9M, productCampaignRate);
        }

        [Fact]
        public void GetRateReducedPrice_null_campaigns_tests()
        {
            List<Campaign> campaigns = null;

            decimal expectedPrice = 2.1M;

            decimal productCampaignPrice = campaigns.GetRateReducedPrice(expectedPrice);

            Assert.Equal(expectedPrice, productCampaignPrice);
        }

        [Fact]
        public void GetRateReducedPrice_1element_campaigns_tests()
        {
            var discount = 0.75M;

            List<Campaign> campaigns = new List<Campaign> 
            {
                new Campaign
                {
                    Discount = discount,
                    Type = CampaignType.Rate,
                },
            };

            decimal productCampaignPrice = campaigns.GetRateReducedPrice(decimal.One);

            Assert.Equal(discount, productCampaignPrice);
        }

        [Fact]
        public void GetRateReducedPrice_2element_campaigns_tests()
        {
            var discount = 0.75M;

            List<Campaign> campaigns = new List<Campaign>
            {
                new Campaign
                {
                    Discount = discount,
                    Type = CampaignType.Rate,
                },
                new Campaign
                {
                    Discount = discount,
                    Type = CampaignType.Rate,
                }, 
                new Campaign
                {
                    Discount = 2,
                    Type = CampaignType.Price,
                },
            };

            decimal productCampaignPrice = campaigns.GetRateReducedPrice(decimal.One);

            Assert.Equal(discount * discount, productCampaignPrice);
        }

        [Fact]
        public void GetPReducedPrice_null_campaigns_tests()
        {
            List<Campaign> campaigns = null;

            decimal expectedPrice = 2.1M;

            decimal productCampaignPrice = campaigns.GetReducedPrice(expectedPrice);

            Assert.Equal(expectedPrice, productCampaignPrice);
        }

        [Fact]
        public void GetReducedPrice_1element_campaigns_tests()
        {
            var discount = 0.75M;

            List<Campaign> campaigns = new List<Campaign>
            {
                new Campaign
                {
                    Discount = discount,
                    Type = CampaignType.Price,
                },
            };

            decimal productCampaignPrice = campaigns.GetReducedPrice(decimal.One);

            Assert.Equal(decimal.One - discount, productCampaignPrice);
        }

        [Fact]
        public void GetReducedPrice_2element_campaigns_tests()
        {
            var discount = 0.75M;
            var price = 3;

            List<Campaign> campaigns = new List<Campaign>
            {
                new Campaign
                {
                    Discount = discount,
                    Type = CampaignType.Price,
                },
                new Campaign
                {
                    Discount = discount,
                    Type = CampaignType.Price,
                },
                new Campaign
                {
                    Discount = 2,
                    Type = CampaignType.Rate,
                },
            };

            decimal productCampaignPrice = campaigns.GetReducedPrice(price);

            Assert.Equal(price - discount - discount, productCampaignPrice);
        }

        [Fact]
        public void GetCategoryCampaigns_null_campaigns_tests()
        {
            List<Campaign> campaigns = null;

            campaigns.GetCategoryCampaigns(null, CampaignType.Price);

            Assert.Null(campaigns);
        }

        [Fact]
        public void GetCategoryCampaigns_1element_campaigns_tests()
        {
            List<Campaign> campaigns = new List<Campaign>();

            Category category = new Category
            {
                Campaigns = new List<Campaign>
                {
                    new Campaign
                    {
                        Discount = 0.8M,
                        Type = CampaignType.Rate,
                    },
                },
            };

            campaigns.GetCategoryCampaigns(category, CampaignType.Rate);

            var campaignSize = 1;

            Assert.Equal(campaignSize, campaigns.Count);
        }

        [Fact]
        public void GetCategoryCampaigns_2element_rate_campaigns_tests()
        {
            List<Campaign> campaigns = new List<Campaign>();

            Category category = new Category
            {
                Campaigns = new List<Campaign>
                {
                    new Campaign
                    {
                        Discount = 0.8M,
                        Type = CampaignType.Rate,
                    },
                },
                ParentCategory = new Category
                {
                    Campaigns = new List<Campaign>
                    {
                        new Campaign
                        {
                            Discount = 0.8M,
                            Type = CampaignType.Rate,
                        },
                        new Campaign
                        {
                            Discount = 0.8M,
                            Type = CampaignType.Price,
                        },
                    },
                }
            };

            campaigns.GetCategoryCampaigns(category, CampaignType.Rate);

            var campaignSize = 2;

            Assert.Equal(campaignSize, campaigns.Count);
        }


        [Fact]
        public void GetCategoryCampaigns_2element_price_campaigns_tests()
        {
            List<Campaign> campaigns = new List<Campaign>();

            Category category = new Category
            {
                Campaigns = new List<Campaign>
                {
                    new Campaign
                    {
                        Discount = 0.8M,
                        Type = CampaignType.Rate,
                    },
                },
                ParentCategory = new Category
                {
                    Campaigns = new List<Campaign>
                    {
                        new Campaign
                        {
                            Discount = 0.8M,
                            Type = CampaignType.Price,
                        },
                        new Campaign
                        {
                            Discount = 0.8M,
                            Type = CampaignType.Price,
                        },
                    },
                }
            };

            campaigns.GetCategoryCampaigns(category, CampaignType.Price);

            var campaignSize = 2;

            Assert.Equal(campaignSize, campaigns.Count);
        }

        [Fact]
        public void GetTotalCoyponDiscount_null_tests()
        {
            List<Coupon> coupons = null;

            var couponDiscount = coupons.GetTotalCouponDiscount(0);

            Assert.Equal(decimal.One, couponDiscount);
        }

        [Fact]
        public void GetTotalCouponDiscount_minAmount_tests()
        {
            List<Coupon> coupons = new List<Coupon>
            {
                new Coupon
                {
                    Amount = 1,
                    Discount = 0.65M,
                }
            };

            var couponDiscount = coupons.GetTotalCouponDiscount(1);

            Assert.Equal(decimal.One, couponDiscount);
        }

        [Fact]
        public void GetTotalCouponDiscount_2element_tests()
        {
            List<Coupon> coupons = new List<Coupon>
            {
                new Coupon
                {
                    Amount = 2,
                    Discount = 0.8M,
                },
                new Coupon
                {
                    Amount = 3,
                    Discount = 0.9M,
                }
            };

            var couponDiscount = coupons.GetTotalCouponDiscount(4);

            Assert.Equal(0.8M * 0.9M, couponDiscount);
        }
    }
}