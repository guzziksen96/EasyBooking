using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ObjectsManager.Model;

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