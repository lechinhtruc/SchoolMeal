using System.ComponentModel.DataAnnotations;

namespace SchoolMeal.WebApp.ViewModels
{
    public class EditUserViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hãy nhập tài khoản!")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hãy nhập số điện thoại!")]
        [MinLength(10, ErrorMessage = "Số điện thoại không được ít hơn 10 số!")]
        [MaxLength(10, ErrorMessage = "Số điện thoại không được quá 10 số!")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ!")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hãy nhập ngày hết hạn!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiredAt { get; set; }

        [Required(ErrorMessage = "Hãy nhập quyền của người dùng!")]
        public string Role { get; set; } = string.Empty;

    }
}
