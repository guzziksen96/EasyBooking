using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.Model.RayanairModels
{
    public class FlightTime
    {
        [JsonProperty("scheduled")]
        public string Scheduled { get; set; }

        [JsonProperty("estimated")]
        public string Estimated { get; set; }

        [JsonProperty("actual")]
        public string Actual { get; set; }
    }
}
