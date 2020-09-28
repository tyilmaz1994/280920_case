using shoppingCard.documents.interfaces.aggregates;
using Xunit;

namespace shoppingCard.tests.unitTests.aggregates
{
    public class CartTotalPriceAggregateTests : AbstractTests
    {
        [Fact]
        public void Calculate_tests()
        {
            ICartTotalPriceAggregate cartTotalPriceAggregate = Resolve<ICartTotalPriceAggregate>();

            var cartTotalPrice = cartTotalPriceAggregate.Calculate(EmptyCardData());

            Assert.Equal(250.43M, cartTotalPrice);
        }
    }
}
