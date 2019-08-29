using Newtonsoft.Json;

namespace IPMA.Core.Models
{
    public class WeatherType
    {
        [JsonProperty("descIdWeatherTypeEN")]
        public string WeatherTypeDescriptionEn { get; set; }
        [JsonProperty("descIdWeatherTypePT")]
        public string WeatherTypeDescriptionPt { get; set; }
        [JsonProperty("idWeatherType")]
        public int WeatherTypeId { get; set; }
    }
}