using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace DH.Lending.Borrower.Presentation.Api.Controllers.V2
{

    [RoutePrefix("api/v2/Borrower")]
    public class BorrowerV2Controller : ApiController
    {
        [Route]
        [SwaggerResponse(HttpStatusCode.NotFound, "Borrower not found")]
        public async Task<string> Get(string identifier)
        {
            return await Task.FromResult($"Borrower V2 {identifier}");
        }
    }
}