using Microsoft.AspNetCore.Mvc;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        public ViewResult Index(int projectId)
        {
            return View();
        }
    }
}
