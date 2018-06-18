using EasyBooking.Models;
using EasyBooking.Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EasyBooking.Controllers
{
    public class HomeController : Controller
    {
        private FlightDatabaseService flightDatabaseService = new FlightDatabaseService();
        private DataCollector collector = new DataCollector();
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SearchResults(string departureCity, string arrivalCity, DateTime fromDate, DateTime returnDate)
        {
            departureCity = "KATOWICE";
            arrivalCity = "Kraków";

            ViewBag.Source = departureCity;
            ViewBag.Dest = arrivalCity;

            if (DateTime.Compare(fromDate, DateTime.Today) > 0)
            {
                //var flights = db.Flights.Where(f => f.ArrivalCity == arrivalCity && f.DepartureCity == departureCity
                //                                && f.DepartureDate == fromDate && f.ArrivalDate == returnDate).ToList();
                var ryanairFlights = collector.GetFromRyanair(fromDate, departureCity, arrivalCity);
                flightDatabaseService.SaveFlights(ryanairFlights);

                if (ryanairFlights.Count() == 0)
                {
                    ViewBag.ScheduleMessage = "No flights on the entered date";
                }
                return View(ryanairFlights);
            }
            else
            {
                ViewBag.ScheduleMessage = "Cannot book flights for requested date. Choose date after today";
                return View();
            }

        }


        [HttpGet]
        public ActionResult GetAll()
        {
            return View(flightDatabaseService.GetAll());

        }
    }
}