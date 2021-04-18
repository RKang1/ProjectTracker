﻿using Microsoft.Extensions.Configuration;
using ProjectTracker.Models.Project.Models;
using ProjectTracker.Models.Project.ViewModels;
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
                            Name = (string)dataReader[nameof(ProjectModel.Name)],
                            Status = (int)dataReader[nameof(ProjectModel.Status)],
                            Stage = (int)dataReader[nameof(ProjectModel.Stage)],
                            Comments = (string)dataReader[nameof(ProjectModel.Comments)],
                        };

                        rtn.Add(temp);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception: {e.Message}");
            }

            return rtn;
        }

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
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
