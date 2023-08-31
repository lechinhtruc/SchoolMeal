using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BaoCaoTienAn.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetMealMoney(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            try
            {
                return Ok(await _unitOfWork.Report.ReportMealMoney(schoolId, startDate, endDate));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcel(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var stream = await _unitOfWork.Report.ExportToExcel(schoolId, startDate, endDate);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Báo cáo tiền ăn ngày " + startDate + " đến " + endDate + ".xlsx");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExportToXml(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var stream = await _unitOfWork.Report.ExportToXml(schoolId, startDate, endDate);
                return File(stream, "application/xml", "Báo cáo tiền ăn ngày " + startDate + " đến " + endDate + ".xml");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
