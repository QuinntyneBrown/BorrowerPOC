using Microsoft.Practices.Unity;

namespace DH.Lending.Borrower.Business.Model
{
    internal interface IDHBusinessScope
    {
        IUnityContainer Scope { get; set; }
    }
}
