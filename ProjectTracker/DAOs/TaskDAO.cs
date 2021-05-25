﻿using Microsoft.Extensions.Configuration;
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

        public IEnumerable<TaskModel> GetTasks()
        {
            List<TaskModel> rtn = new();

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("GetTasks", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        TaskModel temp = new TaskModel()
                        {
                            Id = (int)dataReader[nameof(TaskModel.Id)],
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

        public void AddTask(TaskModel task)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("AddTask", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue(nameof(task.Description), task.Description);
                command.Parameters.AddWithValue(nameof(task.Status), task.Status);
                command.Parameters.AddWithValue(nameof(task.Comments), task.Comments);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        public void EditTask(TaskModel task)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("EditTask", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue(nameof(task.Id), task.Id);
                command.Parameters.AddWithValue(nameof(task.Description), task.Description);
                command.Parameters.AddWithValue(nameof(task.Status), task.Status);
                command.Parameters.AddWithValue(nameof(task.Comments), task.Comments);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        public void DeleteTask(TaskModel task)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("DeleteTask", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue(nameof(task.Id), task.Id);

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