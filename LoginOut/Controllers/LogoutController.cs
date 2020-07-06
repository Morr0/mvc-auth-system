﻿using System;
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

            Request.Headers.TryGetValue("username", out var username);
            return Users.I.Logout(username) ? (ActionResult) Ok() : (ActionResult) Unauthorized();
        }
    }
}
