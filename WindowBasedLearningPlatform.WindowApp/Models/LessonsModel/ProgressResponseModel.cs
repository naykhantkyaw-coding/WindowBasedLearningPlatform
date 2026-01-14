using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBasedLearningPlatform.WindowApp.Models.LessonsModel
{
    public class ProgressResponseModel
    {
        public int ProgressId { get; set; }
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public bool IsRead { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
