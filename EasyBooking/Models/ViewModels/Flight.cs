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
        public Flight(RyanairFlight rf, DateTime arrivalDate)
        {
            this.Id = rf.Number;
            this.FlightCode = rf.Number.ToString();
            //this.DepartureDate = 
            var time = rf.ArrivalTime.Scheduled.Split(':');

            ArrivalDate= new DateTime(
                arrivalDate.Year,
                arrivalDate.Month,
                arrivalDate.Day,
                int.Parse(time[0]),
                int.Parse(time[1]),
                0,
                0,
                arrivalDate.Kind
             );
            this.DepartureCity = rf.DepartureAirport.Name;
            this.ArrivalCity = rf.ArrivalAirport.Name;
            this.SeatsFirstclass = 13;
            this.SeatsEconomyclass = 100;
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