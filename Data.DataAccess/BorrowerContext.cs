using DH.Lending.Borrower.Data.DataAccess.Entities;
using DH.Lending.Borrower.Data.EntityModel;
using DH.Lending.Borrower.Data.Repository;
using DH.Lending.Borrower.Data.Repository.Entities;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DH.Lending.Borrower.Data.DataAccess
{

    internal class BorrowerContext : IBorrowerContext, IProfileContext
    {
        public BorrowerContext()
        {
            Context = new DatabaseContext(ModelSettings.BorrowerConnectionString);
            NoTracking = new DatabaseContextNoTracking(Context);
        }

        private DatabaseContext Context { get; }
        private DatabaseContextNoTracking NoTracking { get; }

        public void Dispose()
        {
            Context.Dispose();
        }


        #region Implementation for IBorrowerContext

        IBorrowerEntity IBorrowerContext.Create(Guid id)
        {
            var entity = new EntityModel.Borrower
            {
                Id = id
            };

            return new BorrowerEntity(entity);
        }

        IBorrowerEntity IBorrowerContext.Get(Guid id)
        {
            var borrower = Context.Borrower
                .Include(p => p.Profile)
                .FirstOrDefault(b => b.Id == id);

            return borrower == null ? null : new BorrowerEntity(borrower);

        }

        async Task<IBorrowerEntity> IBorrowerContext.GetAsync(Guid id)
        {
            var borrower = await Context.Borrower
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(b => b.Id == id);

            return borrower == null ? null : new BorrowerEntity(borrower);
        }

        IEnumerable<IBorrowerEntity> IBorrowerContext.GetForPartner(Guid partnerId, int pageSize, int pageNumber)
        {
            return NoTracking.Borrower
                .Include(b => b.Profile)
                .Where(b => b.Profile.PartnerId == partnerId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList()
                .Select(b => new BorrowerEntity(b))
                .ToList();
        }

        async Task<IEnumerable<IBorrowerEntity>> IBorrowerContext.GetForPartnerAsync(Guid partnerId, int pageSize, int pageNumber)
        {
            var borrowers = await NoTracking.Borrower
                .Include(b => b.Profile)
                .Where(b => b.Profile.PartnerId == partnerId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return borrowers
                .Select(b => new BorrowerEntity(b))
                .ToList();
        }

        IEnumerable<IBorrowerEntity> IBorrowerContext.GetForCobrander(Guid cobranderId, int pageSize, int pageNumber)
        {
            return NoTracking.Borrower
                .Include(b => b.Profile)
                .Where(b => b.Profile.CobranderId == cobranderId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList()
                .Select(b => new BorrowerEntity(b))
                .ToList();
        }

        async Task<IEnumerable<IBorrowerEntity>> IBorrowerContext.GetForCobranderAsync(Guid cobranderId, int pageSize, int pageNumber)
        {
            var borrowers = await NoTracking.Borrower
                .Include(b => b.Profile)
                .Where(b => b.Profile.CobranderId == cobranderId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return borrowers
                .Select(b => new BorrowerEntity(b))
                .ToList();
        }

        IEnumerable<IBorrowerEntity> IBorrowerContext.GetForSiteProfile(Guid siteProfileId, int pageSize, int pageNumber)
        {
            return NoTracking.Borrower
                .Include(b => b.Profile)
                .Where(b => b.Profile.SiteProfileId == siteProfileId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList()
                .Select(b => new BorrowerEntity(b))
                .ToList();
        }

        async Task<IEnumerable<IBorrowerEntity>> IBorrowerContext.GetForSiteProfileAsync(Guid siteProfileId, int pageSize, int pageNumber)
        {
            var borrowers = await NoTracking.Borrower
                .Include(b => b.Profile)
                .Where(b => b.Profile.SiteProfileId == siteProfileId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return borrowers
                .Select(b => new BorrowerEntity(b))
                .ToList();
        }

        IEnumerable<IBorrowerEntity> IBorrowerContext.GetForAccount(Guid accountId)
        {
            return NoTracking.Borrower
                .Include(b => b.Profile)
                .Where(b => b.Profile.AccountId == accountId)
                .ToList()
                .Select(b => new BorrowerEntity(b))
                .ToList();
        }

        async Task<IEnumerable<IBorrowerEntity>> IBorrowerContext.GetForAccountAsync(Guid accountId)
        {
            var borrowers = await NoTracking.Borrower
                .Include(b => b.Profile)
                .Where(b => b.Profile.AccountId == accountId)
                .ToListAsync();

            return borrowers
                .Select(b => new BorrowerEntity(b))
                .ToList();
        }

        void IBorrowerContext.Insert(IBorrowerEntity borrower, Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId)
        {
            var entity = borrower as BorrowerEntity;

            if (entity == null)
                throw new InvalidCastException("IBorrowerEntity is not of type BorrowerEntity");

            var borrowerEntity = entity.Entity;

            Context.Borrower.Add(borrowerEntity);

            Context.SaveChanges();

            (this as IProfileContext).Insert(partnerId, cobranderId, siteProfileId, accountId, borrower.Id);
        }

        async Task IBorrowerContext.InsertAsync(IBorrowerEntity borrower, Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId)
        {
            var entity = borrower as BorrowerEntity;

            if (entity == null)
                throw new InvalidCastException("IBorrowerEntity is not of type BorrowerEntity");

            var borrowerEntity = entity.Entity;

            Context.Borrower.Add(borrowerEntity);

            await Context.SaveChangesAsync();

            await (this as IProfileContext).InsertAsync(partnerId, cobranderId, siteProfileId, accountId, borrower.Id);
        }

        void IBorrowerContext.Update(IBorrowerEntity borrower)
        {
            var entity = borrower as BorrowerEntity;

            if (entity == null)
                throw new InvalidCastException("IBorrowerEntity is not of type BorrowerEntity");

            var borrowerEntity = new EntityModel.Borrower
            {
                Id = borrower.Id
            };

            Context.Borrower.Attach(borrowerEntity);

            borrowerEntity.UpdateChanged(entity, Context, db => db.Position, e => e.Position);
            borrowerEntity.UpdateChanged(entity, Context, db => db.EdisclosureConsent, e => e.EdisclosureConsent);
            borrowerEntity.UpdateChanged(entity, Context, db => db.EmailConsent, e => e.EmailConsent);
            borrowerEntity.UpdateChanged(entity, Context, db => db.EmailAddress, e => e.EmailAddress);

            Context.SaveChanges();
        }

        async Task IBorrowerContext.UpdateAsync(IBorrowerEntity borrower)
        {
            var entity = borrower as BorrowerEntity;

            if (entity == null)
                throw new InvalidCastException("IBorrowerEntity is not of type BorrowerEntity");

            var borrowerEntity = new EntityModel.Borrower
            {
                Id = borrower.Id
            };

            Context.Borrower.Attach(borrowerEntity);

            borrowerEntity.UpdateChanged(entity, Context, db => db.Position, e => e.Position);
            borrowerEntity.UpdateChanged(entity, Context, db => db.EdisclosureConsent, e => e.EdisclosureConsent);
            borrowerEntity.UpdateChanged(entity, Context, db => db.EmailConsent, e => e.EmailConsent);
            borrowerEntity.UpdateChanged(entity, Context, db => db.EmailAddress, e => e.EmailAddress);

            await Context.SaveChangesAsync();
        }

        void IBorrowerContext.Delete(Guid borrowerId)
        {
            var borrower = new EntityModel.Borrower
            {
                Id = borrowerId
            };

            Context.Borrower.Attach(borrower);
            Context.Borrower.Remove(borrower);

            Context.SaveChanges();

            (this as IProfileContext).Delete(borrowerId);
        }

        async Task IBorrowerContext.DeleteAsync(Guid borrowerId)
        {
            await (this as IProfileContext).DeleteAsync(borrowerId);

            var borrower = new EntityModel.Borrower
            {
                Id = borrowerId
            };

            Context.Borrower.Attach(borrower);
            Context.Borrower.Remove(borrower);

            await Context.SaveChangesAsync();
        }

        #endregion

        #region Implementation for IProfileContext

        void IProfileContext.Insert(Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId, Guid borrowerId)
        {
            InsertInternal(partnerId, cobranderId, siteProfileId, accountId, borrowerId);

            Context.SaveChanges();
        }

        async Task IProfileContext.InsertAsync(Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId, Guid borrowerId)
        {
            InsertInternal(partnerId, cobranderId, siteProfileId, accountId, borrowerId);

            await Context.SaveChangesAsync();
        }

        private void InsertInternal(Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId, Guid borrowerId)
        {
            var profile = new Profile
            {
                PartnerId = partnerId,
                CobranderId = cobranderId,
                SiteProfileId = siteProfileId,
                AccountId = accountId,
                BorrowerId = borrowerId
            };

            Context.Profile.Add(profile);
        }

        void IProfileContext.Delete(Guid borrowerId)
        {
            DeleteInternal(borrowerId);

            Context.SaveChanges();
        }

        async Task IProfileContext.DeleteAsync(Guid borrowerId)
        {
            DeleteInternal(borrowerId);

            await Context.SaveChangesAsync();
        }

        private void DeleteInternal(Guid borrowerId)
        {
            var profile = new Profile
            {
                BorrowerId = borrowerId
            };

            Context.Profile.Attach(profile);
            Context.Profile.Remove(profile);
        }
        #endregion
    }
}
