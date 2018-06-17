using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EasyBooking.Models
{
    public class RyanairResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("flights")]
        public List<RyanairFlight> Flights { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("punctuality")]
        public long Punctuality { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }


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

    public class RyanairAiport
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class FlightTime
    {
        [JsonProperty("scheduled")]
        public string Scheduled { get; set; }

        [JsonProperty("estimated")]
        public string Estimated { get; set; }

        [JsonProperty("actual")]
        public string Actual { get; set; }
    }

    public class FlightStatus
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("detailedMessage")]
        public string DetailedMessage { get; set; }

    }



    public partial class DeserializeRyanairResponse
    {
        public static RyanairResponse FromJson(string json) => JsonConvert.DeserializeObject<RyanairResponse>(json, EasyBooking.Models.Converter.Settings);
    }

    public static class SerializeRyanairResponse
    {
        public static string ToJson(this RyanairResponse self) => JsonConvert.SerializeObject(self, EasyBooking.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    

}