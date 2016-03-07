using Csla;
using DH.Lending.Borrower.Business.Repository;
using System;

namespace DH.Lending.Borrower.Business.Model
{
    [Serializable]
    internal abstract class DHBusinessListBase<T, C>
        : BusinessListBase<T, C>, IDHBusinessListBase<C>
        where T : DHBusinessListBase<T, C>
        where C : DHBusinessBase<C>
    {
    }
}
