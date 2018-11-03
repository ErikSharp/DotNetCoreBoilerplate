using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Dtos;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserIn userParam)
        {
            UserOut authenticatedUser = userService.Authenticate(userParam);

            if (authenticatedUser == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(authenticatedUser);
        }

        [HttpGet]
        public IActionResult GetAll([FromHeader(Name = "Authorization")]string tokenString)
        {
            var handler = new JwtSecurityTokenHandler();
            var canRead = handler.CanReadToken(tokenString);
            var token = handler.ReadJwtToken(tokenString);
            var keys = token.Payload.Keys;

            var users = userService.GetAll();
            return Ok(users);
        }
    }
}