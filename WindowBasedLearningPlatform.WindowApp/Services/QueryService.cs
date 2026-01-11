using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    public static class QueryService
    {
        public static string CheckUserExit()
        {
            return "Select * from Tbl_User where UserName = @userName";
        }

        public static string InsertUser()
        {
            return "Insert into Tbl_User (UserName,LoginPassword) Values (@userName,@password)";
        }

        public static string LoadSection()
        {
            return "SELECT SectionId,SectionCode,SectionName FROM Tbl_Sections WHERE SectionCode = @scode ORDER BY SortOrder";
        }

        public static string LoadLesson()
        {
            return "SELECT LessonId, LessonCode,SectionCode,LessonTitle FROM Tbl_Lessons WHERE SectionCode = @scode and SectionId=@sid ORDER BY SortOrder";
        }

        public static string LoadLessonContent()
        {
            return "SELECT ContentType, ContentBody FROM Tbl_LessonContents WHERE LessonCode = @lcode and LessonId =@lid";
        }
    }
}
