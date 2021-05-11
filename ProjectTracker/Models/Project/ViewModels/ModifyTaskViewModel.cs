using ProjectTracker.Models.Project.Models;

namespace ProjectTracker.Models.Project.ViewModels
{
    public class ModifyTaskViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public string Comments { get; set; }

        public string Mode { get; set; }

        public TaskModel ToTaskModel()
        {
            return new TaskModel()
            {
                Id = Id,
                Description = Description,
                Status = Status,
                Comments = Comments
            };
        }
    }
}
