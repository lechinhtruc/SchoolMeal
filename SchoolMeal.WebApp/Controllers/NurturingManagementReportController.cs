using BaoCaoTienAn.ViewModels;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaoCaoTienAn.Controllers
{
    [Authorize]
    public class NurturingManagementReportController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NurturingManagementReportController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("{controller}/TienAn")]
        [ActionName("TienAn")]
        public async Task<IActionResult> GetMealMoney(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            try
            {
                ViewData["Reports"] = await _unitOfWork.Report.ReportMealMoney(schoolId, startDate, endDate);
                return View("TienAn");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PrintMealMoney([FromForm] Guid schoolId, [FromForm] DateTime startDate, [FromForm] DateTime endDate)
        {
            var report = await _unitOfWork.Report.ReportMealMoney(schoolId, startDate, endDate);
            return View(report);
        }

        [HttpPost]
        public async Task<IActionResult> ExportToExcel(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var stream = await _unitOfWork.Report.ExportToExcel(schoolId, startDate, endDate);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Báo cáo tiền ăn ngày " + startDate.ToString("dd-MM-yyyy") + " đến " + endDate.ToString("dd-MM-yyyy") + ".xlsx");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExportToXml(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var stream = await _unitOfWork.Report.ExportToXml(schoolId, startDate, endDate);
                return File(stream, "application/xml", "Báo cáo tiền ăn ngày " + startDate.ToString("dd-MM-yyyy") + " đến " + endDate.ToString("dd-MM-yyyy") + ".xml");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [ActionName("TienAn")]
        public IActionResult TienAn()
        {
            ReportMealMoneyViewModel reportMealMoneyView = new();
            return View(reportMealMoneyView);
        }
    }
}
