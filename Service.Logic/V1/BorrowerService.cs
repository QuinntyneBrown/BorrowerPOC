using DH.Lending.Borrower.Business.Repository;
using DH.Lending.Borrower.Service.Repository.V1;
using DH.Lending.Borrower.Service.Repository.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DH.Lending.Borrower.Service.Logic.V1
{
    internal class BorrowerService : IBorrowerService
    {
        public BorrowerService(IObjectFactory<IBorrowerCollection> borrowerCollectionFactory, IObjectFactory<IBorrower> borrowerFactory)
        {
            BorrowerCollectionFactory = borrowerCollectionFactory;
            BorrowerFactory = borrowerFactory;
        }

        private IObjectFactory<IBorrowerCollection> BorrowerCollectionFactory { get; }
        private IObjectFactory<IBorrower> BorrowerFactory { get; }

        public async Task<IEnumerable<BorrowerDto>> GetByPartnerId(Guid partnerId, int pageSize, int pageNumber)
        {
            var borrowers = await BorrowerCollectionFactory.FetchAsync(new BorrowerCollectionCriteria
            {
                QueryId = partnerId,
                QueryIdType = BorrowerCollectionCriteria.IdType.Partner,
                PageSize = pageSize,
                PageNumber = pageNumber
            });

            return borrowers.Select(b => new BorrowerDto
            {
                PartnerId = b.PartnerId,
                CobranderId = b.CobranderId,
                SiteProfileId = b.SiteProfileId,
                AccountId = b.AccountId,
                Id = b.Id,
                Position = b.Position,
                EDisclosureConsent = b.EDisclosureConsent,
                EmailConsent = b.EmailConsent,
                EmailAddress = b.EmailAddress
            })
                .ToList();
        }

        public async Task<IEnumerable<BorrowerDto>> GetByCobranderId(Guid cobranderId, int pageSize, int pageNumber)
        {
            var borrowers = await BorrowerCollectionFactory.FetchAsync(new BorrowerCollectionCriteria
            {
                QueryId = cobranderId,
                QueryIdType = BorrowerCollectionCriteria.IdType.Cobrander,
                PageSize = pageSize,
                PageNumber = pageNumber
            });

            return borrowers.Select(b => new BorrowerDto
            {
                PartnerId = b.PartnerId,
                CobranderId = b.CobranderId,
                SiteProfileId = b.SiteProfileId,
                AccountId = b.AccountId,
                Id = b.Id,
                Position = b.Position,
                EDisclosureConsent = b.EDisclosureConsent,
                EmailConsent = b.EmailConsent,
                EmailAddress = b.EmailAddress
            })
                .ToList();
        }

        public async Task<IEnumerable<BorrowerDto>> GetBySiteProfileId(Guid siteProfileId, int pageSize, int pageNumber)
        {
            var borrowers = await BorrowerCollectionFactory.FetchAsync(new BorrowerCollectionCriteria
            {
                QueryId = siteProfileId,
                QueryIdType = BorrowerCollectionCriteria.IdType.SiteProfile,
                PageSize = pageSize,
                PageNumber = pageNumber
            });

            return borrowers.Select(b => new BorrowerDto
            {
                PartnerId = b.PartnerId,
                CobranderId = b.CobranderId,
                SiteProfileId = b.SiteProfileId,
                AccountId = b.AccountId,
                Id = b.Id,
                Position = b.Position,
                EDisclosureConsent = b.EDisclosureConsent,
                EmailConsent = b.EmailConsent,
                EmailAddress = b.EmailAddress
            })
                .ToList();
        }

        public async Task<IEnumerable<BorrowerDto>> GetByAccountId(Guid accountId)
        {
            var borrowers = await BorrowerCollectionFactory.FetchAsync(new BorrowerCollectionCriteria
            {
                QueryId = accountId,
                QueryIdType = BorrowerCollectionCriteria.IdType.Account,
            });

            return borrowers.Select(b => new BorrowerDto
            {
                PartnerId = b.PartnerId,
                CobranderId = b.CobranderId,
                SiteProfileId = b.SiteProfileId,
                AccountId = b.AccountId,
                Id = b.Id,
                Position = b.Position,
                EDisclosureConsent = b.EDisclosureConsent,
                EmailConsent = b.EmailConsent,
                EmailAddress = b.EmailAddress
            })
                .ToList();
        }

        public async Task<BorrowerDto> Get(Guid borrowerId)
        {
            var borrower = await BorrowerFactory.FetchAsync(borrowerId);

            return new BorrowerDto
            {
                PartnerId = borrower.PartnerId,
                CobranderId = borrower.CobranderId,
                SiteProfileId = borrower.SiteProfileId,
                AccountId = borrower.AccountId,
                Id = borrower.Id,
                Position = borrower.Position,
                EDisclosureConsent = borrower.EDisclosureConsent,
                EmailConsent = borrower.EmailConsent,
                EmailAddress = borrower.EmailAddress
            };
        }

        public async Task<BorrowerDto> Insert(BorrowerDto borrowerDto)
        {
            IBorrower borrower = await BorrowerFactory.CreateAsync(new Tuple<Guid, Guid, Guid, Guid>(borrowerDto.PartnerId, borrowerDto.CobranderId, borrowerDto.SiteProfileId, borrowerDto.AccountId));

            borrower.Position = borrowerDto.Position;
            borrower.EDisclosureConsent = borrowerDto.EDisclosureConsent;
            borrower.EmailConsent = borrowerDto.EmailConsent;
            borrower.EmailAddress = borrowerDto.EmailAddress;

            borrower = await borrower.SaveAsync() as IBorrower;

            return new BorrowerDto
            {
                PartnerId = borrower.PartnerId,
                CobranderId = borrower.CobranderId,
                SiteProfileId = borrower.SiteProfileId,
                AccountId = borrower.AccountId,
                Id = borrower.Id,
                Position = borrower.Position,
                EDisclosureConsent = borrower.EDisclosureConsent,
                EmailConsent = borrower.EmailConsent,
                EmailAddress = borrower.EmailAddress
            };
        }

        public async Task<BorrowerDto> Update(BorrowerDto borrowerDto)
        {
            IBorrower borrower = await BorrowerFactory.FetchAsync(borrowerDto.Id);

            borrower.Position = borrowerDto.Position;
            borrower.EDisclosureConsent = borrowerDto.EDisclosureConsent;
            borrower.EmailConsent = borrowerDto.EmailConsent;
            borrower.EmailAddress = borrowerDto.EmailAddress;

            borrower = await borrower.SaveAsync() as IBorrower;

            return new BorrowerDto
            {
                PartnerId = borrower.PartnerId,
                CobranderId = borrower.CobranderId,
                SiteProfileId = borrower.SiteProfileId,
                AccountId = borrower.AccountId,
                Id = borrower.Id,
                Position = borrower.Position,
                EDisclosureConsent = borrower.EDisclosureConsent,
                EmailConsent = borrower.EmailConsent,
                EmailAddress = borrower.EmailAddress
            };
        }

        public async Task Delete(Guid borrowerId)
        {
            await BorrowerFactory.DeleteAsync(borrowerId);
        }
    }
}
