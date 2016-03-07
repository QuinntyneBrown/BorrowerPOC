using DH.Lending.Borrower.Service.Repository.V1;
using DH.Lending.Borrower.Service.Repository.V1.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace DH.Lending.Borrower.Presentation.Api.Controllers.V1
{
    [RoutePrefix("api/v1/Borrower")]
    public class BorrowerV1Controller : ApiController
    {
        public BorrowerV1Controller(IBorrowerService borrowerService)
        {
            BorrowerService = borrowerService;
        }
        
        private IBorrowerService BorrowerService { get; }

        [Route]
        [SwaggerResponse(HttpStatusCode.OK, "Borrower details", typeof(BorrowerDto))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Borrower not found")]
        public async Task<BorrowerDto> Get(Guid borrowerId)
        {
            return await BorrowerService.Get(borrowerId);
        }

        [Route]
        [SwaggerResponse(HttpStatusCode.OK, "Borrower details", typeof(BorrowerDto))]
        public async Task<BorrowerDto> Put(BorrowerDto borrower)
        {
            return await BorrowerService.Update(borrower);
        }

        [Route]
        [SwaggerResponse(HttpStatusCode.OK, "Borrower details", typeof(BorrowerDto))]
        public async Task<BorrowerDto> Post(BorrowerDto borrower)
        {
            return await BorrowerService.Insert(borrower);
        }

        [Route]
        [SwaggerResponse(HttpStatusCode.OK, "Borrower deleted")]
        public async Task Delete(Guid borrowerId)
        {
            await BorrowerService.Delete(borrowerId);
        }
    }
}