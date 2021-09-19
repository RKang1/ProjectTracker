using ProjectTracker.Helpers;
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
            UserId = (string)sqlDataReader["UserId"];
            Name = (string)sqlDataReader["Name"];
            StatusId = (int)sqlDataReader["StatusId"];
            Status = (string)sqlDataReader["Status"];
            StageId = (int)sqlDataReader["StageId"];
            Stage = (string)sqlDataReader["Stage"];
            Comments = DatabaseHelper.ConvertFromDBVal<string>(sqlDataReader["Comments"]);
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public int StatusId { get; set; }

        public string Status { get; set; }

        public int StageId { get; set; }

        public string Stage { get; set; }

        public string Comments { get; set; }

        public ModifyProjectViewModel ToModifyProjectViewModel()
        {
            return new ModifyProjectViewModel()
            {
                Id = Id,
                Name = Name,
                SelectedStatus = StatusId,
                SelectedStage = StageId,
                Comments = Comments
            };
        }

        public ProjectViewModel ToProjectViewModel()
        {
            return new ProjectViewModel()
            {
                Id = Id,
                Name = Name,
                SelectedStatus = StatusId,
                SelectedStage = StageId,
                Comments = Comments
            };
        }
    }
}
