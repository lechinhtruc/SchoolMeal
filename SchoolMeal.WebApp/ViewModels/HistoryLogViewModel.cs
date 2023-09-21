using System.ComponentModel.DataAnnotations;

namespace SchoolMeal.WebApp.ViewModels
{
    public class HistoryLogViewModel
    {
        [Required(ErrorMessage = "Hãy nhập từ khoá muốn tìm kiếm!")]
        public string SearchString { get; set; } = string.Empty;
    }
}
