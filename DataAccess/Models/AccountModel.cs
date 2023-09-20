using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hãy nhập tài khoản!")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hãy nhập mật khẩu!")]
        public string Password { get; set; } = string.Empty;

        [MaxLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiredAt { get; set; }
    }
}
