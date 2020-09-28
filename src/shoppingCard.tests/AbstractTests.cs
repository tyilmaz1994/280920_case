using shoppingCard.core.container;
using shoppingCard.documents.entities;
using System.Collections.Generic;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace shoppingCard.tests
{
    public abstract class AbstractTests
    {
        public AbstractTests()
        {
            ContainerHelper.Install();
        }

        protected TImplementedInterface Resolve<TImplementedInterface>()
        {
            return ContainerHelper.Resolve<TImplementedInterface>();
        }

        protected Cart EmptyCardData()
        {
            return new Cart
            {
                ProductTransactions = new List<ProductTransaction>
                {
                    new ProductTransaction
                    {
                        Quantity = 2,
                        Product = new Product
                        {
                            Price = 29.99M,
                        }
                    },
                    new ProductTransaction
                    {
                        Quantity = 3,
                        Product = new Product
                        {
                            Price = 30.15M,
                        }
                    },
                    new ProductTransaction
                    {
                        Quantity = 5,
                        Product = new Product
                        {
                            Price = 20M,
                        }
                    },
                },
            };
        }
    }
}
