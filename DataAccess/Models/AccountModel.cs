using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hãy nhập tài khoản!")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu!")]
        public string? Password { get; set; }
    }
}
