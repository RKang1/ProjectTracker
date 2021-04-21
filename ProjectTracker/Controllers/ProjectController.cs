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
            return PartialView("~/Views/Project/Partials/ProjectPartial.cshtml", new ProjectViewModel() { Mode = "add" });
        }

        public void AddProject(ProjectViewModel newProject)
        {
            ProjectDAO dao = new(_configuration);
            dao.AddProject(newProject);
        }

        public void EditProject(ProjectViewModel editProject)
        {
            ProjectDAO dao = new(_configuration);
            dao.AddProject(editProject);
        }

    }
}
