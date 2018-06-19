using EasyBooking.Models;
using EasyBooking.Services;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using EasyBooking.Data;
using EasyBooking.Models.ViewModels;
using Microsoft.AspNet.Identity;
using EasyBooking.RyanairDataCollectorService;

namespace EasyBooking.Controllers
{
    public class HomeController : Controller
    {
        private FlightDatabaseService flightDatabaseService = new FlightDatabaseService();

        private RyanairDataCollectorClient collectorService = new RyanairDataCollectorClient();

        public ActionResult Index()
        {
            ViewBag.countries = CityMaping.AiportsDictionary.Select(x => x.Key).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult SearchResults(string departureCity, string arrivalCity, DateTime fromDate, DateTime returnDate)
        {

            ViewBag.Source = departureCity;
            ViewBag.Dest = arrivalCity;
            var userId = User.Identity.GetUserId();

            if (DateTime.Compare(fromDate, DateTime.Today) > 0)
            {
                var ryanairFlights = collectorService.GetFromRyanair(fromDate, departureCity, arrivalCity, userId).ToList();
                flightDatabaseService.SaveFlights(ryanairFlights);

                if (!ryanairFlights.Any())
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
            var user = User.Identity.GetUserId();
            if (user != null)
            {
                return View(flightDatabaseService.GetAll().Where(flight =>
                {
                    if (flight.UserId != null)
                    {
                        return flight.UserId.Equals(user);
                    }
                    return false;
                }).ToList());

            }
            return View();

        }
    }
}