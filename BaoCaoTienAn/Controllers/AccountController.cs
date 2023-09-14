using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaoCaoTienAn.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult ThongTin()
        {
            return View();
        }

        public IActionResult DoiMatKhau()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword()
        {
            return Ok();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("DangNhap", "Auth");
        }
    }
}
