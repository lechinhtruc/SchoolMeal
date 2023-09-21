using System.ComponentModel.DataAnnotations;

namespace BaoCaoTienAn.ViewModels
{
    public class ChangePasswordViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nhập mật khẩu cũ!")]
        public string OldPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nhập mật khẩu mới!")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nhập lại mật khẩu mới!")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu mới không khớp!")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
