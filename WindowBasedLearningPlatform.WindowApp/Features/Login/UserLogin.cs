using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowBasedLearningPlatform.WindowApp.Models.UserModel;
using WindowBasedLearningPlatform.WindowApp.Services;

namespace WindowBasedLearningPlatform.WindowApp.Features.Login
{
    public static class UserLogin
    {
        public static UserResponseModel CheckUserExist(UserRequestModel reqModel)
        {
            UserResponseModel model = new UserResponseModel();
            var db = new DatabaseService();
            var userName = reqModel.UserName?.Trim();

            var checkParams = new[]
            {
                new SqlParameter("@userName", userName)
            };

            var userList = db.Query<UserResponseModel>(
                QueryService.CheckUserExit(),
                checkParams
            );

            // User exists
            if (userList.Count > 0)
            {
                var userResult = userList[0];
                if (userResult.LoginPassword != reqModel.Password)
                {
                    model.IsSuccess = false;
                    model.Message = "User Name or Password is wrong!";
                    return model;
                }

                userResult.IsSuccess = true;
                userResult.Message = "Success";
                return userResult;
            }

            var insertParams = new[]
            {
                new SqlParameter("@userName", userName),
                new SqlParameter("@password", reqModel.Password?.Trim())
            };

            db.Execute(QueryService.InsertUser(), insertParams);

            model.IsSuccess = true;
            model.Message = "User created successfully";
            return model;
        }

    }
}
