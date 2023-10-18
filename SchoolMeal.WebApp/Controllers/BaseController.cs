using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolMeal.WebApp.Extensions;
using SchoolMeal.WebApp.ViewModels;
using System.Security.Claims;

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
            //var User = HttpContext.Session.GetObject<UserViewModel>("User");  
            //if (User?.Id == 0)
            //{
            //   RedirectToAction("Index");
            //}
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //int Id = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value);
            //string? Username = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)!.Value;
            //string? actionName = context.RouteData.Values["action"]!.ToString();
            //string? controllerName = context.RouteData.Values["controller"]!.ToString();
            //var userLog = new HistoryLogModel()
            //{
            //    UserID = Id,
            //    Username = Username,
            //    Description = $"{Username} -> {controllerName} -> {actionName}",
            //    DateTime = DateTime.Now,
            //    Action = actionName,
            //    Controller = controllerName,
            //};
            //_unitOfWork.UserLog.AddLog(userLog);
        }
    }
}
