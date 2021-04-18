using Microsoft.Extensions.Configuration;
using ProjectTracker.Models.Project.ViewModels;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjectTracker.DAOs
{
    public class ProjectDAO
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProjectDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ProjectTrackerDb");
        }

        public object Database { get; }

        public void AddProject(NewProjectViewModel newProject)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("AddProject", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue(nameof(newProject.Name), newProject.Name);
                command.Parameters.AddWithValue(nameof(newProject.Status), newProject.Status);
                command.Parameters.AddWithValue(nameof(newProject.Stage), newProject.Stage);
                command.Parameters.AddWithValue(nameof(newProject.Comments), newProject.Comments);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Debug.WriteLine($"Rows Affected: {rowsAffected}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
