using System.Collections.Generic;
using ProjectTracker.Models.Project;

namespace ProjectTracker.Models.Dashboard
{
    public class DashboardViewModel
    {
        public IEnumerable<ProjectModel> Projects { get; set; }
    }
}
