using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaoCaoTienAn.Controllers
{
    [Authorize]
    public class NurturingManagementReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public NurturingManagementReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> PrintMealMoney(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            var report = await _unitOfWork.Report.ReportMealMoney(schoolId, startDate, endDate);
            return View(report);
        }
        public IActionResult TienAn()
        {
            return View();
        }
    }
}
