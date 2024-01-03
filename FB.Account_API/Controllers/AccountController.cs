using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FB.Account_API.Services;
using FB.Account_API.Entities;
using FB.Account_API.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using FB.Account_API.Repositories;
using FB.Account_API.Queries;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace FB.Account_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService service;
      // private readonly AccountQueriesRepository repository;
         private readonly IAccountQueriesRepository accountQueries;
        private readonly IAccountCommandsRepository accountCommands;

        private readonly ILogger _logger;


        public AccountController(AccountService service,IAccountQueriesRepository accountQueries,IAccountCommandsRepository accountCommands, ILogger<AccountController> logger)
        {
            this.service = service;
            this.accountQueries = accountQueries;
            this.accountCommands = accountCommands;
            this._logger = logger;
            
        }

       [HttpGet]
        public void OnGet()
        {
            string Message = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(Message);
        }
        

        [HttpPost]
        [Route("Validate")]
        public IActionResult Validate(Login login)//CQRS pattern
        {
            try
            {
                AuthUser authUser = null;
                User user = accountQueries.Validate(login);
                if (user != null)
                {
                    authUser = new AuthUser()
                    {
                        UserId = user.UserId,
                        Name = user.Name,
                        Token = GetToken(user),
                        Role = user.Role
                    };
                    _logger.LogInformation("User Validated!!!");

                }

                return Ok(authUser);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            try
            {
                accountCommands.Register(user);
                _logger.LogInformation("Registration Successful");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }
        private string GetToken(User user)
        {
            var _config = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json").Build();
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                   }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        [HttpPost]

        public IActionResult GetUserId(int UserId)// CQRS 
        {
            var repo = accountQueries.GetUserByID(UserId);
            try
            {
                if (repo != null)
                {
                    return Ok(repo);
                }

            }
           
            catch (Exception ex)
            {

                _logger.LogInformation(ex.Message);
            }

            return Ok(repo);
        }
    }
}
