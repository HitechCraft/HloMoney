namespace HloMoney.Core.Web
{
    using System.Net;
    using System.Text;

    internal static class WebClientHelper
    {
        internal static T GetResponseJson<T>(string url)
        {
            return Json.Deserialize<T>(CreateDefaultWebClient().GetResponseString(url));
        }

        internal static string GetResponseString(this WebClient client, string url)
        {
            return client.DownloadString(url);
        }
        
        internal static System.Net.WebClient CreateDefaultWebClient()
            => new System.Net.WebClient { Encoding = Encoding.UTF8, Proxy = new WebProxy() };
    }
}
