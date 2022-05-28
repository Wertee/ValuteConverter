using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuteConverter.Models
{
    public class CountValueModel
    {
        public string FirstValuteName { get; set; }
        public int FirstValuteCount { get; set; }
        public string SecondValuteName { get; set; }
        public decimal Result { get; set; }
    }
}
