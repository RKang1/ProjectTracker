using Microsoft.Extensions.Configuration;
using ProjectTracker.Models;
using System.Collections.Generic;

namespace ProjectTracker.DAOs
{

    public class StatusDAO
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public StatusDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ProjectTrackerDb");
        }

        public IEnumerable<StatusModel> GetStatuses()
        {
            //List<StatusModel> rtn = new();

            //try
            //{
            //    using SqlConnection connection = new(_connectionString);
            //    using SqlCommand command = new("GetProjectsByUserId", connection)
            //    {
            //        CommandType = CommandType.StoredProcedure
            //    };

            //    command.Parameters.AddWithValue("UserId", userId);

            //    connection.Open();
            //    using SqlDataReader dataReader = command.ExecuteReader();
            //    if (dataReader.HasRows)
            //    {
            //        while (dataReader.Read())
            //        {
            //            rtn.Add(new StatusModel(dataReader));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine($"Exception: {ex.Message}");
            //}

            List<StatusModel> rtn = new List<StatusModel>
            {
                new StatusModel() { Id = 1, Name = "In Progress" },
                new StatusModel() { Id = 2, Name = "Completed" },
            };

            return rtn;
        }
    }
}
