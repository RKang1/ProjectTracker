using ProjectTracker.Models.Dashboard.ViewModels;
using ProjectTracker.Models.Project.ViewModels;
using System.Data.SqlClient;

namespace ProjectTracker.Models.Project.Models
{
    public class ProjectModel
    {
        public ProjectModel() { }

        public ProjectModel(SqlDataReader sqlDataReader)
        {
            Id = (int)sqlDataReader["Id"];
            Name = (string)sqlDataReader["Name"];
            Status = (int)sqlDataReader["Status"];
            Stage = (int)sqlDataReader["Stage"];
            Comments = (string)sqlDataReader["Comments"];
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public int Stage { get; set; }

        public string Comments { get; set; }

        public ModifyProjectViewModel ToModifyProjectViewModel()
        {
            return new ModifyProjectViewModel()
            {
                Id = Id,
                Name = Name,
                Status = Status,
                Stage = Stage,
                Comments = Comments
            };
        }

        public ProjectViewModel ToProjectViewModel()
        {
            return new ProjectViewModel()
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
