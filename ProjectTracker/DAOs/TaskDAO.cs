using Microsoft.Extensions.Configuration;
using ProjectTracker.Models.Project.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjectTracker.DAOs
{
    public class TaskDAO
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public TaskDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ProjectTrackerDb");
        }

        public TaskModel GetTask(int id)
        {
            TaskModel rtn = new();

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("GetTaskById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue(nameof(id), id);

                connection.Open();
                using SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    rtn = new TaskModel()
                    {
                        Id = (int)dataReader[nameof(TaskModel.Id)],
                        Description = (string)dataReader[nameof(TaskModel.Description)],
                        Status = (int)dataReader[nameof(TaskModel.Status)],
                        Comments = (string)dataReader[nameof(TaskModel.Comments)],
                    };
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }

            return rtn;
        }
    }
}
