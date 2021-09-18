using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ProjectTracker.DAOs;
using ProjectTracker.Models;
using ProjectTracker.Models.Dashboard.ViewModels;
using ProjectTracker.Models.Project.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectTracker.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ProjectDAO projectDAO;
        private readonly StatusDAO statusDAO;
        private readonly StageDAO stageDAO;

        public DashboardController(IConfiguration configuration)
        {
            _configuration = configuration;
            projectDAO = new(_configuration);
            statusDAO = new(_configuration);
            stageDAO = new(_configuration);
        }

        public ViewResult Index()
        {
            ViewData["Title"] = "Project Tracker";

            return View();
        }

        public PartialViewResult LoadTablePartial()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<ProjectModel> projects = projectDAO.GetProjectsByUserId(userId);
            return PartialView("~/Views/Dashboard/Partials/TablePartial.cshtml", projects);
        }

        public PartialViewResult LoadProjectPartial(string mode, int projectId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ModifyProjectViewModel viewModel = new();

            if (mode == "edit" || mode == "delete")
            {
                viewModel = projectDAO.GetProjectById(projectId, userId).ToModifyProjectViewModel();
            }

            viewModel.Mode = mode;

            var Statuses = statusDAO.GetStatuses();

            viewModel.Statuses = new SelectList(Statuses, "Id", "Name");

            var Stages = stageDAO.GetStages();

            viewModel.Stages = new SelectList(Stages, "Id", "Name");

            return PartialView("~/Views/Dashboard/Partials/ModifyProjectPartial.cshtml", viewModel);
        }

        [HttpPost]
        public void SubmitProject(ModifyProjectViewModel viewModel)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            switch (viewModel.Mode)
            {
                case "add":
                case "edit":
                    ProjectModel project = viewModel.ToProjectModel();
                    project.UserId = userId;

                    if (viewModel.Mode == "add")
                    {
                        projectDAO.AddProject(project);
                    }
                    else
                    {
                        projectDAO.EditProject(project);
                    }
                    break;
                case "delete":
                    projectDAO.DeleteProjectById(viewModel.Id, userId);
                    break;
            }
        }
    }
}
