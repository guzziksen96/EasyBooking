using ObjectsManager.Model;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EasyBooking.Models.ViewModels
{
    [Serializable]
    [DataContract]
    public class FlightS
    {
        public FlightS() { }

        public FlightS(RyanairFlight rf, DateTime arrivalDate, string UserId)
        {
            this.Id = rf.Number;
            this.FlightCode = rf.Number.ToString();

            var dTime = rf.DepartureTime.Scheduled.Split(':');
            this.DepartureDate = new DateTime(
                arrivalDate.Year,
                arrivalDate.Month,
                arrivalDate.Day,
                int.Parse(dTime[0]),
                int.Parse(dTime[1]),
                0,
                0,
                arrivalDate.Kind
             );

            var aTime = rf.ArrivalTime.Scheduled.Split(':');
            this.ArrivalDate = new DateTime(
                arrivalDate.Year,
                arrivalDate.Month,
                arrivalDate.Day,
                int.Parse(aTime[0]),
                int.Parse(aTime[1]),
                0,
                0,
                arrivalDate.Kind
             );
            Random rnd = new Random();
            this.DepartureCity = rf.DepartureAirport.Name;
            this.ArrivalCity = rf.ArrivalAirport.Name;
            this.SeatsFirstclass = rnd.Next(5, 20);
            this.SeatsEconomyclass = rnd.Next(20, 60);
            this.UserId = UserId;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FlightCode { get; set; }
        [DataMember]
        public DateTime DepartureDate { get; set; }
        [DataMember]
        public DateTime ArrivalDate { get; set; }
        [DataMember]
        public String DepartureCity { get; set; }
        [DataMember]
        public String ArrivalCity { get; set; }
        [DataMember]
        public int SeatsFirstclass { get; set; }
        [DataMember]
        public int SeatsEconomyclass { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}