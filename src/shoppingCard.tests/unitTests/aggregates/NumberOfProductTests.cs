using shoppingCard.documents.entities;
using shoppingCard.documents.interfaces.aggregates;
using System.Collections.Generic;
using Xunit;

namespace shoppingCard.tests.unitTests.aggregates
{
    public class NumberOfProductTests : AbstractTests
    {
        [Fact]
        public void Calculate_tests()
        {
            INumberOfProduct numberOfProduct = Resolve<INumberOfProduct>();

            var cart = new Cart
            {
                ProductTransactions = new List<ProductTransaction>
                {
                    new ProductTransaction(),
                    new ProductTransaction(),
                    new ProductTransaction(),
                },
            };

            var productCount = numberOfProduct.Calculate(cart);

            Assert.Equal(3, productCount);
        }

    }
}
