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
    }
}
