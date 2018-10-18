using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "what's up my ninja";
        }

        // POST auth
        [HttpPost]
        public void Post(UserCredentials value)
        {
            Console.WriteLine(value.ToString());
        }
    }
}