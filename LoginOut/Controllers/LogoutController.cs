using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginOut.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginOut.Controllers
{
    [Route("api/logout")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        [HttpPost]
        public ActionResult Logout()
        {
            if (!Request.Headers.ContainsKey("username")) 
                return BadRequest();

            Request.Cookies.TryGetValue("username", out var _username);
            Request.Headers.TryGetValue("username", out var username);

            if (_username != username)
                return Unauthorized();

            Response.Cookies.Delete("username");

            return Users.I.Logout(username) ? (ActionResult) Ok() : (ActionResult) Unauthorized();
        }
    }
}
