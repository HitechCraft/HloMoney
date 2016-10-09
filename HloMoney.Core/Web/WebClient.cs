namespace HloMoney.Core.Web
{
    using System.Net;
    using System.Text;

    internal class WebClient
    {
        private static readonly System.Net.WebClient Client = CreateDefaultWebClient();

        internal static T GetResponseJson<T>(string url)
        {
            return Json.Deserialize<T>(GetResponseString(url));
        }

        internal static string GetResponseString(string url)
        {
            return Client.DownloadString(url);
        }
        
        internal static System.Net.WebClient CreateDefaultWebClient()
            => new System.Net.WebClient { Encoding = Encoding.UTF8 };
    }
}
