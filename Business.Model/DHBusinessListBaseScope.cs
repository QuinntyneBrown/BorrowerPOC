using Microsoft.Practices.Unity;
using System;

namespace DH.Lending.Borrower.Business.Model
{
    [Serializable]
    internal abstract class DHBusinessListBaseScope<T, C>
        : DHBusinessListBase<T, C>, IDHBusinessScope
        where T : DHBusinessListBase<T, C>
        where C : DHBusinessBaseScope<C>
    {
        [NonSerialized]
        private IUnityContainer _unityContainer;

        [Dependency]
        IUnityContainer IDHBusinessScope.Scope
        {
            get { return _unityContainer; }
            set { _unityContainer = value; }
        }
    }
}
