using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Models.Dashboard;
using ProjectTracker.Models.Project;
using System.Collections.Generic;

namespace ProjectTracker.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Project Tracker";

            DashboardViewModel model = new();

            List<ProjectModel> projects = new()
            {
                new ProjectModel()
                {
                    Name = "Project Test",
                    Status = "Needs Work",
                    Stage = "Alpha",
                    Comments = "Reading works!"
                }
            };

            model.Projects = projects;

            return View(model);
        }
    }
}
