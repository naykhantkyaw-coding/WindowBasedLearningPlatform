using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBasedLearningPlatform.WindowApp.Models.LessonsModel
{
    public class LessonContentsRequestModel
    {
        public int ContentId { get; set; }
        public string LessonCode { get; set; }
        public string ContentType { get; set; }
        public string ContentBody { get; set; }
    }
}
