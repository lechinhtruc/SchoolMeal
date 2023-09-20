using System.ComponentModel.DataAnnotations;

namespace BaoCaoTienAn.ViewModels
{
    public class ReportMealMoneyViewModel
    {
        [Required(ErrorMessage = "Hãy nhập mã trường!")]
        public string? SchoolId { get; set; }

        [Required(ErrorMessage = "Hãy nhập ngày bắt đầu để tìm kiếm!")]
        public string? StartDate { get; set; }

        [Required(ErrorMessage = "Hãy nhập ngày kết thúc để tìm kiếm!")]
        public string? EndDate { get; set; }

        public ReportMealMoneyViewModel()
        {
            var now = DateTime.Now;
            StartDate = new DateTime(now.Year, now.Month, 1).ToString("yyyy-MM-dd");
            EndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).ToString("yyyy-MM-dd");
        }
    }
}
