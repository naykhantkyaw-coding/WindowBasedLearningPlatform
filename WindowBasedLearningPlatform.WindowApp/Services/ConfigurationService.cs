using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    public class ConfigurationService
    {
        public static string GetDbConnection()
        {
            string connectionString = string.Empty;
            JObject obj = new JObject();
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "customsetting.json");
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    obj = JObject.Parse(json);

                    connectionString = obj["ConnectionStrings"]["DefaultConnection"].ToString();
                }
            }
            catch (Exception ex)
            {
            }

            return connectionString;
        }
    }
}
