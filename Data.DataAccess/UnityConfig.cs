using DH.Lending.Borrower.Data.Repository;
using Microsoft.Practices.Unity;

namespace DH.Lending.Borrower.Data.DataAccess
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            // Register the Data Context classes.
            container.RegisterType<IBorrowerContext, BorrowerContext>();
            container.RegisterType<IProfileContext, BorrowerContext>();
        }
    }
}
