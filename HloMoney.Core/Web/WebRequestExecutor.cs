using HloMoney.Core.Extentions;
using HloMoney.Core.Models.Json;

namespace HloMoney.Core.Web
{
    public static class WebRequestExecutor
    {
        public static JsonVkUserInfo GetVkUserInfoResponse(string url, string userIds, string fields, string version)
        {
            var request =
                $"{url}"
                .AddParam("user_ids", userIds)
                .AddParam("fields", fields)
                .AddParam("v", version)
                .AddParam("lang", "ru");

            return WebClientHelper.GetResponseJson<JsonVkUserInfo>(request);
        }
    }
}
