using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace Presentation.Stateless.Controller.V2
{
    [RoutePrefix("api/v2/Borrower")]
    public class BorrowerV2Controller : ApiController
    {
        [HttpGet]
        [Route("Get")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Borrower not found")]
        public async Task<string> Get()
        {
            //fac
            //factory
            return await Task.FromResult("Hello Borrower");
        }
    }
}
