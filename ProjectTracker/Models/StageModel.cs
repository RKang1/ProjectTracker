using System.Data.SqlClient;

namespace ProjectTracker.Models
{
    public class StageModel
    {
        public StageModel() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public StageModel(SqlDataReader sqlDataReader)
        {
            Id = (int)sqlDataReader["Id"];
            Name = (string)sqlDataReader["Description"];
        }
    }
}
