using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ValuteConverter.Models
{
    public class Header
    {
        [JsonProperty("Date")]
        public string Date { get; set; }
        [JsonProperty("PreviousDate")]
        public string PreviousDate { get; set; }
        [JsonProperty("PreviousURL")]
        public string PreviousURL { get; set; }
        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("Valute")]
        public object Valute { get; set; }
    }
}
