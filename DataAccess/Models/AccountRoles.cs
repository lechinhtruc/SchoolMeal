using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class AccountRoles
    {
        [Key]
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string ActionName { get; set; } = string.Empty;

    }
}
