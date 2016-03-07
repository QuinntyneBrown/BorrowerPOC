using Microsoft.Practices.Unity;
using ImpV1 = DH.Lending.Borrower.Service.Logic.V1;
using RepV1 = DH.Lending.Borrower.Service.Repository.V1;

namespace DH.Lending.Borrower.Service.Logic
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            // Register the Service Logic classes.
            container.RegisterType<RepV1.IBorrowerService, ImpV1.BorrowerService>(new TransientLifetimeManager());
        }
    }
}
