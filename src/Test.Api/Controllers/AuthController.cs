using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Test.Api.Extensions;
using Test.Api.Models;
using Test.Domain.Entities;
using Test.Domain.Interfaces.Repositories;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public AuthController(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = _userRepository.Login(userLogin.Email, userLogin.Password);

            if (null == result)
            {
                return BadRequest("The email and/or password entered is invalid. Please try again");
            }

            var token = GenerateToken(result.Result);

            return Ok(token);
        }

        private string GenerateToken(UserSys user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim []
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("role", user.UserRole.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1.5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenResult = tokenHandler.WriteToken(token);

            return tokenResult;
        }
    }
}
