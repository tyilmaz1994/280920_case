using shoppingCard.documents.interfaces.aggregates;
using Xunit;

namespace shoppingCard.tests.unitTests.aggregates
{
    public class DeliveryCostAggregateTests : AbstractTests
    {
        [Fact]
        public void Calculate_tests()
        {
            IDeliveryCostAggregate deliveryCostAggregate = Resolve<IDeliveryCostAggregate>();

            Assert.Equal(11, deliveryCostAggregate.Calculate(EmptyCardData()));
        }
    }
}
