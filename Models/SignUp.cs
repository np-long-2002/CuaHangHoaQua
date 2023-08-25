using System.ComponentModel.DataAnnotations;

namespace CuaHangHoaQua.Models
{
    public class SignUp
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
