using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthenticationPlugin;
using FoodApi.Data;
using FoodApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FoodApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly AuthService _auth;
        private FoodDbContext _dbContext;
        public UsersController(FoodDbContext dbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _auth = new AuthService(_configuration);
            _dbContext = dbContext;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Users user)
        {
            var userWithSameEmail = _dbContext.Users.SingleOrDefault(u => u.Email == user.Email);
            if (userWithSameEmail != null) return BadRequest("User with this email already exists");
            var userObj = new Users
            {
                UserId = Guid.NewGuid(),
                Username = user.Username,
                Password = user.Password,
                FName = user.FName,
                LName = user.LName,
                Email = user.Email,
                Phone1 = user.Phone1,
                Phone2 = user.Phone2,
                Address = user.Address,
                LocationMAP = user.LocationMAP,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                Age = user.Age,
                DateRegistered = user.DateRegistered,
                CityID = user.CityID,
                RegionID = user.RegionID,
                Active = user.Active
            };
            _dbContext.Users.Add(userObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(Users user)
        {
            var userEmail = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userEmail == null) return StatusCode(StatusCodes.Status404NotFound);
            var hashedPassword = userEmail.Password;
            if (!SecurePasswordHasherHelper.Verify(user.Password, hashedPassword)) return Unauthorized();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Email),
            };

            var token = _auth.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                token_type = token.TokenType,
                user_Id = userEmail.UserId,
                user_name = userEmail.Username,
                expires_in = token.ExpiresIn,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
            });
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult AdminLogin(ADMINMast ADMINMast)
        {
            var UserName = _dbContext.ADMINMast.FirstOrDefault(a => a.UserName == a.UserName);
            if (UserName == null) return StatusCode(StatusCodes.Status404NotFound);
            var hashedPassword = UserName.Password;
            if (!SecurePasswordHasherHelper.Verify(ADMINMast.Password, hashedPassword)) return Unauthorized();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, ADMINMast.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, ADMINMast.UserName),
            };

            var token = _auth.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                token_type = token.TokenType,
                Admin_Id = ADMINMast.AdminID,
                user_name = ADMINMast.UserName,
                expires_in = token.ExpiresIn,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
            });
        }
    }
}
