using DH.Lending.Borrower.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DH.Lending.Borrower.Business.Model
{
    [Serializable]
    internal sealed partial class BorrowerCollection
        : DHBusinessListBaseScope<BorrowerCollection, Borrower>, IBorrowerCollection
    {
        IEnumerator<IBorrower> IEnumerable<IBorrower>.GetEnumerator()
        {
            return this.Cast<IBorrower>().GetEnumerator();
        }
    }
}
