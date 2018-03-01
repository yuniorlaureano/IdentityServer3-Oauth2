using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace ASPNETWebApi
{
    [Route("test")]
    public class TestController: ApiController
    {
        /// <summary>
        /// Api que para probar la parte de identity server, obteniendo tokens.
        /// Este es el recurso que sera accedido.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            var subjectClaim = caller.FindFirst("sub");

            if (subjectClaim != null)
            {
                return Json(
                    new
                    {
                        message = "OK user",
                        client = caller.FindFirst("client_id").Value,
                        subsject = subjectClaim.Value //client unique identifier
                    }
               );
            }
            else
            {
                return Json(
                    new
                    {
                        message = "OK computer",
                        client = caller.FindFirst("client_id").Value
                    }
                );
            }            
        }
    }
}