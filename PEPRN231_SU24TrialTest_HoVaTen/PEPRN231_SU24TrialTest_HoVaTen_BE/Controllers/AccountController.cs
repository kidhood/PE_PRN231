using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PEPRN231_SU24TrialTest_HoVaTen_BE.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WatercolorsPainting_BO;
using WatercolorsPainting_Repository.Interface;

namespace PEPRN231_SU24TrialTest_HoVaTen_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IConfiguration _config;

        public AccountController(IUserAccountRepository userAccountRepository, IConfiguration config)
        {
            this.userAccountRepository = userAccountRepository;
            _config = config;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request) 
        {
            var account = this.userAccountRepository.CheckLogin(request.UserEmail, request.Password);
            if (account == null)
                return Unauthorized();

            var token = this.GenerateJSONWebToken(account);
            return Ok(token);
        }

        private string GenerateJSONWebToken(UserAccount userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              new Claim[]
              {
                  new(ClaimTypes.Email, userInfo.UserEmail),
                  new(ClaimTypes.Role, userInfo.Role.ToString()),
                  new("userId", userInfo.UserAccountId.ToString()),
              },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
