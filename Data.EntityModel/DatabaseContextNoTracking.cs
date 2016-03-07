using Microsoft.Data.Entity;
using System.Linq;

namespace DH.Lending.Borrower.Data.EntityModel
{
    public partial class DatabaseContextNoTracking
    {
        public DatabaseContextNoTracking(DatabaseContext context)
        {
            Context = context;
        }

        public DatabaseContext Context { get; }

        public virtual IQueryable<Borrower> Borrower => Context.Borrower.AsNoTracking();
        public virtual IQueryable<Profile> Profile => Context.Profile.AsNoTracking();
    }
}
