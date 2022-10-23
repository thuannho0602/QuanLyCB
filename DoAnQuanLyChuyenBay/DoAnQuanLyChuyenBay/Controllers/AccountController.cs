using DoAnCB.Entity;
using DoAnCB.Model;
using DoAnCB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IUserServices userService;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<User> userManager, IConfiguration configuration, IUserServices userService)
        {
            this.userManager = userManager;
            //this._roleManager = roleManager;
            this.configuration = configuration;
            
            this.userService = userService;
        }
        [HttpPost("createUser")]
        [ProducesResponseType(typeof(BaseResponseModel<JsonResult>), 200)]
        //[Authorize]
        public async Task<IActionResult> CreateUser(UserCreatRequest newUserDto)
        {
            var newUser = new User()
            {
                UserName = newUserDto.UserName,
                FirstName = newUserDto.FirstName,
                LastName = newUserDto.LastName,
                PhoneNumber = newUserDto.SoDienThoai,
                NgaySinh = newUserDto.NgaySinh,
                SoDienThoai = newUserDto.SoDienThoai,
                HovaTen = newUserDto.HovaTen,
                Email = newUserDto.UserName,
                DiaChi = newUserDto.DiaChi,
                EmailConfirmed = true,
            };
            var result = await userManager.CreateAsync(newUser, newUserDto.Password);
            
            if (result.Succeeded)
            {
                return Ok(new { MsgCode = "200", Message = "Tạo user thành công!" });
            }
            return BadRequest(new { MsgCode = "403", Message = "Tạo user thất bại!" });
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login(Login model)
        {
            if(!ModelState.IsValid)
            {
                return InvalidModel();
            }
            var user = await userManager.FindByNameAsync(model.Username);
            if(user==null)
            {
                return Failure("Password và Email Không Hợp Lệ");
            }
            var verigyResult = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if(verigyResult==PasswordVerificationResult.Failed)
            {
                return Failure("Password và Email Không Hợp Lệ");
            }
            var token = await CreatedToken(user);
            return Success(token);
        }
        [HttpGet("GetUserById")]
        public async Task<User> GetUserById([FromQuery]string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return new Entity.User();
            return user;
        }
        private async Task<string> CreatedToken(User user)
        {
            var username = user.UserName != null ? user.UserName : "";
            var email = user.Email != null ? user.Email : "";
            var firstname = user.FirstName != null ? user.FirstName:"";
            var lastname = user.LastName != null ? user.LastName:"";
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,username),
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim(JwtRegisteredClaimNames.GivenName,firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName,lastname)
            };
            var config = configuration.GetSection("Jwt").Get<JwtTokenSetting>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey));
            var token = new JwtSecurityToken(
                issuer:config.SecretKey,
                audience:config.SecretKey,
                claims:claims,
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddMinutes(config.ExpiryMinutes),
                signingCredentials:new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
