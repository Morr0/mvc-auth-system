using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginOut.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginOut.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public ActionResult<string> Login()
        {
            if (!Request.Headers.ContainsKey("username") || !Request.Headers.ContainsKey("password"))
                return BadRequest();

            if (Request.Cookies.ContainsKey("username"))
                return Unauthorized();

            Request.Headers.TryGetValue("username", out var username);
            Request.Headers.TryGetValue("password", out var password);

            if (Users.I.Login(username, password))
            {
                CookieOptions cookie = new CookieOptions();
                cookie.HttpOnly = true;
                Response.Cookies.Append("username", username, cookie);

                return Ok();
            } else
            {
                return NotFound();
            }
        }
    }
}
