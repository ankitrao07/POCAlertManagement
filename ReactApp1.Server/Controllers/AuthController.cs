using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities.Models;
using System.Security.AccessControl;
using System.Runtime.CompilerServices;
using Contracts;
using Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.RateLimiting;
using Newtonsoft.Json;

namespace ReactApp1.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private ILogger<AuthController> _logger;
        private IRepositoyWrapper _repository;

        public AuthController(IConfiguration configuration,ILogger<AuthController> logger,IRepositoyWrapper repository)
        {
            _configuration = configuration;
            _logger = logger;
            _repository = repository;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel user)
        {
           
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }
            if (_repository.User.IsAuthenticated(user.Email,user.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                HttpContext.Response.Cookies.Append("token", tokenString,
                    new CookieOptions
                    {
                        
                        Expires = DateTime.Now.AddMinutes(10),
                        HttpOnly=true,
                        Secure = true,
                        IsEssential=true,
                        SameSite=SameSiteMode.None
                    });
                var retVal = new AuthenticatedResponse { Token = tokenString };
                return Ok(true);
            }
            return Unauthorized(false);
        }
         
    }
}
