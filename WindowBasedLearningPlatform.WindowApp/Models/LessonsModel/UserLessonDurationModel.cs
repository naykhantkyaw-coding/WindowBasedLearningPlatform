using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBasedLearningPlatform.WindowApp.Models.LessonsModel
{
    public class UserLessonDurationModel
    {
        public int UserLessonTimeId { get; set; }
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public int MinutesLearned { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
