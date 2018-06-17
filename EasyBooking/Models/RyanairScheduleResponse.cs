using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EasyBooking.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RyanairSchedule
    {
        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("days")]
        public List<ScheduleDay> Days { get; set; }
    }

    public partial class ScheduleDay
    {
        [JsonProperty("day")]
        public int DayDay { get; set; }

        [JsonProperty("flights")]
        public List<ScheduleFlight> ScheduleFlights { get; set; }
    }

    public partial class ScheduleFlight
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("departureTime")]
        public string DepartureTime { get; set; }

        [JsonProperty("arrivalTime")]
        public string ArrivalTime { get; set; }
    }

    public partial class DeserializeRyanairScheduleResponseConverter
    {
        public static RyanairSchedule FromJson(string json) => JsonConvert.DeserializeObject<RyanairSchedule>(json, EasyBooking.Models.RyanairScheduleResponseConverter.Settings);
    }

    public static class SerializeRyanairScheduleResponseConverter
    {
        public static string ToJson(this RyanairSchedule self) => JsonConvert.SerializeObject(self, EasyBooking.Models.RyanairScheduleResponseConverter.Settings);
    }

    internal static class RyanairScheduleResponseConverter
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

