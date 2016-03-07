using Microsoft.Practices.Unity;
using System;

namespace DH.Lending.Borrower.Business.Model
{
    [Serializable]
    internal abstract class DHBusinessBaseScope<T>
        : DHBusinessBase<T>, IDHBusinessScope
        where T : DHBusinessBase<T>
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
