using System;

namespace DH.Lending.Borrower.Business.Repository
{
    public interface IBorrower
        : IDHBusinessBase
    {
        Guid Id { get; }
        int Position { get; set; }
        bool EDisclosureConsent { get; set; }
        bool EmailConsent { get; set; }
        string EmailAddress { get; set; }

        Guid PartnerId { get; }
        Guid CobranderId { get; }
        Guid SiteProfileId { get; }
        Guid AccountId { get; }
    }
}
