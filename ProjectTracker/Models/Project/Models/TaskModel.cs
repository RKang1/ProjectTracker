using ProjectTracker.Models.Project.ViewModels;

namespace ProjectTracker.Models.Project.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public string Comments { get; set; }

        public ModifyTaskViewModel ToModifyTaskViewModel()
        {
            return new ModifyTaskViewModel()
            {
                Id = Id,
                ProjectId = ProjectId,
                Description = Description,
                Status = Status,
                Comments = Comments
            };
        }
    }
}
