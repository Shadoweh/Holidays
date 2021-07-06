using Newtonsoft.Json;

namespace Holidays.Api.Models
{
    public class HolidayNameModel
    {
        [JsonProperty("lang")]
        public string Language { get; set; }
        [JsonProperty("text")]
        public string Name { get; set; }
    }
}
