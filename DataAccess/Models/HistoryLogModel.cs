using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class HistoryLogModel
    {
        [Key]
        public int LogID { get; set; }
        public int UserID { get; set; }
        public string? Username { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string? Action { get; set; } = string.Empty;
        public string? Controller { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
