using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowBasedLearningPlatform.WindowApp.Models.LessonsModel;
using WindowBasedLearningPlatform.WindowApp.Models.UserModel;
using WindowBasedLearningPlatform.WindowApp.Services;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowBasedLearningPlatform.WindowApp.Features.Lessons
{
    public static class SelectedLessons
    {
        public static List<SectionResponseModel> LoadSidebar(string code)
        {
            List<SectionResponseModel> model = new List<SectionResponseModel>();
            var db = new DatabaseService();
            var parameter = new[]
           {
                new SqlParameter("@scode", code),
            };
            var sectionList = db.Query<SectionResponseModel>(
               QueryService.LoadSection(), parameter);
            if (sectionList is not null && sectionList.Count > 0)
            {
                model.AddRange(sectionList);
            }
            return model;
        }

        public static LessonsResponseModel LoadLessons(string sectionCode, int sectionId)
        {
            LessonsResponseModel model = new LessonsResponseModel();
            var db = new DatabaseService();
            var parameter = new[]
            {
                new SqlParameter("@scode", sectionCode),
                new SqlParameter("@sid", sectionId)
            };
            var item = db.QueryFirstOrDefault<LessonsResponseModel>(
             QueryService.LoadLesson(), parameter);
            if (item is not null)
            {
                model = item;
            }
            return model;

        }

        public static LessonContentsResponseModel LoadLessonContent(string lessonCode, int lessonId)
        {
            LessonContentsResponseModel model = new LessonContentsResponseModel();
            var db = new DatabaseService();
            var parameter = new[]
            {
                new SqlParameter("@lcode", lessonCode),
                new SqlParameter("@lid", lessonId)
            };
            var item = db.QueryFirstOrDefault<LessonContentsResponseModel>(
            QueryService.LoadLessonContent(), parameter);
            if (item is not null)
            {
                model = item;
            }
            return model;
        }
    }
}
