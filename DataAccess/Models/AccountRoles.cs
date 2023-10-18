using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Models
{
    public class AccountRoles
    {
        [Key]
        public int Id { get; set; }

        public string ActionName { get; set; } = string.Empty;

        public int AccountId { get; set; }

        [JsonIgnore]
        public AccountModel? Account { get; set; }

    }
}
