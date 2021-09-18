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
        private readonly ProjectDAO projectDao;
        private readonly TaskDAO taskDao;

        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
            projectDao = new(_configuration);
            taskDao = new(_configuration);
        }

        public ActionResult Index(int projectId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ProjectModel project = projectDao.GetProjectById(projectId, userId);

            ProjectViewModel viewModel = project.ToProjectViewModel();

            List<StatusModel> Statuses = new List<StatusModel>
            {
                new StatusModel() { Id = 1, Name = "In Progress" },
                new StatusModel() { Id = 2, Name = "Completed" },
            };

            viewModel.Statuses = new SelectList(Statuses, "Id", "Name");

            List<StageModel> Stages = new List<StageModel>
            {
                new StageModel() { Id = 1, Name = "Alpha" },
                new StageModel() { Id = 2, Name = "Beta" },
            };

            viewModel.Stages = new SelectList(Stages, "Id", "Name");

            return View(viewModel);
        }

        public PartialViewResult LoadTaskTablePartial(int projectId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<TaskModel> tasks = taskDao.GetTasksByProjectId(projectId, userId);
            return PartialView("~/Views/Project/Partials/TaskTablePartial.cshtml", tasks);
        }

        public PartialViewResult LoadTaskPartial(string mode, int taskId, int projectId)
        {
            ModifyTaskViewModel viewModel = new();

            if (mode == "edit" || mode == "delete")
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                viewModel = taskDao.GetTaskById(taskId, userId).ToModifyTaskViewModel();
            }

            viewModel.ProjectId = projectId;
            viewModel.Mode = mode;

            List<StatusModel> Statuses = new List<StatusModel>
            {
                new StatusModel() { Id = 1, Name = "In Progress" },
                new StatusModel() { Id = 2, Name = "Completed" },
            };

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
                    projectDao.EditProject(project);
                    break;
                case "delete":
                    projectDao.DeleteProjectById(viewModel.Id, userId);
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
                    taskDao.AddTask(viewModel.ToTaskModel(), userId);
                    break;
                case "edit":
                    taskDao.EditTask(viewModel.ToTaskModel(), userId);
                    break;
                case "delete":
                    taskDao.DeleteTaskById(viewModel.Id, userId);
                    break;
            }
        }
    }
}
