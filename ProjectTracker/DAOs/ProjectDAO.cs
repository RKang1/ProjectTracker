﻿using Microsoft.Extensions.Configuration;
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

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("GetProjectById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue(nameof(id), id);

                connection.Open();
                using SqlDataReader dataReader = command.ExecuteReader();
                if(dataReader.Read())
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

                command.Parameters.AddWithValue("UserId", project.UserId);
                command.Parameters.AddWithValue("Name", project.Name);
                command.Parameters.AddWithValue("Status", project.Status);
                command.Parameters.AddWithValue("Stage", project.Stage);
                command.Parameters.AddWithValue("Comments", project.Comments);

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
                command.Parameters.AddWithValue("UserId", project.UserId);
                command.Parameters.AddWithValue("Name", project.Name);
                command.Parameters.AddWithValue("Status", project.Status);
                command.Parameters.AddWithValue("Stage", project.Stage);
                command.Parameters.AddWithValue("Comments", project.Comments);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        public void DeleteProject(ProjectModel project)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("DeleteProject", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue(nameof(project.Id), project.Id);

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
