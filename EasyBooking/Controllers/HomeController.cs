using EasyBooking.Models;
using EasyBooking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyBooking.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchResults(string departureCity, string arrivalCity, DateTime fromDate, DateTime returnDate)
        {
            ViewBag.Source = departureCity;
            ViewBag.Dest = arrivalCity;

            if (DateTime.Compare(fromDate, DateTime.Today) > 0)
            {
                var flights = db.Flights.Where(f => f.ArrivalCity == arrivalCity && f.DepartureCity == departureCity
                                                && f.DepartureDate == fromDate && f.ArrivalDate == returnDate).ToList();

                if (flights.Count() == 0)
                {
                    ViewBag.ScheduleMessage = "No flights on the entered date";

                }
                return View(flights);
            }
            else
            {
                ViewBag.ScheduleMessage = "Cannot book flights for requested date. Choose date after today";

                return View();
            }

        }
    }
}