using System;

namespace DH.Lending.Borrower.Data.EntityModel
{
    public class Borrower
    {
        public Guid Id { get; set; }
        public int Position { get; set; }
        public bool EdisclosureConsent { get; set; }
        public bool EmailConsent { get; set; }
        public string EmailAddress { get; set; }

        public Profile Profile { get; set; }
    }
}
