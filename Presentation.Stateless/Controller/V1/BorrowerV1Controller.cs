using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace Presentation.Stateless.Controller.V1
{
    [RoutePrefix("api/v1/Borrower")]
    public class BorrowerV1Controller : ApiController
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
