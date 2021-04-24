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

        public DashboardController(IConfiguration configuration)
        {
            _configuration = configuration;
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
    }
}
