using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuTestRestAPI.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Authentication
        {
            public const string RegisterUser = Base + "/user/register";
            public const string RegisterResturant = Base + "/restaurant/register";

            public const string LoginUser = Base + "/user/login";
            public const string LoginResturant = Base + "/restaurant/login";

            public const string RefreshToken = Base + "/token/refresh";

            public const string ResetPassword = Base + "/password/reset";

            public const string ResetPasswordUser = Base + "/password/reset/user";


            public const string ConfrimEmail = Base + "/email/confirm";


            public const string ChangePassword = Base + "/password/change";

        }

        public static class UserProfile
        {
            public const string GetAll = Base + "/user/profile/all";

            public const string Get = Base + "/user/profile/{profileId}";

            public const string Update = Base + "/user/profile/{profileId}";

            public const string Delete = Base + "/user/profile/{profileId}";
        }
 
        public static class CompareFiles
        {
            public const string CompareLiveDoc = Base + "/user/files/compare";
        }

        public static class History
        {
            public const string GetAllHistory = Base + "/history/all";
            public const string GetUserHistory = Base + "user/history/{profileId}";
            public const string GetHistoryDetails = Base + "history/{historyId}";
            public const string RerunComparism = Base + "/history/compare/{historyId}";
        }
    }
}
