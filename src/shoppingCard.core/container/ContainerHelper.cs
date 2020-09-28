using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using shoppingCard.core.aggregates;
using shoppingCard.core.aggregates.priceCalculation;
using shoppingCard.documents.interfaces.aggregates;

namespace shoppingCard.core.container
{
    public class ContainerHelper
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer Install()
        {
            IWindsorInstaller[] windsorInstallers = new IWindsorInstaller[]
            {
                new AggregateInstaller()
            };

            _container = new WindsorContainer().AddFacility<TypedFactoryFacility>();

            return _container.Install(windsorInstallers);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public class AggregateInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer windsorContainer, IConfigurationStore configurationStore)
            {
                windsorContainer.Register(Component.For<IProductTotalPriceAggregate>()
                    .ImplementedBy<ProductTotalPriceAggregate>()
                    .LifeStyle.Singleton);
                windsorContainer.Register(Component.For<IProductWithCampaignPriceAggregate>()
                    .ImplementedBy<ProductWithCampaignPriceAggregate>()
                    .LifeStyle.Singleton);
                windsorContainer.Register(Component.For<INumberOfProduct>()
                    .ImplementedBy<NumberOfProduct>()
                    .LifeStyle.Singleton);
                windsorContainer.Register(Component.For<INumberOfDelivery>()
                    .ImplementedBy<NumberOfDelivery>()
                    .LifeStyle.Singleton);
                windsorContainer.Register(Component.For<IDeliveryCostAggregate>()
                    .ImplementedBy<DeliveryCostAggregate>()
                    .LifeStyle.Singleton);
                windsorContainer.Register(Component.For<ICartWithCouponPriceAggregate>()
                    .ImplementedBy<CartWithCouponPriceAggregate>()
                    .LifeStyle.Singleton);
                windsorContainer.Register(Component.For<ICartTotalPriceAggregate>()
                    .ImplementedBy<CartTotalPriceAggregate>()
                    .LifeStyle.Singleton);
            }
        }
    }
}
