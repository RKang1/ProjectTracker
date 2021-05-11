using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectTracker.DAOs;
using ProjectTracker.Models.Project.Models;
using ProjectTracker.Models.Project.ViewModels;
using System.Collections.Generic;

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
        public ViewResult Index(int projectId)
        {
            ProjectViewModel viewModel = dao.GetProject(projectId).ToProjectViewModel();

            return View(viewModel);
        }

        public PartialViewResult LoadTaskTablePartial()
        {
            List<TaskModel> tasks = new();
            tasks.Add(new TaskModel
            {
                Id = 1,
                Description = "Task 1",
                Status = "In progress",
                Comments = "Hooray"
            });

            return PartialView("~/Views/Project/Partials/TaskTablePartial.cshtml", tasks);
        }

        public PartialViewResult LoadTaskPartial(string mode, int taskId)
        {
            ModifyProjectViewModel viewModel = new();

            switch (mode)
            {
                case "add":
                    viewModel.Mode = "add";
                    break;

                case "edit":
                case "delete":
                    viewModel = dao.GetProject(taskId).ToModifyProjectViewModel();
                    viewModel.Mode = mode;
                    break;
            }

            return PartialView("~/Views/Project/Partials/TaskPartial.cshtml", viewModel);
        }

        [HttpPost]
        public void SubmitTask(ModifyProjectViewModel viewModel)
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
