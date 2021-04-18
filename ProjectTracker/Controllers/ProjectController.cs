using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectTracker.DAOs;
using ProjectTracker.Models.Project.ViewModels;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
            ProjectDAO dao = new(_configuration);
            dao.AddProject(newProject);
        }
    }
}
