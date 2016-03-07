using System.Threading.Tasks;
using System.Web.Http;

namespace DH.Lending.Borrower.Presentation.Api.Controllers.V1
{
    [Authorize]
    [RoutePrefix("api/v1/OAuthTest")]
    public class OAuthTestV1Controller : ApiController
    {
        [HttpGet]
        [Route("SayHello")]
        public Task<string> SayHello(string name)
        {
            return Task.FromResult($"Hello {name}");
        }

        
        [AllowAnonymous]
        [HttpGet]
        [Route("Hello")]
        public Task<string> Hello()
        {
            return Task.FromResult("Hello world");
        }
    }
}
