using BaoCaoTienAn.Controllers;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult TaoTaiKhoan()
        {
            return View();
        }

        public async Task<IActionResult> TaiKhoan()
        {
            var accounts = await _unitOfWork.ManageAccounts.GetAllAccount();
            return View(accounts);
        }

        public async Task<IActionResult> LichSuHoatDong()
        {
            return View(await _unitOfWork.UserLog.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(int Id)
        {
            await _unitOfWork.ManageAccounts.DeleteAccount(Id);
            return RedirectToAction("TaiKhoan");
        }

        [HttpPost]
        [ActionName("TaoTaiKhoan")]
        public IActionResult CreateAccount(AccountModel account)
        {
            if (ModelState.IsValid)
            {
                var user = _unitOfWork.Account.CreateAccount(account);
                if (user.Id != 0)
                {
                    TempData["Result"] = "Tạo tài khoản thành công!";
                    return RedirectToAction("TaoTaiKhoan");
                }
                else
                {
                    ModelState.AddModelError(nameof(user.Username), "Tài khoản đã tồn tại!");
                }
            }
            return View("TaoTaiKhoan");
        }
    }
}
