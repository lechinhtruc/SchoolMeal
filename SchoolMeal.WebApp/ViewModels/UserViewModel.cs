using DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolMeal.WebApp.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Hãy nhập ngày hết hạn!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiredAt { get; set; }

        public List<AccountRoles>? Modules { get; set; }
    }
}
