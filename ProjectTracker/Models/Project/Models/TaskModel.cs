using ProjectTracker.Models.Project.ViewModels;
using System.Data.SqlClient;

namespace ProjectTracker.Models.Project.Models
{
    public class TaskModel
    {
        public TaskModel() { }
        public TaskModel(SqlDataReader sqlDataReader)
        {
            Id = (int)sqlDataReader["Id"];
            Description = (string)sqlDataReader["Description"];
            Status = (int)sqlDataReader["Status"];
            Comments = (string)sqlDataReader["Comments"];
        }

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
                SelectedStatus = Status,
                Comments = Comments
            };
        }
    }
}
