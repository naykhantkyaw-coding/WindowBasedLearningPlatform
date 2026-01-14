using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    public class DatabaseService
    {
        // for select data
        public List<T> Query<T>(string query, params SqlParameter[] parameters)
        {
            string connectionString = ConfigurationService.GetDbConnection();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            List<T>? data = JsonConvert.DeserializeObject<List<T>>(json);
            return data;
        }

        // for select data with specific range
        public T? QueryFirstOrDefault<T>(string query, params SqlParameter[] parameters)
        {
            string connectionString = ConfigurationService.GetDbConnection();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            List<T>? data = JsonConvert.DeserializeObject<List<T>>(json);
            return data.FirstOrDefault();
        }

        // for insert,update,delete
        public int Execute(string query, params SqlParameter[] parameters)
        {
            try
            {
                string connectionString = ConfigurationService.GetDbConnection();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters is not null)
                {
                    command.Parameters.AddRange(parameters);
                }

                var result = command.ExecuteNonQuery();
                connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
