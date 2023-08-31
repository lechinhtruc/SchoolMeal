using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BaoCaoTienAn.Controllers
{
    public class PrintController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public PrintController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> MealMoneyReport(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            var report = await _unitOfWork.Report.ReportMealMoney(schoolId, startDate, endDate);
            return View(report);
        }
    }
}
