using System.ComponentModel.DataAnnotations;


namespace DataAccess.Models
{
    public class SchoolRecord
    {
        [Key]
        public int Id { get; set; }
        public Guid SchoolId { get; set; }
        public DateTime Date { get; set; }
        public decimal TienAnSang { get; set; }
        public decimal TienAnTrua { get; set; }
        public decimal TienAnChieu { get; set; }
        public decimal PhuPhi { get; set; }
    }
}
