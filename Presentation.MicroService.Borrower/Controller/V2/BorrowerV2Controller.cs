using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace Presentation.MicroService.Borrower.Controller.V2
{
    [RoutePrefix("api/v2/Borrower")]
    public class BorrowerV2Controller : ApiController
    {
        [HttpGet]
        [Route]
        [SwaggerResponse(HttpStatusCode.NotFound, "Borrower not found")]
        public async Task<string> Get()
        {
            //fac
            //factory
            return await Task.FromResult("Hello V2 Borrower");
        }

        [HttpGet]
        [Route("GetBy")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Borrower not found")]
        public async Task<string> GetBy(string identifier)
        {
            //fac
            //factory
            return await Task.FromResult($"{identifier} V2 Borrower");
        }
    }
}
