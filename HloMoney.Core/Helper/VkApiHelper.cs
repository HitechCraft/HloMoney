using System.Net;

namespace HloMoney.Core.Helper
{
    using System;
    using System.Linq;
    using Models.Json;
    using Web;

    public static class VkApiHelper
    {
        public static string AppId => "5636156";
        public static string AppSecret => "to5eyqJpczkGFb1k4Uux";
        public static string AppPermissions => "notify, friends, status, email";

        private static string ApiBaseUrl => "http://api.vk.com/";
        private static string ApiVersion => "5.53";
        private static string UserInfoFields => "bdate,photo_max,online";
        
        public static JsonVkUserInfo GetUsersInfo(string userIds)
        {
            return WebRequestExecutor.GetVkUserInfoResponse($"{ApiBaseUrl}method/users.get", userIds, UserInfoFields,
                ApiVersion);
        }
        
        public static JsonVkResponse GetUserResponce(string userId)
        {
            return GetUsersInfo(userId).response.First();
        }

        #region User Info

        public static string GetUserName(string userId)
        {
            try
            {
                var userInfo = GetUserResponce(userId);

                return $"{userInfo.first_name} {userInfo.last_name}";
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
        
        public static byte[] GetUserAvatar(string userId)
        {
            try
            {
                var webClient = new WebClient();

                return webClient.DownloadData(GetUserAvatarLink(userId));
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string GetUserAvatarLink(string userId)
        {
            try
            {
                var userInfo = GetUserResponce(userId);

                return $"{userInfo.photo_max}";
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
        #endregion
    }
}
