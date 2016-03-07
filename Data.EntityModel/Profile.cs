using System;

namespace DH.Lending.Borrower.Data.EntityModel
{
    public class Profile
    {
        public Guid PartnerId { get; set; }
        public Guid CobranderId { get; set; }
        public Guid SiteProfileId { get; set; }
        public Guid AccountId { get; set; }
        public Guid BorrowerId { get; set; }

        public Borrower Borrower { get; set; }
    }
}
