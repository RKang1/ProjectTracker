using Microsoft.AspNetCore.Mvc;

namespace ProjectTracker.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Project Tracker";

            return View();
        }
    }
}
