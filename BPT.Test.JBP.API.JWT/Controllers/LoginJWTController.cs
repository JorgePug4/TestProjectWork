using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BPT.Test.JBP.API.JWT.Data;
using BPT.Test.JBP.API.JWT.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace BPT.Test.JBP.API.JWT.Controllers
{
    [Route("apijwt")]
    [ApiController]
    public class LoginJWTController : ControllerBase
    {
        private readonly BPTTestJBPAPIJWTContext _context;

        //public LoginJWTController()
        //{
            
        //}

        // GET: UserModels
 

        private IConfiguration _config;

        public LoginJWTController(IConfiguration config, BPTTestJBPAPIJWTContext context)
        {
            _config = config;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginJWT login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken();
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private LoginJWT AuthenticateUser(LoginJWT login)
        {
            LoginJWT user = null;

            var userjwt = _context.LoginJWT.Where(x => x.Username == login.Username && x.Password == login.Password);
            if (userjwt.Count() > 0)
                user = login;
            return user;
        }
    }
}
