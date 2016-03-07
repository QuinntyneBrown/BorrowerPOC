using DH.Lending.Borrower.Data.EntityModel;
using DH.Lending.Borrower.Data.Repository;
using System;
using System.Threading.Tasks;

namespace DH.Lending.Borrower.Data.DataAccess
{
    public class ProfileContext : IProfileContext
    {
        public ProfileContext()
        {
            Context = new DatabaseContext(ModelSettings.BorrowerConnectionString);
        }

        private DatabaseContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Insert(Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId, Guid borrowerId)
        {
            InsertInternal(partnerId, cobranderId, siteProfileId, accountId, borrowerId);

            Context.SaveChanges();
        }

        public async Task InsertAsync(Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId, Guid borrowerId)
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

        public void Delete(Guid borrowerId)
        {
            DeleteInternal(borrowerId);

            Context.SaveChanges();
        }

        public async Task DeleteAsync(Guid borrowerId)
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
    }
}
