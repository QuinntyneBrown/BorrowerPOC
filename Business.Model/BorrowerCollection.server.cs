using DH.Lending.Borrower.Business.Repository;
using DH.Lending.Borrower.Data.Repository;
using DH.Lending.Borrower.Data.Repository.Entities;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DH.Lending.Borrower.Business.Model
{
    internal partial class BorrowerCollection
    {
        private static readonly IDictionary<BorrowerCollectionCriteria.IdType, Func<BorrowerCollectionCriteria, IBorrowerContext, Task<IEnumerable<IBorrowerEntity>>>> _FetchFactory =
            new Dictionary<BorrowerCollectionCriteria.IdType, Func<BorrowerCollectionCriteria, IBorrowerContext, Task<IEnumerable<IBorrowerEntity>>>>
            {
                { BorrowerCollectionCriteria.IdType.Partner, (crit, con) => con.GetForPartnerAsync(crit.QueryId, crit.PageSize, crit.PageNumber) },
                { BorrowerCollectionCriteria.IdType.Cobrander, (crit, con) => con.GetForCobranderAsync(crit.QueryId, crit.PageSize, crit.PageNumber) },
                { BorrowerCollectionCriteria.IdType.SiteProfile, (crit, con) => con.GetForSiteProfileAsync(crit.QueryId, crit.PageSize, crit.PageNumber) },
                { BorrowerCollectionCriteria.IdType.Account, (crit, con) => con.GetForAccountAsync(crit.QueryId) },
            };

        private async Task DataPortal_Fetch(BorrowerCollectionCriteria criteria)
        {
            Func<BorrowerCollectionCriteria, IBorrowerContext, Task<IEnumerable<IBorrowerEntity>>> fetcher;

            if (!_FetchFactory.TryGetValue(criteria.QueryIdType, out fetcher))
            {
                throw new ApplicationException("Invalid Fetch Criteria");
            }

            var borrowers = await fetcher(criteria, BorrowerContext);

            await LoadModel(borrowers);
        }

        private async Task LoadModel(IEnumerable<IBorrowerEntity> entities)
        {
            RaiseListChangedEvents = false;

            var factory = new ObjectFactory<Borrower>();

            foreach (IBorrowerEntity entity in entities)
            {
                var borrower = await factory.FetchAsync(entity);
                Add(borrower);
            }

            RaiseListChangedEvents = true;
        }

        #region Data Context

        [NonSerialized]
        private IBorrowerContext _borrowerContext;

        [Dependency]
        internal IBorrowerContext BorrowerContext
        {
            private get { return _borrowerContext; }
            set { _borrowerContext = value; }
        }

        #endregion
    }
}
