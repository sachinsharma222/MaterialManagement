using DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MaterialManagement.web.Controllers.API
{
    public class AccountController : Controller
    {
        private IConfiguration _config;
        private readonly AppDbContext db;

        public AccountController(IConfiguration config, AppDbContext db)
        {
            _config = config;
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate([FromBody]UserVM userInfo)
        {
            if (userInfo != null)
            {
                userInfo.UserName = userInfo.Email;
                var user = db.Users.FirstOrDefault(x => x.Email == userInfo.Email);
                if (user != null)
                {
                    PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
                    var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash,userInfo.Password);
                    if (result==PasswordVerificationResult.Success)
                    {
                        var token = GenerateJSONWebToken(userInfo);
                        userInfo.Token = token;
                        userInfo.Password = "";
                        return Json(userInfo);
                    }
                }
            }
            return Json(new { token = "",msg="Invalid User" });
            
        }

        private string GenerateJSONWebToken(UserVM userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
