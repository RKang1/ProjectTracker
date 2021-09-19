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

        public ProjectModel GetProjectById(int id, string userId)
        {
            ProjectModel rtn = new();

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("GetProjectById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("UserId", userId);

                connection.Open();
                using SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    rtn = new ProjectModel(dataReader);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }

            return rtn;
        }

        public IEnumerable<ProjectModel> GetProjectsByUserId(string userId)
        {
            List<ProjectModel> rtn = new();

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("GetProjectsByUserId", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("UserId", userId);

                connection.Open();
                using SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        rtn.Add(new ProjectModel(dataReader));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }

            return rtn;
        }

        public void AddProject(ProjectModel project)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("AddProject", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("Name", project.Name);
                command.Parameters.AddWithValue("Status", project.StatusId);
                command.Parameters.AddWithValue("Stage", project.StageId);
                command.Parameters.AddWithValue("Comments", project.Comments);
                command.Parameters.AddWithValue("UserId", project.UserId);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        public void EditProject(ProjectModel project)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("EditProject", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("Id", project.Id);
                command.Parameters.AddWithValue("Name", project.Name);
                command.Parameters.AddWithValue("Status", project.StatusId);
                command.Parameters.AddWithValue("Stage", project.StageId);
                command.Parameters.AddWithValue("Comments", project.Comments);
                command.Parameters.AddWithValue("UserId", project.UserId);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        public void DeleteProjectById(int id, string userId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("DeleteProjectById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("UserId", userId);

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
