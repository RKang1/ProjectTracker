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

        public IActionResult AddProjectPartial()
        {
            return PartialView("~/Views/Project/Partials/AddProjectPartial.cshtml", new AddProjectViewModel());
        }

        public void AddProject(AddProjectViewModel newProject)
        {

        }
    }
}
