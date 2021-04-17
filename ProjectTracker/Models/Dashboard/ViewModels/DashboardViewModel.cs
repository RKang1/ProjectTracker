using System.Collections.Generic;
using ProjectTracker.Models.Project.Models;

namespace ProjectTracker.Models.Dashboard.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<ProjectModel> Projects { get; set; }
    }
}
