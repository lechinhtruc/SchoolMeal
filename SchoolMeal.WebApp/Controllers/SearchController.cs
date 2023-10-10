using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SchoolMeal.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["Root"] = "Tìm kiếm";
            ViewData["SearchString"] = searchString;
            var result = await _unitOfWork.Search.SearchData(searchString);
            return View(result);
        }
    }
}
