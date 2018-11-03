using ApplicationCore.Dtos;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                Email = "erik.sharp@hadleyshope.com",
                PasswordHash = "$2y$12$yVYkJsR7a4Wj3wRzCD9Pn.DvDGWY3Dzx2AwisSqailn3Pyu.X.zWi" //password
            }
        };

        private readonly AppSettings appSettings;
        private readonly IMapper mapper;

        public UserService(
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            this.appSettings = appSettings.Value;
            this.mapper = mapper;
        }

        public UserOut Authenticate(UserIn userIn)
        {
            var user = _users.SingleOrDefault(x => x.Email == userIn.Email);

            // return null if user not found
            if (user == null)
                return null;

            bool passMatchesHash =
                BCrypt.Net.BCrypt.Verify(userIn.Password, user.PasswordHash);

            // return null when wrong password
            if (!passMatchesHash)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userOut = mapper.Map<UserOut>(user);
            userOut.Token = tokenHandler.WriteToken(token);
            
            return userOut;
        }

        public IEnumerable<UserOut> GetAll()
        {
            return _users.Select(u => {
                return mapper.Map<UserOut>(u);
            });
        }
    }
}
