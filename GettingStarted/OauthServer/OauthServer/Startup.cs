using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.InMemory;
using OauthServer.Config;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(OauthServer.Startup))]

namespace OauthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var options = new IdentityServerOptions
            {
                Factory = new IdentityServerServiceFactory()
                              .UseInMemoryClients(Clients.Get())
                              .UseInMemoryScopes(Scopes.Get())
                              .UseInMemoryUsers(Users.Get()),

                RequireSsl = false
            };

            app.UseIdentityServer(options);
        }
    }
}
