using ProjectTracker.Models.Project.Models;

namespace ProjectTracker.Models.Project.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public int Stage { get; set; }

        public string Comments { get; set; }

        public string Mode { get; set; }

        public static implicit operator ProjectViewModel(ProjectModel project)
        {
            return new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Status = project.Status,
                Stage = project.Stage,
                Comments = project.Comments
            };
        }
    }
}
