using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowBasedLearningPlatform.WindowApp.Models.QuizModel;

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

            public static List<QuizQuestion> GetQuizzesForLesson(int lessonId)
        {
            var quizzes = new List<QuizQuestion>();

            // Ensure you use your actual connection string logic
            using (SqlConnection conn = new SqlConnection(ConfigurationService.GetDbConnection()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Tbl_QuizzData WHERE LessonID = @lid";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@lid", lessonId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                quizzes.Add(new QuizQuestion
                                {
                                    QuizID = (int)reader["QuizID"],
                                    LessonID = (int)reader["LessonID"],
                                    QuestionText = reader["QuestionText"].ToString(),
                                    OptionA = reader["OptionA"].ToString(),
                                    OptionB = reader["OptionB"].ToString(),
                                    OptionC = reader["OptionC"].ToString(),
                                    OptionD = reader["OptionD"].ToString(),
                                    CorrectOption = reader["CorrectOption"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log error
                    System.Diagnostics.Debug.WriteLine("Quiz Fetch Error: " + ex.Message);
                }
            }
            return quizzes;
        }
    }
    }

