using ProjectTracker.Models.Project.Models;

namespace ProjectTracker.Models.Project.ViewModels
{
    public class ModifyProjectViewModel : ProjectViewModel
    {
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
