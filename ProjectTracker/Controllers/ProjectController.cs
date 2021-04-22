using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectTracker.DAOs;
using ProjectTracker.Models.Project.Models;
using ProjectTracker.Models.Project.ViewModels;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ProjectDAO dao;

        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new(_configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadNewProject()
        {
            return PartialView("~/Views/Project/Partials/ProjectPartial.cshtml", new ProjectViewModel() { Mode = "add" });
        }

        public IActionResult LoadEditProject(int projectId)
        {
            ProjectModel project = dao.GetProject(projectId);
            ProjectViewModel viewModel = project;
            viewModel.Mode = "edit"; 

            return PartialView("~/Views/Project/Partials/ProjectPartial.cshtml", viewModel);
        }

        public void AddProject(ProjectModel newProject)
        {
            dao.AddProject(newProject);
        }

        public void EditProject(ProjectModel editProject)
        {
            dao.AddProject(editProject);
        }
    }
}
