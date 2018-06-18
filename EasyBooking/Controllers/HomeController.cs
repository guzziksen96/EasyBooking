using EasyBooking.Models;
using EasyBooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EasyBooking.Data;
using EasyBooking.Models.ViewModels;

namespace EasyBooking.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.countries  = CityMaping.AiportsDictionary.Select(x => x.Key).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult SearchResults(string departureCity, string arrivalCity, DateTime fromDate, DateTime returnDate)
        {
            //departureCity = "PALMA DE MALLORCA";
                //arrivalCity = "DUBLIN";
            DataCollector collector = new DataCollector();
            var ryanairFlights = collector.GetFromRyanair(fromDate, departureCity, arrivalCity);


            ViewBag.Source = departureCity;
            ViewBag.Dest = arrivalCity;

            if (DateTime.Compare(fromDate, DateTime.Today) > 0)
            {
                //var flights = db.Flights.Where(f => f.ArrivalCity == arrivalCity && f.DepartureCity == departureCity
                //                                && f.DepartureDate == fromDate && f.ArrivalDate == returnDate).ToList();

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
    }
}