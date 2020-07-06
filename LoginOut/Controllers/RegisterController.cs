using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginOut.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginOut.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public ActionResult Register()
        {
            if (!Request.Headers.ContainsKey("username") || !Request.Headers.ContainsKey("password"))
                return BadRequest();

            Request.Headers.TryGetValue("username", out var username);
            Request.Headers.TryGetValue("password", out var password);

            return Users.I.Register(username, password) ? (ActionResult) Ok() : Unauthorized();
        }
    }
}
