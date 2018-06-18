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

namespace EasyBooking.Services
{
    public class FlightDatabaseService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public List<Flight> SaveFlights(List<Flight> flights)
        {
            var result = flights.Select(f => db.Flights.Add(f)).ToList();
            db.SaveChanges();
            return result;
        }

        public List<Flight> GetAll()
        {
            return db.Flights.ToList();
        }
    }
}
