using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.Model.SkyscannerModels
{
    class SkyscannerBoundLeg
    {
        [JsonProperty("CarrierIds")]
        public List<int> CarrierIds { get; set; }

        [JsonProperty("OriginId")]
        public int OriginId { get; set; }

        [JsonProperty("DestinationId")]
        public int DestinationId { get; set; }

        [JsonProperty("DepartureDate")]
        public DateTimeOffset DepartureDate { get; set; }
    }
}
