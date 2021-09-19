using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTracker.Models.Project.Models;

namespace ProjectTracker.Models.Project.ViewModels
{
    public class ModifyTaskViewModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Description { get; set; }

        public int SelectedStatus { get; set; }

        public SelectList Statuses { get; set; }

        public string Comments { get; set; }

        public string Mode { get; set; }

        public TaskModel ToTaskModel()
        {
            return new TaskModel()
            {
                Id = Id,
                ProjectId = ProjectId,
                Description = Description,
                StatusId = SelectedStatus,
                Comments = Comments
            };
        }
    }
}
