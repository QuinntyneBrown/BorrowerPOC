using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DH.Lending.Borrower.Presentation.Api.Controllers.V1
{
    [RoutePrefix("api/v1/HelloWorld")]
    public class HelloWorldV1Controller : ApiController
    {
        [HttpGet]
        [Route]
        public Task<string> Get()
        {
            return Task.FromResult("Hello World !!!");
        }
    }
}
