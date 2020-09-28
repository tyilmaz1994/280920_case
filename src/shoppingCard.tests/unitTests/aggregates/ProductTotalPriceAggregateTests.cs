using shoppingCard.documents.entities;
using shoppingCard.documents.interfaces.aggregates;
using Xunit;

namespace shoppingCard.tests.unitTests.aggregates
{
    public class ProductTotalPriceAggregateTests : AbstractTests
    {
        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(1.55, 2, 3.10)]
        [InlineData(1, 1, 1)]
        public void Calculate_tests(decimal applePrice, decimal quantity, decimal expectedValue)
        {
            IProductTotalPriceAggregate productTotalPriceAggregate = Resolve<IProductTotalPriceAggregate>();

            ProductTransaction productTransaction = new ProductTransaction
            {
                Product = new Product
                {
                    Price = applePrice,
                    Title = "Apple",
                },
                Quantity = quantity,
            };

            var actualPrice = productTotalPriceAggregate.Calculate(productTransaction);

            Assert.Equal(expectedValue, actualPrice);
        }
    }
}
