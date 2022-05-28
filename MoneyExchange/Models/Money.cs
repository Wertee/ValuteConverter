using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ValuteConverter.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Money
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("NumCode")]
        public string NumCode { get; set; }
        [JsonProperty("CharCode")]
        public string CharCode { get; set; }
        [JsonProperty("Nominal")]
        public int Nominal { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Value")]
        public decimal Value { get; set; }
        [JsonProperty("Previous")]
        public decimal Previous { get; set; }

    }
}
