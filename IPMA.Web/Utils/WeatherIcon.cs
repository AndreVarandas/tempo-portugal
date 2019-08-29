using System;

namespace IPMA.Web.Utils
{
    public static class WeatherIcon
    {
        public static string GetIconForWeather(int weatherId)
        {
            string resourceUrl;
            switch (weatherId)
            {
                case 0:
                case 1:
                case 2:
                    resourceUrl = "/images/forecast/sun.svg";
                    break;
                case 3:
                case 4:
                case 5:
                case 24:
                case 25:
                case 27:
                    resourceUrl = "/images/forecast/cloudy.svg";
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 21:
                case 22:
                    resourceUrl = "/images/forecast/rain.svg";
                    break;
                case 18:
                    resourceUrl = "/images/forecast/snow.svg";
                    break;
                case 19:
                case 23:
                    resourceUrl = "/images/forecast/storm.svg";
                    break;
                default:
                    resourceUrl = "/images/forecast/sun.svg";
                    break;
            }

            return resourceUrl;
        }
    }
}