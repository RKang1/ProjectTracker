using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectTracker.DAOs;
using ProjectTracker.Models.Dashboard.ViewModels;
using ProjectTracker.Models.Project.Models;
using ProjectTracker.Models.Project.ViewModels;
using System.Collections.Generic;

namespace ProjectTracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ProjectDAO dao;

        public DashboardController(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new(_configuration);
        }

        public ViewResult Index()
        {
            ViewData["Title"] = "Project Tracker";

            DashboardViewModel model = new();
            ProjectDAO projectDAO = new(_configuration);

            IEnumerable<ProjectModel> projects = projectDAO.GetProjects();

            model.Projects = projects;

            return View(model);
        }

        public PartialViewResult LoadNewProject()
        {
            return PartialView("~/Views/Project/Partials/ProjectPartial.cshtml", new ProjectViewModel() { Mode = "add" });
        }

        public PartialViewResult LoadEditProject(int projectId)
        {
            ProjectModel project = dao.GetProject(projectId);
            ProjectViewModel viewModel = project.ToProjectViewModel();
            viewModel.Mode = "edit";

            return PartialView("~/Views/Project/Partials/ProjectPartial.cshtml", viewModel);
        }

        [HttpPost]
        public void SubmitProject(ProjectViewModel project)
        {
            switch (project.Mode)
            {
                case "add":
                    dao.AddProject(project.ToProjectModel());
                    break;
                case "edit":
                    dao.EditProject(project.ToProjectModel());
                    break;
            }
        }
    }
}
