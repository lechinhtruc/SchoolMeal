using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BaoCaoTienAn.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {

        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult ThongTin()
        {
            int Id = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value);
            string Username = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)!.Value;
            string PhoneNumber = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.MobilePhone)!.Value;
            DateTime CreatedAt = Convert.ToDateTime(User.Claims.FirstOrDefault(claim => claim.Type == "CreatedAt")!.Value);
            DateTime ExpiredAt = Convert.ToDateTime(User.Claims.FirstOrDefault(claim => claim.Type == "ExpiredAt")!.Value);
            var infomation = new AccountModel()
            {
                Id = Id,
                Username = Username,
                PhoneNumber = PhoneNumber,
                CreatedAt = CreatedAt,
                ExpiredAt = ExpiredAt,
            };
            return View(infomation);
        }

        public IActionResult DoiMatKhau()
        {
            return View();
        }

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
