using ProjectTracker.Models.Project.Models;

namespace ProjectTracker.Models.Project.ViewModels
{
    public class ModifyProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public int Stage { get; set; }

        public string Comments { get; set; }

        public string Mode { get; set; }

        public ProjectModel ToProjectModel()
        {
            return new ProjectModel()
            {
                Id = Id,
                Name = Name,
                Status = Status,
                Stage = Stage,
                Comments = Comments
            };
        }
    }
}
