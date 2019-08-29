using Newtonsoft.Json;

namespace IPMA.Core.Models
{
    public class WindType
    {
        [JsonProperty("descClassWindSpeedDailyEN")]
        public string WindSpeedDescriptionDailyEn { get; set; }
        [JsonProperty("descClassWindSpeedDailyPT")]
        public string WindSpeedDescriptionDailyPt { get; set; }
        [JsonProperty("classWindSpeed")]
        public int WindSpeedClass { get; set; }
    }
}