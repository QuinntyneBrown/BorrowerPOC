using System;

namespace DH.Lending.Borrower.Data.Repository.Entities
{
    public interface IProfileEntity
    {
        Guid PartnerId { get; set; }
        Guid CobranderId { get; set; }
        Guid SiteProfileId { get; set; }
        Guid AccountId { get; set; }
        Guid BorrowerId { get; set; }
    }
}
