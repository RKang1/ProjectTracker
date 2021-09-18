using System.Data.SqlClient;

namespace ProjectTracker.Models
{
    public class StatusModel
    {
        public StatusModel() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public StatusModel(SqlDataReader sqlDataReader)
        {
            Id = (int)sqlDataReader["Id"];
            Name = (string)sqlDataReader["Description"];
        }
    }
}
