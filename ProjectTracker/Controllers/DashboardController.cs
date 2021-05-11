using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectTracker.DAOs;
using ProjectTracker.Models.Dashboard.ViewModels;
using ProjectTracker.Models.Project.Models;
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

            return View();
        }

        public PartialViewResult LoadTablePartial()
        {
            IEnumerable<ProjectModel> projects = dao.GetProjects();
            return PartialView("~/Views/Dashboard/Partials/TablePartial.cshtml", projects);
        }

        public PartialViewResult LoadProjectPartial(string mode, int projectId)
        {
            ModifyProjectViewModel viewModel = new();

            switch (mode)
            {
                case "add":
                    viewModel.Mode = mode;
                    break;

                case "edit":
                case "delete":
                    viewModel = dao.GetProject(projectId).ToModifyProjectViewModel();
                    viewModel.Mode = mode;
                    break;
            }

            return PartialView("~/Views/Dashboard/Partials/ProjectPartial.cshtml", viewModel);
        }

        [HttpPost]
        public void SubmitProject(ModifyProjectViewModel viewModel)
        {
            switch (viewModel.Mode)
            {
                case "add":
                    dao.AddProject(viewModel.ToProjectModel());
                    break;
                case "edit":
                    dao.EditProject(viewModel.ToProjectModel());
                    break;
                case "delete":
                    dao.DeleteProject(viewModel.ToProjectModel());
                    break;
            }
        }
    }
}
