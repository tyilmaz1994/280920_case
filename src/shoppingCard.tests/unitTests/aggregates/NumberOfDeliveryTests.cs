using shoppingCard.documents.interfaces.aggregates;
using Xunit;

namespace shoppingCard.tests.unitTests.aggregates
{
    public class NumberOfDeliveryTests : AbstractTests
    {
        [Fact]
        public void Calculate_tests()
        {
            INumberOfDelivery numberOfDelivery = Resolve<INumberOfDelivery>();

            var cart = EmptyCardData();

            var productCount = numberOfDelivery.Calculate(cart);

            Assert.Equal(3, productCount);
        }
    }
}
