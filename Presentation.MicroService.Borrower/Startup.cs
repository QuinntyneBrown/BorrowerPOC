using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using DH.Lending.Microservice.Common.Interfaces;
using Owin;

namespace Presentation.MicroService.Borrower
{
    public class Startup : IOwinAppBuilder
    {
        public static void ConfigureFormatters(MediaTypeFormatterCollection formatters)
        {
            formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            SwaggerConfig.Register(config);
            config.MapHttpAttributeRoutes();
            ConfigureFormatters(config.Formatters);
            //ConfigureRoute(config);
            appBuilder.UseWebApi(config);
        }
        
    }
}
