using System;
using Newtonsoft.Json;

namespace IPMA.Core.Models
{
    public class Forecast
    {
        [JsonProperty("precipitaProb")]
        public string RainProbability { get; set; }
        [JsonProperty("tMin")]
        public string MinimumTemperature { get; set; }
        [JsonProperty("tMax")]
        public string MaximumTemperature { get; set; }
        [JsonProperty("predWindDir")]
        public string WindDirection { get; set; }
        [JsonProperty("idWeatherType")]
        public int WeatherTypeId { get; set; }
        [JsonProperty("classWindSpeed")]
        public int WindSpeedClass { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("forecastDate")]
        public string ForecastDate { get; set; }
        [JsonProperty("globalIdLocal")]
        public Districts LocationId { get; set; }

        public WeatherType Weather { get; set; }
        public WindType Wind { get; set; }

        public string Icon { get; set; }
    }
}