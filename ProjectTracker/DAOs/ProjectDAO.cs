using Microsoft.Extensions.Configuration;
using ProjectTracker.Models.Project.Models;
using System;
using System.Collections.Generic;
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

        public ProjectModel GetProject(int id)
        {
            ProjectModel rtn = new();

            return rtn;
        }

        public IEnumerable<ProjectModel> GetProjects()
        {
            List<ProjectModel> rtn = new();

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("GetProjects", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ProjectModel temp = new ProjectModel()
                        {
                            Id = (int)dataReader[nameof(ProjectModel.Id)],
                            Name = (string)dataReader[nameof(ProjectModel.Name)],
                            Status = (int)dataReader[nameof(ProjectModel.Status)],
                            Stage = (int)dataReader[nameof(ProjectModel.Stage)],
                            Comments = (string)dataReader[nameof(ProjectModel.Comments)],
                        };

                        rtn.Add(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }

            return rtn;
        }

        public void AddProject(ProjectModel newProject)
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
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        //TODO write the stored proc for this
        public void EditProject(ProjectModel editProject)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("EditProject", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue(nameof(editProject.Name), editProject.Name);
                command.Parameters.AddWithValue(nameof(editProject.Status), editProject.Status);
                command.Parameters.AddWithValue(nameof(editProject.Stage), editProject.Stage);
                command.Parameters.AddWithValue(nameof(editProject.Comments), editProject.Comments);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

    }
}
