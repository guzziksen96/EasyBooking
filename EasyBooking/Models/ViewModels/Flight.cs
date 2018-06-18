using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyBooking.Models.ViewModels
{
    public class Flight
    {

        public Flight()
        { }
        public Flight(RyanairFlight rf, DateTime arrivalDate)
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
            this.DepartureCity = rf.DepartureAirport.Name;
            this.ArrivalCity = rf.ArrivalAirport.Name;
            this.SeatsFirstclass = Faker.RandomNumber.Next(5,20);
            this.SeatsEconomyclass = Faker.RandomNumber.Next(20, 60);
        }

        public int Id { get; set; }
        public string FlightCode { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public String DepartureCity { get; set; }
        public String ArrivalCity { get; set; }
        public int SeatsFirstclass { get; set; }
        public int SeatsEconomyclass { get; set; }
    }
}