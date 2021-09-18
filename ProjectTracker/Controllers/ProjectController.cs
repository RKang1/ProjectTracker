using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ProjectTracker.DAOs;
using ProjectTracker.Models;
using ProjectTracker.Models.Project.Models;
using ProjectTracker.Models.Project.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ProjectDAO projectDAO;
        private readonly TaskDAO taskDAO;
        private readonly StatusDAO statusDAO;
        private readonly StageDAO stageDAO;


        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
            projectDAO = new(_configuration);
            taskDAO = new(_configuration);
            statusDAO = new(_configuration);
            stageDAO = new(_configuration);
        }

        public ActionResult Index(int projectId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ProjectModel project = projectDAO.GetProjectById(projectId, userId);

            ProjectViewModel viewModel = project.ToProjectViewModel();

            var Statuses = statusDAO.GetStatuses();

            viewModel.Statuses = new SelectList(Statuses, "Id", "Name");

            var Stages = stageDAO.GetStages();

            viewModel.Stages = new SelectList(Stages, "Id", "Name");

            return View(viewModel);
        }

        public PartialViewResult LoadTaskTablePartial(int projectId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<TaskModel> tasks = taskDAO.GetTasksByProjectId(projectId, userId);
            return PartialView("~/Views/Project/Partials/TaskTablePartial.cshtml", tasks);
        }

        public PartialViewResult LoadTaskPartial(string mode, int taskId, int projectId)
        {
            ModifyTaskViewModel viewModel = new();

            if (mode == "edit" || mode == "delete")
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                viewModel = taskDAO.GetTaskById(taskId, userId).ToModifyTaskViewModel();
            }

            viewModel.ProjectId = projectId;
            viewModel.Mode = mode;

            var Statuses = statusDAO.GetStatuses();

            viewModel.Statuses = new SelectList(Statuses, "Id", "Name");

            return PartialView("~/Views/Project/Partials/ModifyTaskPartial.cshtml", viewModel);
        }

        [HttpPost]
        public void SubmitProject(ProjectViewModel viewModel)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            switch (viewModel.Mode)
            {
                case "add":
                    // Can be used later if needed
                    //projectDao.AddProject(viewModel.ToProjectModel());
                    break;
                case "edit":
                    ProjectModel project = viewModel.ToProjectModel();
                    project.UserId = userId;
                    projectDAO.EditProject(project);
                    break;
                case "delete":
                    projectDAO.DeleteProjectById(viewModel.Id, userId);
                    break;
            }
        }

        [HttpPost]
        public void SubmitTask(ModifyTaskViewModel viewModel)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            switch (viewModel.Mode)
            {
                case "add":
                    taskDAO.AddTask(viewModel.ToTaskModel(), userId);
                    break;
                case "edit":
                    taskDAO.EditTask(viewModel.ToTaskModel(), userId);
                    break;
                case "delete":
                    taskDAO.DeleteTaskById(viewModel.Id, userId);
                    break;
            }
        }
    }
}
