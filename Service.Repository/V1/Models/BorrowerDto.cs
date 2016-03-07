using System;

namespace DH.Lending.Borrower.Service.Repository.V1.Models
{
    public class BorrowerDto
    {
        public Guid PartnerId { get; set; }
        public Guid CobranderId { get; set; }
        public Guid SiteProfileId { get; set; }
        public Guid AccountId { get; set; }
        public Guid Id { get; set; }
        public int Position { get; set; }
        public bool EDisclosureConsent { get; set; }
        public bool EmailConsent { get; set; }
        public string EmailAddress { get; set; }
    }
}
