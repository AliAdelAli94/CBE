namespace CBE.Feature.Accounts.Services
{
    public class WebClient : IWebClient
    {
        public byte[] DownloadData(string address)
        {
            var realWebClient = new System.Net.WebClient();
            return realWebClient.DownloadData(address);
        }
    }
}