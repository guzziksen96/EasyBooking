using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyBooking.Data;
using EasyBooking.Models.ViewModels;
using EasyBooking.Models;
using EasyBooking.RyanairDataCollectorService;

namespace EasyBooking.Services
{
    public class FlightDatabaseService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public List<FlightS> SaveFlights(List<FlightS> flights)
        {
           
            var result = flights.Select(f => db.Flights.Add(Map(f))).ToList();
            db.SaveChanges();

            return flights;
        }

        public List<FlightS> GetAll()
        {
            var tmp = db.Flights.ToList();
            var l = new List<FlightS>();
           foreach (var f in tmp)
            {
                l.Add(ReverseMap(f));
            }

            return l;
        }

        private Flight Map(FlightS f)
        {
            var result = new Flight
            {
                Id = f.Id,
                FlightCode = f.FlightCode,
                ArrivalCity = f.ArrivalCity,
                DepartureCity = f.DepartureCity,
                ArrivalDate = f.ArrivalDate,
                DepartureDate = f.DepartureDate,
                SeatsEconomyclass = f.SeatsEconomyclass,
                SeatsFirstclass = f.SeatsFirstclass,
                UserId = f.UserId
            };
            return result;
        }

        private FlightS ReverseMap(Flight db)
        {
            var result = new FlightS
            {
                Id = db.Id,
                FlightCode = db.FlightCode,
                ArrivalCity = db.ArrivalCity,
                DepartureCity = db.DepartureCity,
                ArrivalDate = db.ArrivalDate,
                DepartureDate = db.DepartureDate,
                SeatsEconomyclass = db.SeatsEconomyclass,
                SeatsFirstclass = db.SeatsFirstclass,
                UserId = db.UserId
            };
            return result;
        }
    }
}
