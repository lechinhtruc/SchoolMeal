using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolMeal.WebApp.Extensions;
using SchoolMeal.WebApp.ViewModels;

namespace BaoCaoTienAn.Controllers
{
    [Controller]
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var User = HttpContext.Session.GetObject<UserViewModel>("User");
            if (User == null)
            {
                context.Result = new RedirectToActionResult("DangNhap", "Auth", null);
            }
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var User = HttpContext.Session.GetObject<UserViewModel>("User");
            string? actionName = context.RouteData.Values["action"]!.ToString();
            string? controllerName = context.RouteData.Values["controller"]!.ToString();
            var userLog = new HistoryLogModel()
            {
                UserID = User!.Id,
                Username = User.Username,
                Description = $"{User.Username} -> {controllerName} -> {actionName}",
                DateTime = DateTime.Now,
                Action = actionName,
                Controller = controllerName,
            };
            _unitOfWork.UserLog.AddLog(userLog);
        }
    }
}
