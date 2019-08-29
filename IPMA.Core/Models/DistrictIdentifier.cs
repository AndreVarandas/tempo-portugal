using Newtonsoft.Json;

namespace IPMA.Core.Models
{
    public class DistrictIdentifier
    {
        [JsonProperty("idRegiao")]
        public int RegionId { get; set; }
        [JsonProperty("idAreaAviso")]
        public string WarningAreaId { get; set; }
        [JsonProperty("idConcelho")]
        public int CountyId { get; set; }
        [JsonProperty("globalIdLocal")]
        public int GlobalIdLocal { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("idDestrito")]
        public int DistrictId { get; set; }
        [JsonProperty("local")]
        public string Local { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}