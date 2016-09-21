using HloMoney.Core.Extentions;
using HloMoney.Core.Models.Json;
using HloMoney.Core.System;

namespace HloMoney.Core
{
    public static class WebRequestExecutor
    {
        public static JsonVkUserInfo GetVkUserInfoResponse(string url, string userIds, string fields, string version)
        {
            var request =
                $"{url}"
                .AddParam("user_ids", userIds)
                .AddParam("fields", fields)
                .AddParam("v", version);

            return WebClient.GetResponseJson<JsonVkUserInfo>(request);
        }
    }
}
