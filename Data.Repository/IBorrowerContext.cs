using DH.Lending.Borrower.Data.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DH.Lending.Borrower.Data.Repository
{
    public interface IBorrowerContext
        : IDisposable
    {
        IBorrowerEntity Create(Guid id);
        IBorrowerEntity Get(Guid id);
        Task<IBorrowerEntity> GetAsync(Guid id);
        IEnumerable<IBorrowerEntity> GetForPartner(Guid partnerId, int pageSize, int pageNumber);
        Task<IEnumerable<IBorrowerEntity>> GetForPartnerAsync(Guid partnerId, int pageSize, int pageNumber);
        IEnumerable<IBorrowerEntity> GetForCobrander(Guid cobranderId, int pageSize, int pageNumber);
        Task<IEnumerable<IBorrowerEntity>> GetForCobranderAsync(Guid cobranderId, int pageSize, int pageNumber);
        IEnumerable<IBorrowerEntity> GetForSiteProfile(Guid siteProfileId, int pageSize, int pageNumber);
        Task<IEnumerable<IBorrowerEntity>> GetForSiteProfileAsync(Guid siteProfileId, int pageSize, int pageNumber);
        IEnumerable<IBorrowerEntity> GetForAccount(Guid accountId);
        Task<IEnumerable<IBorrowerEntity>> GetForAccountAsync(Guid accountId);
        void Insert(IBorrowerEntity borrower, Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId);
        Task InsertAsync(IBorrowerEntity borrower, Guid partnerId, Guid cobranderId, Guid siteProfileId, Guid accountId);
        void Update(IBorrowerEntity borrower);
        Task UpdateAsync(IBorrowerEntity borrower);
        void Delete(Guid borrowerId);
        Task DeleteAsync(Guid borrowerId);
    }
}
