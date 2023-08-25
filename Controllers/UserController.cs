using CuaHangHoaQua.Models;
using CuaHangHoaQua.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangHoaQua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            var user = await _userService.SignUpUser(signUp);
            if(user.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignIn signIn)
        {
            var user = await _userService.SignInUser(signIn);
            if (string.IsNullOrEmpty(user))
            {
                return BadRequest();
            }
            return Ok(user);
        }
    }
}
