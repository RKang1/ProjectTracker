using Microsoft.Extensions.Configuration;
using ProjectTracker.Models.Project.Models;
using System;
using System.Collections.Generic;
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

        public TaskModel GetTaskById(int id, string userId)
        {
            TaskModel rtn = new();

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("GetTaskById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("UserId", userId);

                connection.Open();
                using SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    rtn = new TaskModel()
                    {
                        Id = (int)dataReader[nameof(TaskModel.Id)],
                        ProjectId = (int)dataReader[nameof(TaskModel.ProjectId)],
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

        public IEnumerable<TaskModel> GetTasksByProjectId(int projectId, string userId)
        {
            List<TaskModel> rtn = new();

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("GetTasksByProjectId", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("ProjectId", projectId);
                command.Parameters.AddWithValue("UserId", userId);

                connection.Open();
                using SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        TaskModel temp = new TaskModel()
                        {
                            Id = (int)dataReader[nameof(TaskModel.Id)],
                            ProjectId = (int)dataReader[nameof(TaskModel.ProjectId)],
                            Description = (string)dataReader[nameof(TaskModel.Description)],
                            Status = (int)dataReader[nameof(TaskModel.Status)],
                            Comments = (string)dataReader[nameof(TaskModel.Comments)],
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

        public void AddTask(TaskModel task, string userId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("AddTask", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("ProjectId", task.ProjectId);
                command.Parameters.AddWithValue("Description", task.Description);
                command.Parameters.AddWithValue("Status", task.Status);
                command.Parameters.AddWithValue("Comments", task.Comments);
                command.Parameters.AddWithValue("UserId", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        public void EditTask(TaskModel task, string userId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("EditTask", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("Id", task.Id);
                command.Parameters.AddWithValue("Description", task.Description);
                command.Parameters.AddWithValue("Status", task.Status);
                command.Parameters.AddWithValue("Comments", task.Comments);
                command.Parameters.AddWithValue("UserId", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        public void DeleteTaskById(int id, string userId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("DeleteTask", connection)
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
