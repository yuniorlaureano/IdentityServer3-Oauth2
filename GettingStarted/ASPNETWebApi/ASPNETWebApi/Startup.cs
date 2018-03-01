using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.AccessTokenValidation;
using System.Web.Http;

[assembly: OwinStartup(typeof(ASPNETWebApi.Startup))]

namespace ASPNETWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions 
            {
                Authority = "http://localhost:5000",//Authorization server a utilizar
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new[] { "api1" } //Recurso qe representa.
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }
    }
}
