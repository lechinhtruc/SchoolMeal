using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hãy nhập tài khoản!")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hãy nhập mật khẩu!")]
        //[MinLength(6, ErrorMessage = "Mật khẩu quá ngắn, độ dài tối thiểu là 6 ký tự!")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hãy nhập số điện thoại!")]
        [MaxLength(10, ErrorMessage = "Số điện thoại không được quá 10 số!")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ!")]
        public string PhoneNumber { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Hãy nhập ngày hết hạn!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiredAt { get; set; }

        [Required(ErrorMessage = "Hãy nhập quyền của người dùng!")]
        public string Role { get; set; } = string.Empty;

        public static string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hashedPassword;
        }
    }
}
