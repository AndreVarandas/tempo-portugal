using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IPMA.Core.Communications
{
    public static class Http
    {
        public static async Task<string> GetUrl(string url)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    return await httpClient.GetStringAsync(url);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}