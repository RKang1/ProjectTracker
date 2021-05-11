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
        private readonly ProjectDAO projectDao;

        public DashboardController(IConfiguration configuration)
        {
            _configuration = configuration;
            projectDao = new(_configuration);
        }

        public ViewResult Index()
        {
            ViewData["Title"] = "Project Tracker";

            return View();
        }

        public PartialViewResult LoadTablePartial()
        {
            IEnumerable<ProjectModel> projects = projectDao.GetProjects();
            return PartialView("~/Views/Dashboard/Partials/TablePartial.cshtml", projects);
        }

        public PartialViewResult LoadProjectPartial(string mode, int projectId)
        {
            ModifyProjectViewModel viewModel = new();

            if(mode == "edit" || mode == "delete")
            {
                viewModel = projectDao.GetProject(projectId).ToModifyProjectViewModel();
            }

            viewModel.Mode = mode;

            return PartialView("~/Views/Dashboard/Partials/ModifyProjectPartial.cshtml", viewModel);
        }

        [HttpPost]
        public void SubmitProject(ModifyProjectViewModel viewModel)
        {
            switch (viewModel.Mode)
            {
                case "add":
                    projectDao.AddProject(viewModel.ToProjectModel());
                    break;
                case "edit":
                    projectDao.EditProject(viewModel.ToProjectModel());
                    break;
                case "delete":
                    projectDao.DeleteProject(viewModel.ToProjectModel());
                    break;
            }
        }
    }
}
