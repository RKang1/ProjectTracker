using Microsoft.AspNetCore.Mvc;
using ProjectTracker.DAOs;
using ProjectTracker.Models.Project.ViewModels;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewProject()
        {
            return PartialView("~/Views/Project/Partials/NewProjectPartial.cshtml", new NewProjectViewModel());
        }

        public void AddProject(NewProjectViewModel newProject)
        {
            ProjectDAO dao = new();
            dao.AddProject(newProject);
        }
    }
}
