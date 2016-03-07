using System;
using System.Threading.Tasks;

namespace DH.Lending.Borrower.Data.Repository
{
    public interface IProfileContext
        : IDisposable
    {
        void Insert(Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId, Guid borrowerId);
        void Delete(Guid borrowerId);

        Task InsertAsync(Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId, Guid borrowerId);
        Task DeleteAsync(Guid borrowerId);
    }
}
