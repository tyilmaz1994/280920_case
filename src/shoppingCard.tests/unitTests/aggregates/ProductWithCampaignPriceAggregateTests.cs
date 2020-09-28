using shoppingCard.documents.entities;
using shoppingCard.documents.enums;
using shoppingCard.documents.interfaces.aggregates;
using System.Collections.Generic;
using Xunit;

namespace shoppingCard.tests.unitTests.aggregates
{
    public class ProductWithCampaignPriceAggregateTests : AbstractTests
    {
        [Theory]
        [InlineData(1, 2, 0.9, 1.8)]
        [InlineData(1.55, 2, 0.5, 1.55)]
        [InlineData(1, 1, 0.71, 0.71)]
        public void Calculate_rate_campaign_tests(decimal applePrice, decimal quantity, decimal discountRate, decimal expectedValue)
        {
            IProductWithCampaignPriceAggregate productWithCampaignPriceAggregate = Resolve<IProductWithCampaignPriceAggregate>();

            ProductTransaction productTransaction = new ProductTransaction
            {
                Product = new Product
                {
                    Price = applePrice,
                    Title = "Apple",
                    Campaigns = new List<Campaign>
                    {
                        new Campaign
                        {
                            Discount = discountRate,
                            Type = CampaignType.Rate,
                        }
                    },
                },
                Quantity = quantity,
            };

            var actualPrice = productWithCampaignPriceAggregate.Calculate(productTransaction);

            Assert.Equal(expectedValue, actualPrice);
        }

        [Theory]
        [InlineData(1, 2, 0.1, 1.9)]
        [InlineData(1.55, 2, 0.2, 2.9)]
        [InlineData(1, 1, 0.3, 0.7)]
        public void Calculate_price_campaign_tests(decimal applePrice, decimal quantity, decimal discountRate, decimal expectedValue)
        {
            IProductWithCampaignPriceAggregate productWithCampaignPriceAggregate = Resolve<IProductWithCampaignPriceAggregate>();

            ProductTransaction productTransaction = new ProductTransaction
            {
                Product = new Product
                {
                    Price = applePrice,
                    Title = "Apple",
                    Campaigns = new List<Campaign>
                    {
                        new Campaign
                        {
                            Discount = discountRate,
                            Type = CampaignType.Price,
                        }
                    },
                },
                Quantity = quantity,
            };

            var actualPrice = productWithCampaignPriceAggregate.Calculate(productTransaction);

            Assert.Equal(expectedValue, actualPrice);
        }

        [Theory]
        [InlineData(1, 2, 0.9, 0.1, 1.7)]
        [InlineData(1.55, 2, 0.5, 0.2, 1.35)]
        [InlineData(1, 1, 0.71, 0.3, 0.41)]
        public void Calculate_rate_and_price_campaign_tests(decimal applePrice, decimal quantity, decimal discountRate, decimal discountPrice, decimal expectedValue)
        {
            IProductWithCampaignPriceAggregate productWithCampaignPriceAggregate = Resolve<IProductWithCampaignPriceAggregate>();

            ProductTransaction productTransaction = new ProductTransaction
            {
                Product = new Product
                {
                    Price = applePrice,
                    Title = "Apple",
                    Campaigns = new List<Campaign>
                    {
                        new Campaign
                        {
                            Discount = discountRate,
                            Type = CampaignType.Rate,
                        },
                        new Campaign
                        {
                            Discount = discountPrice,
                            Type = CampaignType.Price,
                        },

                    },
                },
                Quantity = quantity,
            };

            var actualPrice = productWithCampaignPriceAggregate.Calculate(productTransaction);

            Assert.Equal(expectedValue, actualPrice);
        }

        [Theory]
        [InlineData(1, 2, 0.9, 0.2, 1.62)]
        [InlineData(1.55, 2, 0.5, 0.2, 1.45)]
        [InlineData(1, 1, 0.71, 0.3, 0.497)]
        public void Calculate_parent_category_campaign_tests(decimal applePrice, decimal quantity, decimal discountRate, decimal discountPrice, decimal expectedValue)
        {
            IProductWithCampaignPriceAggregate productWithCampaignPriceAggregate = Resolve<IProductWithCampaignPriceAggregate>();

            ProductTransaction productTransaction = new ProductTransaction
            {
                Product = new Product
                {
                    Price = applePrice,
                    Title = "Apple",
                    Campaigns = new List<Campaign>
                    {
                        new Campaign
                        {
                            Discount = discountRate,
                            Type = CampaignType.Rate,
                        },
                    },
                    Category = new Category
                    {
                        ParentCategory = new Category
                        {
                            Campaigns = new List<Campaign>
                            {
                                new Campaign
                                {
                                    Discount = discountPrice,
                                    Type = CampaignType.Price,
                                },
                            }
                        }
                    }
                },
                Quantity = quantity,
            };

            var actualPrice = productWithCampaignPriceAggregate.Calculate(productTransaction);

            Assert.Equal(expectedValue, actualPrice);
        }
    }
}
