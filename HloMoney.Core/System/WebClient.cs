namespace HloMoney.Core.System
{
    using global::System.Net;
    using global::System.Text;

    internal class WebClient
    {
        private static readonly global::System.Net.WebClient Client = CreateDefaultWebClient();

        internal static T GetResponseJson<T>(string url)
        {
            return Json.Deserialize<T>(GetResponseString(url));
        }

        internal static string GetResponseString(string url)
        {
            return Client.DownloadString(url);
        }
        
        internal static global::System.Net.WebClient CreateDefaultWebClient()
            => new global::System.Net.WebClient { Encoding = Encoding.UTF8, Proxy = new WebProxy() };
    }
}
