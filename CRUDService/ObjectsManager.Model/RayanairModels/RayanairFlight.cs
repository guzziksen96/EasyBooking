using EasyBooking.Models;
using Newtonsoft.Json;
using ObjectsManager.Model.RayanairModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.Model
{
    public class RyanairFlight
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("departureAirport")]
        public RyanairAiport DepartureAirport { get; set; }

        [JsonProperty("arrivalAirport")]
        public RyanairAiport ArrivalAirport { get; set; }

        [JsonProperty("departureTime")]
        public FlightTime DepartureTime { get; set; }

        [JsonProperty("arrivalTime")]
        public FlightTime ArrivalTime { get; set; }

        [JsonProperty("status")]
        public FlightStatus Status { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}
