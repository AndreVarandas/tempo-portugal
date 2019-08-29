using System;
using Microsoft.AspNetCore.Hosting;

namespace IPMA.Web.Utils
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UsePort(this IWebHostBuilder builder)
        {
            var port = Environment.GetEnvironmentVariable("PORT");
            if (string.IsNullOrEmpty(port))
            {
                return builder;
            }

            return builder.UseUrls($"http://+:{port}");
        }
    }
}