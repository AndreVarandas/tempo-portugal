using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPMA.Core.Communications;
using IPMA.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPMA.Core
{
    public class Ipma : IIpma
    {
        public IEnumerable<WeatherType> WeatherTypes { get; set; }
        public IEnumerable<WindType> WindTypes { get; set; }
        
        private static readonly string DistrictIdentifierUrl = "http://api.ipma.pt/open-data/distrits-islands.json";
        private static readonly string WeatherTypesUrl = "http://api.ipma.pt/open-data/weather-type-classe.json";
        private static readonly string WindTypeUrl = "http://api.ipma.pt/open-data/wind-speed-daily-classe.json";
        private static readonly string DaiyCityForecastUrl = "http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/";
        private static readonly string GlobalDailyForecastUrl =
            "http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/hp-daily-forecast-day";

        /// <summary>
        /// Creates and returns a new Ipma instance.
        /// </summary>
        /// <returns></returns>
        public static async Task<Ipma> Create()
        {
            var ipma = new Ipma();
            await ipma.Initialize();
            return ipma;
        }

        /// <summary>
        /// Initializes a new instance of Ipma.cs
        /// This is needed to asynchronously populate the Weather and Wind Types.
        /// </summary>
        /// <returns></returns>
        private async Task Initialize()
        {
            WeatherTypes = await GetWeatherTypes();
            WindTypes = await GetWindTypes();
        }
        
        /// <summary>
        /// Makes constructor private, a new instance of Ipma should be created
        /// only using the static async method Ipma.Create().
        /// </summary>
        private Ipma()
        {
            
        }

        /// <summary>
        /// Gets a list of district identifiers.
        /// </summary>
        /// <returns>DistrictIdentifier[]</returns>
        public async Task<IEnumerable<DistrictIdentifier>> GetDistrictIdentifiers()
        {
            var response = await GetHttpResponseFor(DistrictIdentifierUrl);
            var districtIdentifiers = JsonConvert.DeserializeObject <IEnumerable<DistrictIdentifier>>(response);

            return districtIdentifiers;
        }

        /// <summary>
        /// Gets a list of weather types.
        /// </summary>
        /// <returns>WeatherType[]</returns>
        public async Task<IEnumerable<WeatherType>> GetWeatherTypes()
        {
            var response = await GetHttpResponseFor(WeatherTypesUrl);
            var weatherTypes = JsonConvert.DeserializeObject <IEnumerable<WeatherType>>(response);
            
            return weatherTypes;
        }

        /// <summary>
        /// Gets a list of wind types.
        /// </summary>
        /// <returns>WindType[]</returns>
        public async Task<IEnumerable<WindType>> GetWindTypes()
        {
            var response = await GetHttpResponseFor(WindTypeUrl);
            var windTypes = JsonConvert.DeserializeObject <IEnumerable<WindType>>(response);
            
            return windTypes;
        }

        /// <summary>
        /// From a forecast, get weather details.
        /// </summary>
        /// <param name="forecast">The forecast to get the details from.</param>
        /// <returns>WeatherType</returns>
        public WeatherType GetWeatherDetailsForForecast(Forecast forecast)
        {
            return WeatherTypes.First(w => w.WeatherTypeId == forecast.WeatherTypeId);
        }

        /// <summary>
        /// From a forecast, find wind details.
        /// </summary>
        /// <param name="forecast">The forecast to get details from.</param>
        /// <returns>WindType</returns>
        public WindType GetWindDetailsForForecast(Forecast forecast)
        {
            return WindTypes.First(w => w.WindSpeedClass == forecast.WindSpeedClass);
        }

        /// <summary>
        /// Gets 5 days forecast for a district ID.
        /// </summary>
        /// <param name="districts">The district identifier</param>
        /// <returns>LocalForecast[]</returns>
        public async Task<IEnumerable<Forecast>> GetForecastForLocation(Districts districts)
        {
            var requestUrl = DaiyCityForecastUrl + (int)districts + ".json";
            var response = await GetHttpResponseFor(requestUrl);
            var localForecast = JsonConvert.DeserializeObject <IEnumerable<Forecast>>(response);
            
            return localForecast;
        }

        /// <summary>
        /// Daily Weather Forecast up to 3 days, aggregated information per day.
        /// Results are global, containing the ids of the district.
        /// </summary>
        /// <param name="day">0, 1 or 2. Meaning today, tomorrow, or after</param>
        /// <returns>WeatherForecast[]</returns>
        public async Task<IEnumerable<Forecast>> GetForecastsForDay(string day)
        {
            var requestUrl = GlobalDailyForecastUrl + day + ".json";
            var response = await GetHttpResponseFor(requestUrl);
            var globalForecast = JsonConvert.DeserializeObject <IEnumerable<Forecast>>(response);

            return globalForecast;
        }
        
        /// <summary>
        /// Returns a forecast that matches the location id, from a list of forecasts.
        /// </summary>
        /// <param name="forecasts">The forecasts list to search.</param>
        /// <param name="locationId">The location id to match.</param>
        /// <returns></returns>
        public Forecast GetForecastFromForecasts(IEnumerable<Forecast> forecasts, Districts locationId)
        {
            return forecasts.First(f => f.LocationId == locationId);
        }

        /// <summary>
        /// Fetches a json resource from an Url.
        /// </summary>
        /// <param name="url">The url to request.</param>
        /// <returns></returns>
        private static async Task<string> GetHttpResponseFor(string url)
        {
            var response = await Http.GetUrl(url);
            var parsedObject = JObject.Parse(response);
            var responseData = parsedObject["data"].ToString();

            return responseData;
        }
    }
}