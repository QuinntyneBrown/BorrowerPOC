using DH.Lending.Borrower.Service.Repository.V1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DH.Lending.Borrower.Service.Repository.V1
{
    public interface IBorrowerService
    {
        Task<IEnumerable<BorrowerDto>> GetByPartnerId(Guid partnerId, int pageSize, int pageNumber);
        Task<IEnumerable<BorrowerDto>> GetByCobranderId(Guid cobranderId, int pageSize, int pageNumber);
        Task<IEnumerable<BorrowerDto>> GetBySiteProfileId(Guid siteProfileId, int pageSize, int pageNumber);
        Task<IEnumerable<BorrowerDto>> GetByAccountId(Guid accountId);
        Task<BorrowerDto> Get(Guid borrowerId);
        Task<BorrowerDto> Insert(BorrowerDto borrower);
        Task<BorrowerDto> Update(BorrowerDto borrower);
        Task Delete(Guid borrowerId);
    }
}
