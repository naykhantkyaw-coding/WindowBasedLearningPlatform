using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBasedLearningPlatform.WindowApp.Models.LessonsModel
{
    public class LessonsRequestModel
    {
        public int LessonId { get; set; }
        public string LessonCode { get; set; }
        public string SectionCode { get; set; }
        public string LessonTitle { get; set; }
        public int SortOrder { get; set; }
    }
}
