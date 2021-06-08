using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectTracker.DAOs;
using ProjectTracker.Models.Project.Models;
using ProjectTracker.Models.Project.ViewModels;
using System.Collections.Generic;

namespace ProjectTracker.Controllers
{
    // TODO modify stored procs, daos, and controllers for user id
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

        public ViewResult Index(int projectId)
        {
            ProjectViewModel viewModel = projectDao.GetProject(projectId).ToProjectViewModel();

            return View(viewModel);
        }

        public PartialViewResult LoadTaskTablePartial(int projectId)
        {
            IEnumerable<TaskModel> tasks = taskDao.GetTasksByProjectId(projectId);
            return PartialView("~/Views/Project/Partials/TaskTablePartial.cshtml", tasks);
        }

        public PartialViewResult LoadTaskPartial(string mode, int taskId, int projectId)
        {
            ModifyTaskViewModel viewModel = new();

            if(mode == "edit" || mode == "delete")
            {
                viewModel = taskDao.GetTaskById(taskId).ToModifyTaskViewModel();
            }

            viewModel.ProjectId = projectId;
            viewModel.Mode = mode;

            return PartialView("~/Views/Project/Partials/ModifyTaskPartial.cshtml", viewModel);
        }

        [HttpPost]
        public void SubmitProject(ProjectViewModel viewModel)
        {
            switch (viewModel.Mode)
            {
                case "add":
                    //TODO create new project button that uses this
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

        [HttpPost]
        public void SubmitTask(ModifyTaskViewModel viewModel)
        {
            switch (viewModel.Mode)
            {
                case "add":
                    taskDao.AddTask(viewModel.ToTaskModel());
                    break;
                case "edit":
                    taskDao.EditTask(viewModel.ToTaskModel());
                    break;
                case "delete":
                    taskDao.DeleteTaskById(viewModel.Id);
                    break;
            }
        }
    }
}
