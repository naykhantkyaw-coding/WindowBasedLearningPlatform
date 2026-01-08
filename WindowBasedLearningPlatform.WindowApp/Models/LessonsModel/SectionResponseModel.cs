using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowBasedLearningPlatform.WindowApp.Models.HelperModel;

namespace WindowBasedLearningPlatform.WindowApp.Models.LessonsModel
{
    public class SectionResponseModel : ResponseModel
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int SortOrder { get; set; }
        public string SectionCode { get; set; }
    }
}
