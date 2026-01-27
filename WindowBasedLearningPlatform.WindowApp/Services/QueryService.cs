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

        public static string UpdateProgress()
        {
            return "UPDATE Tbl_UserLessonProgress SET IsRead = 1 WHERE LessonId=@lessonId AND UserId=@userId AND SectionCode=@code";
        }
        public static string SelectProgress()
        {
            return "Select * from Tbl_UserLessonProgress WHERE LessonId=@lessonId AND UserId=@userId AND SectionCode=@code";
        }

        public static string InsertProgress()
        {
            return @"INSERT INTO Tbl_UserLessonProgress (UserId,LessonId ,IsRead, IsCompleted,SectionCode ,CompletedDate)
                        VALUES (@userId,@lessonId,1,1,@code,GETDATE())";
        }

        public static string InsertTimeDuration()
        {
            return @"INSERT INTO Tbl_UserLessonTime (UserId, LessonId, MinutesLearned)
            VALUES (@userId, @lessonId, @minutes)";
        }

        public static string SelectDuration()
        {
            return @"Select * from Tbl_UserLessonTime where UserId = @userId and LessonId = @lessonId";
        }
        public static string UpdateTimeDuration()
        {
            return "UPDATE Tbl_UserLessonTime SET MinutesLearned =@minutes  WHERE LessonId=@lessonId AND UserId=@userId";
        }

        public static string SelectLessonsCount()
        {
            return "select count(*) from Tbl_Lessons where SectionCode = @code";
        }

        public static string SelectLessonComplete()
        {
            return "select count(*) from Tbl_UserLessonProgress where UserId = @userId and SectionCode=@code and IsCompleted = 1";
        }
    }
}
