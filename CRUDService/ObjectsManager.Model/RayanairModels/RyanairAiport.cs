using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.Model.RayanairModels
{
    public class RyanairAiport
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
