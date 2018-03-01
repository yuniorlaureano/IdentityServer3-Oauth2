using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer3.Core.Services.InMemory;

namespace OauthServer.Config
{
    public class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "bob", //Unique names
                    Password = "secret", //Unique attribute
                    Subject = "1" //Unique identifier
                },
                new InMemoryUser
                {
                    Username = "alice",
                    Password = "secret",
                    Subject = "2"
                }
            };
        }
    }
}
