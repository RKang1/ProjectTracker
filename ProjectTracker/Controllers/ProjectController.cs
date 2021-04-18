using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Models.Project.ViewModels;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewProjectPartial()
        {
            return PartialView("~/Views/Project/Partials/NewProjectPartial.cshtml", new NewProjectViewModel());
        }

        public void AddProject(NewProjectViewModel newProject)
        {

        }
    }
}
