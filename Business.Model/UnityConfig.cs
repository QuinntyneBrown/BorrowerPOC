using Csla;
using DH.Lending.Borrower.Business.Repository;
using Microsoft.Practices.Unity;

namespace DH.Lending.Borrower.Business.Model
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            // Register the CSLA Factory classes.
            container.RegisterType(typeof(IObjectFactory<>), typeof(ObjectFactory<>), new PerResolveLifetimeManager());

            // Setup the CSLA Activator
            ApplicationContext.DataPortalActivator = new ObjectActivator(container);
        }
    }
}
