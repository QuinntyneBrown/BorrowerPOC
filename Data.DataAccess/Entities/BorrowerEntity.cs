using DH.Lending.Borrower.Data.Repository.Entities;
using System;

namespace DH.Lending.Borrower.Data.DataAccess.Entities
{
    internal class BorrowerEntity
        : BaseEntity<BorrowerEntity, EntityModel.Borrower>,
        IBorrowerEntity
    {
        public BorrowerEntity()
            : base(null)
        {
        }

        internal BorrowerEntity(EntityModel.Borrower borrower)
            : base(borrower)
        {
        }

        public Guid Id => Entity.Id;

        public int Position
        {
            get
            {
                return Entity.Position;
            }

            set
            {
                Entity.Position = value;
                PropertySet();
            }
        }

        public bool EdisclosureConsent
        {
            get
            {
                return Entity.EdisclosureConsent;
            }

            set
            {
                Entity.EdisclosureConsent = value;
                PropertySet();
            }
        }

        public bool EmailConsent
        {
            get
            {
                return Entity.EmailConsent;
            }

            set
            {
                Entity.EmailConsent = value;
                PropertySet();
            }
        }

        public string EmailAddress
        {
            get
            {
                return Entity.EmailAddress;
            }

            set
            {
                Entity.EmailAddress = value;
                PropertySet();
            }
        }

        private IProfileEntity _profileEntity;

        public IProfileEntity Profile => _profileEntity ?? (_profileEntity = new ProfileEntity(Entity.Profile));
    }
}
