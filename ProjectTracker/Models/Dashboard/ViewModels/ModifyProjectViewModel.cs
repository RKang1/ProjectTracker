using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTracker.Models.Project.Models;

namespace ProjectTracker.Models.Dashboard.ViewModels
{
    public class ModifyProjectViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public int SelectedStatus { get; set; }

        public SelectList Statuses { get; set; }

        public int SelectedStage { get; set; }

        public SelectList Stages { get; set; }

        public string Comments { get; set; }

        public string Mode { get; set; }

        public ProjectModel ToProjectModel()
        {
            return new ProjectModel()
            {
                Id = Id,
                Name = Name,
                StatusId = SelectedStatus,
                StageId = SelectedStage,
                Comments = Comments
            };
        }
    }
}
