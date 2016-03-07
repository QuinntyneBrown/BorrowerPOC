using DH.Lending.Borrower.Data.EntityModel;
using DH.Lending.Borrower.Data.Repository.Entities;
using System;

namespace DH.Lending.Borrower.Data.DataAccess.Entities
{
    internal class ProfileEntity
        : BaseEntity<ProfileEntity, Profile>,
        IProfileEntity
    {
        public ProfileEntity()
            : base(null)
        {
        }

        internal ProfileEntity(Profile profile)
            : base(profile)
        {
            Entity = profile;
        }

        public Guid PartnerId
        {
            get { return Entity.PartnerId; }
            set { Entity.PartnerId = value; }
        }

        public Guid CobranderId
        {
            get { return Entity.CobranderId; }
            set { Entity.CobranderId = value; }
        }

        public Guid SiteProfileId
        {
            get { return Entity.SiteProfileId; }
            set { Entity.SiteProfileId = value; }
        }

        public Guid AccountId
        {
            get { return Entity.AccountId; }
            set { Entity.AccountId = value; }
        }

        public Guid BorrowerId
        {
            get { return Entity.BorrowerId; }
            set { Entity.BorrowerId = value; }
        }
    }
}
