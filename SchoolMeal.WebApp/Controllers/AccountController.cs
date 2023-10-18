using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SchoolMeal.WebApp.Extensions;
using SchoolMeal.WebApp.ViewModels;
using System.Security.Claims;

namespace BaoCaoTienAn.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly string RootName = "Tài khoản";

        public AccountController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult ThongTin()
        {
            ViewData["Root"] = RootName;
            var infomation = HttpContext.Session.GetObject<UserViewModel>("User");
            return View(infomation);
        }

        [HttpGet]
        public IActionResult DoiMatKhau()
        {
            ViewData["Root"] = RootName;
            return View();
        }

        [HttpPost]
        [ActionName("DoiMatKhau")]
        public async Task<IActionResult> ChangePassword(string OldPassword, string NewPassword)
        {
            if (ModelState.IsValid)
            {
                int Id = HttpContext.Session.GetObject<UserViewModel>("User")!.Id;
                bool changePassword = await _unitOfWork.Account.ChangePassword(Id, OldPassword, NewPassword);
                if (changePassword)
                {
                    TempData["Result"] = "Đổi mật khẩu thành công!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "Mật khẩu cũ không chính xác!");
                }
            }
            ViewData["Root"] = RootName;
            return View("DoiMatKhau");
        }

        public IActionResult Logout()
        {
            return RedirectToAction("DangNhap", "Auth");
        }
    }
}
