using Csla;
using DH.Lending.Borrower.Business.Repository;
using System;
using DH.Lending.Borrower.Data.Repository;

namespace DH.Lending.Borrower.Business.Model
{
    [Serializable]
    internal sealed partial class Borrower
        : DHBusinessBaseScope<Borrower>, IBorrower
    {
        private static readonly PropertyInfo<Guid> _IdProperty = PropertyInfoRegistration.Register<Borrower, Guid>(p => p.Id);
        public Guid Id => GetProperty(_IdProperty);

        private static readonly PropertyInfo<int> _PositionProperty = PropertyInfoRegistration.Register<Borrower, int>(p => p.Position);
        public int Position
        {
            get { return GetProperty(_PositionProperty); }
            set { SetProperty(_PositionProperty, value); }
        }

        private static readonly PropertyInfo<bool> _EDisclosureConsentProperty = PropertyInfoRegistration.Register<Borrower, bool>(p => p.EDisclosureConsent);
        public bool EDisclosureConsent
        {
            get { return GetProperty(_EDisclosureConsentProperty); }
            set { SetProperty(_EDisclosureConsentProperty, value); }
        }

        private static readonly PropertyInfo<bool> _EmailConsentProperty = PropertyInfoRegistration.Register<Borrower, bool>(p => p.EmailConsent);
        public bool EmailConsent
        {
            get { return GetProperty(_EmailConsentProperty); }
            set { SetProperty(_EmailConsentProperty, value); }
        }

        private static readonly PropertyInfo<string> _EmailAddressProperty = PropertyInfoRegistration.Register<Borrower, string>(p => p.EmailAddress);
        public string EmailAddress
        {
            get { return GetProperty(_EmailAddressProperty); }
            set { SetProperty(_EmailAddressProperty, value); }
        }

        private static readonly PropertyInfo<Guid> _ParnterIdProperty = PropertyInfoRegistration.Register<Borrower, Guid>(p => p.PartnerId);
        public Guid PartnerId => GetProperty(_ParnterIdProperty);

        private static readonly PropertyInfo<Guid> _CobranderIdProperty = PropertyInfoRegistration.Register<Borrower, Guid>(p => p.CobranderId);
        public Guid CobranderId => GetProperty(_CobranderIdProperty);

        private static readonly PropertyInfo<Guid> _SiteProfileIdProperty = PropertyInfoRegistration.Register<Borrower, Guid>(p => p.SiteProfileId);
        public Guid SiteProfileId => GetProperty(_SiteProfileIdProperty);

        private static readonly PropertyInfo<Guid> _AccountIdProperty = PropertyInfoRegistration.Register<Borrower, Guid>(p => p.AccountId);
        public Guid AccountId => GetProperty(_AccountIdProperty);
    }
}
