using DH.Lending.Borrower.Data.Repository;
using DH.Lending.Borrower.Data.Repository.Entities;
using Microsoft.Practices.Unity;
using System;
using System.Threading.Tasks;

namespace DH.Lending.Borrower.Business.Model
{
    internal partial class Borrower
    {
        private void DataPortal_Create(Tuple<Guid, Guid, Guid, Guid> criteria)
        {
            Guid partnerId = criteria.Item1;
            Guid cobranderId = criteria.Item2;
            Guid siteProfileId = criteria.Item3;
            Guid accountId = criteria.Item4;

            LoadProperty(_ParnterIdProperty, partnerId);
            LoadProperty(_CobranderIdProperty, cobranderId);
            LoadProperty(_SiteProfileIdProperty, siteProfileId);
            LoadProperty(_AccountIdProperty, accountId);
        }

        private async Task DataPortal_Fetch(Guid borrowerId)
        {
            var entity = await BorrowerContext.GetAsync(borrowerId);

            if (entity == null)
                throw new ApplicationException("Borrower record not found.");

            LoadModel(entity);
        }

        private void DataPortal_Fetch(IBorrowerEntity entity)
        {
            LoadModel(entity);
        }

        private new async Task DataPortal_Insert()
        {
            var entity = BorrowerContext.Create(Guid.Empty);

            LoadEntity(entity);

            await BorrowerContext.InsertAsync(entity,
                ReadProperty(_ParnterIdProperty),
                ReadProperty(_CobranderIdProperty),
                ReadProperty(_SiteProfileIdProperty),
                ReadProperty(_AccountIdProperty));

            LoadProperty(_IdProperty, entity.Id);
        }

        private new async Task DataPortal_Update()
        {
            var entity = BorrowerContext.Create(ReadProperty(_IdProperty));

            LoadEntity(entity);

            await BorrowerContext.UpdateAsync(entity);
        }

        private async Task DataPortal_Delete(Guid id)
        {
            await BorrowerContext.DeleteAsync(id);
        }

        private void LoadEntity(IBorrowerEntity entity)
        {
            SetEntityProperty(entity, e => e.Position, _PositionProperty);
            SetEntityProperty(entity, e => e.EdisclosureConsent, _EDisclosureConsentProperty);
            SetEntityProperty(entity, e => e.EmailConsent, _EmailConsentProperty);
            SetEntityProperty(entity, e => e.EmailAddress, _EmailAddressProperty);
        }

        private void LoadModel(IBorrowerEntity entity)
        {
            LoadProperty(_IdProperty, entity.Id);
            LoadProperty(_PositionProperty, entity.Position);
            LoadProperty(_EDisclosureConsentProperty, entity.EdisclosureConsent);
            LoadProperty(_EmailConsentProperty, entity.EmailConsent);
            LoadProperty(_EmailAddressProperty, entity.EmailAddress);
            LoadProperty(_ParnterIdProperty, entity.Profile.PartnerId);
            LoadProperty(_CobranderIdProperty, entity.Profile.CobranderId);
            LoadProperty(_SiteProfileIdProperty, entity.Profile.SiteProfileId);
            LoadProperty(_AccountIdProperty, entity.Profile.AccountId);
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
