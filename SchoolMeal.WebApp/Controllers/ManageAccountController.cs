using BaoCaoTienAn.Controllers;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolMeal.WebApp.ViewModels;

namespace SchoolMeal.WebApp.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ManageAccountController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManageAccountController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LichSuHoatDong()
        {
            var logs = await _unitOfWork.UserLog.GetAll();
            var historyLogView = new HistoryLogViewModel();
            ViewData["Logs"] = logs;
            return View(historyLogView);
        }

    }
}
