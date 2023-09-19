using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BaoCaoTienAn.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult ThongTin()
        {
            return View();
        }

        public IActionResult DoiMatKhau()
        {
            return View();
        }

        [Route("{controller}/DoiMatKhau")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string OldPassword, string NewPassword)
        {
            if (ModelState.IsValid)
            {
                int Id = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value);
                var changePassword = await _unitOfWork.Account.ChangePassword(Id, OldPassword, NewPassword);
                if (changePassword)
                {
                    TempData["Result"] = "Đổi mật khẩu thành công!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "Mật khẩu cũ không chính xác!");
                    return View("DoiMatKhau");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("DangNhap", "Auth");
        }
    }
}
