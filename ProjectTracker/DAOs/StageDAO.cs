using Microsoft.Extensions.Configuration;
using ProjectTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjectTracker.DAOs
{
    public class StageDAO
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public StageDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ProjectTrackerDb");
        }

        public IEnumerable<StageModel> GetStages()
        {
            List<StageModel> rtn = new();

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new("GetStages", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        rtn.Add(new StageModel(dataReader));
                    }
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
