using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SchoolMeal.WebApp.Extensions;
using SchoolMeal.WebApp.ViewModels;

namespace BaoCaoTienAn.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult DangNhap()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("User");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.Auth.Login(Username, Password);
                if (user.Id != 0)
                {
                    if (user.ExpiredAt > DateTime.Now)
                    {
                        //    var claims = new List<Claim>
                        //{
                        //     new(ClaimTypes.Name, user.Username),
                        //     new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        //     new(ClaimTypes.MobilePhone, user.PhoneNumber),
                        //     new("CreatedAt", user.CreatedAt.ToString()),
                        //     new("ExpiredAt", user.ExpiredAt.ToString()),
                        //};
                        //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        //    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                        UserViewModel User = new()
                        {
                            Id = user.Id,
                            Username = user.Username,
                            PhoneNumber = user.PhoneNumber,
                            CreatedAt = user.CreatedAt,
                            ExpiredAt = user.ExpiredAt,
                            Modules = user.Roles
                        };
                        HttpContext.Session.SetObject("User", User);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(user.Username), "Tài khoản đã hết hạn, hãy gia hạn để tiếp tục sử dụng!");
                    }

                }
                else
                {
                    ModelState.AddModelError(nameof(user.Password), "Thông tin đăng nhập không chính xác");
                }
            }
            return View("DangNhap");
        }
    }
}
