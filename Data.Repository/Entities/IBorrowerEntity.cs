using System;

namespace DH.Lending.Borrower.Data.Repository.Entities
{
    public interface IBorrowerEntity
    {
        Guid Id { get; }
        int Position { get; set; }
        bool EdisclosureConsent { get; set; }
        bool EmailConsent { get; set; }
        string EmailAddress { get; set; }

        IProfileEntity Profile { get; }
    }
}
