using CuaHangHoaQua.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CuaHangHoaQua.Services
{
    public interface IUserService
    {
        public Task<IdentityResult> SignUpUser(SignUp model);
        public Task<string> SignInUser(SignIn model);
    }
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration configuration;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<string> SignInUser(SignIn model)
        {
            var user = await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
            if(!user.Succeeded)
            {
                return string.Empty;
            }
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: Claims,
                    signingCredentials: new SigningCredentials(authenKey,SecurityAlgorithms.HmacSha512Signature)
                    
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpUser(SignUp model)
        {
            var newUser = new User
            {
                Email = model.Email,
                UserName = model.Email,
            };
            return await _userManager.CreateAsync(newUser,model.Password);
        }
    }
}
