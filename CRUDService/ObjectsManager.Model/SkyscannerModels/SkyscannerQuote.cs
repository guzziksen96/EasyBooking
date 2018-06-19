using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.Model.SkyscannerModels
{
    class SkyskannerQuote
    {
        [JsonProperty("QuoteId")]
        public int QuoteIds { get; set; }

        [JsonProperty("MinPrice")]
        public decimal MinPrice { get; set; }

        [JsonProperty("Direct")]
        public bool Direct  {get; set; }

        [JsonProperty("InboundLeg")]
        public SkyscannerBoundLeg InboundLeg { get; set; }

        [JsonProperty("OutboundLeg")]
        public SkyscannerBoundLeg OutboundLeg { get; set; }

        [JsonProperty("QuoteDateTime")]
        public DateTimeOffset QuoteDataTime { get; set; }
    }
}
