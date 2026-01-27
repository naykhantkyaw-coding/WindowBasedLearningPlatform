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

        public object? ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            string connectionString = ConfigurationService.GetDbConnection();
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand(query, connection);

            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command.ExecuteScalar();
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
        // In DatabaseService.cs

        public static void SaveQuizProgress(int studentId, int lessonId, int score)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationService.GetDbConnection()))
            {
                try
                {
                    conn.Open();
                    // Check if record exists
                    string checkQuery = "SELECT Count(*) FROM Tbl_ProgressRecords WHERE StudentId = @sid AND LessonId = @lid";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@sid", studentId);
                    checkCmd.Parameters.AddWithValue("@lid", lessonId);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Update existing
                        string updateQuery = "UPDATE Tbl_ProgressRecords SET QuizScore = @score, LastAccessed = GETDATE() WHERE StudentId = @sid AND LessonId = @lid";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@score", score);
                        updateCmd.Parameters.AddWithValue("@sid", studentId);
                        updateCmd.Parameters.AddWithValue("@lid", lessonId);
                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insert new
                        string insertQuery = "INSERT INTO Tbl_ProgressRecords (StudentId, LessonId, QuizScore, IsCompleted, LastAccessed) VALUES (@sid, @lid, @score, 1, GETDATE())";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@score", score);
                        insertCmd.Parameters.AddWithValue("@sid", studentId);
                        insertCmd.Parameters.AddWithValue("@lid", lessonId);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Log error
                    System.Diagnostics.Debug.WriteLine("Error saving progress: " + ex.Message);
                }
            }
        }
    }
}

