using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowBasedLearningPlatform.WindowApp.Models.HelperModel;

namespace WindowBasedLearningPlatform.WindowApp.Models.UserModel
{
    public class UserResponseModel : ResponseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LoginPassword { get; set; }
    }
}
