using HloMoney.Core.Models.Json;

namespace HloMoney.Core.Helper
{
    public static class VkApiHelper
    {
        public static string AppId => "5636156";
        public static string AppSecret => "to5eyqJpczkGFb1k4Uux";
        public static string AppPermissions => "notify, friends, status, email";

        private static string ApiBaseUrl => "http://api.vk.com/";
        private static string ApiVersion => "5.53";
        private static string UserInfoFields => "bdate,photo_200_orig,online";

        public static JsonVkUserInfo GetUserInfo(string userIds)
        {
            return WebRequestExecutor.GetVkUserInfoResponse($"{ApiBaseUrl}method/users.get", userIds, UserInfoFields,
                ApiVersion);
        }
    }
}
