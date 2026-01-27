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
        public static ResponseModel UpdateUserProgress(int lessonsId, int userId, string code)
        {
            ResponseModel model = new ResponseModel();
            var db = new DatabaseService();
            var parameter = new[]
            {
                new SqlParameter("@lessonId", lessonsId),
                new SqlParameter("@userId", userId),
                new SqlParameter("@code", code),
            };
            var selectResult = db.Query<ProgressResponseModel>(QueryService.SelectProgress(), parameter);

            if (selectResult.Count == 0)
            {
                var insertParameter = new[]
                {
                new SqlParameter("@lessonId", lessonsId),
                new SqlParameter("@userId", userId),
                new SqlParameter("@code", code),
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
                 new SqlParameter("@code", code),
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

        public static ResponseModel AddTime(int lessonId, int userId, int minutes)
        {
            ResponseModel model = new ResponseModel();
            var db = new DatabaseService();
            var parameter = new[]
            {
                new SqlParameter("@lessonId", lessonId),
                new SqlParameter("@userId", userId),
                new SqlParameter("@minutes", minutes),
            };

            var selectResult = db.Query<UserLessonDurationModel>(QueryService.SelectDuration(), parameter);
            if (selectResult.Count == 0)
            {
                var insertParameter = new[]
            {
                new SqlParameter("@lessonId", lessonId),
                new SqlParameter("@userId", userId),
                new SqlParameter("@minutes", minutes),
            };
                var result = db.Execute(QueryService.InsertTimeDuration(), insertParameter);
                if (result == 1)
                {
                    model.IsSuccess = true;
                    model.Message = "Progress Time Insert Complete";
                }
            }
            else
            {
                var updateParameter = new[]
        {
                new SqlParameter("@lessonId", lessonId),
                new SqlParameter("@userId", userId),
                new SqlParameter("@minutes", minutes),
            };
                var result = db.Execute(QueryService.UpdateTimeDuration(), updateParameter);
                if (result == 1)
                {
                    model.IsSuccess = true;
                    model.Message = "Progress Time Update Complete";
                }
            }

            return model;
        }

        public static int ProgressBar(int userId, string code)
        {
            int result = 0;
            int total = 0;
            int complete = 0;
            var db = new DatabaseService();

            var parameter = new[]
            {
                new SqlParameter("@code", code),
            };
            var lessonsCount = db.ExecuteScalar(QueryService.SelectLessonsCount(), parameter);
            total = Convert.ToInt32(lessonsCount);
            var lessonComplete = new[]
            {
                new SqlParameter("@code", code),
                new SqlParameter("@userId", userId),
            };
            var completeCount = db.ExecuteScalar(QueryService.SelectLessonComplete(), lessonComplete);
            complete = Convert.ToInt32(completeCount);
            result = (complete * 100) / total;
            return result;
        }



    }
}
