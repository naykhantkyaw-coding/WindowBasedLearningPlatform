using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowBasedLearningPlatform.WindowApp.Models.HelperModel;
using WindowBasedLearningPlatform.WindowApp.Models.LessonsModel;
using WindowBasedLearningPlatform.WindowApp.Services;

namespace WindowBasedLearningPlatform.WindowApp.Features.Lessons
{
    public static class UserProgress
    {
        public static ResponseModel UpdateUserProgress(int lessonsId, int userId)
        {
            ResponseModel model = new ResponseModel();
            var db = new DatabaseService();
            var parameter = new[]
            {
                new SqlParameter("@lessonId", lessonsId),
                new SqlParameter("@userId", userId),
            };
            var selectResult = db.Query<ProgressResponseModel>(QueryService.SelectProgress(), parameter);

            if (selectResult.Count == 0)
            {
                var insertParameter = new[]
                {
                new SqlParameter("@lessonId", lessonsId),
                new SqlParameter("@userId", userId),
                };
                var result = db.Execute(QueryService.InsertProgress(), insertParameter);
                if (result == 1)
                {
                    model.IsSuccess = true;
                    model.Message = "Progress Insert Complete";
                }
            }
            else
            {
                var updateParameter = new[]
                {
                new SqlParameter("@lessonId", lessonsId),
                new SqlParameter("@userId", userId),
                };
                var result = db.Execute(QueryService.UpdateProgress(), updateParameter);
                if (result == 1)
                {
                    model.IsSuccess = true;
                    model.Message = "Progress Update Complete";
                }
            }
            return model;
        }
    }
}
