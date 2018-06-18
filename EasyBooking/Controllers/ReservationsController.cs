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

namespace EasyBooking.Controllers
{
    //[Authorize]
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations
        public async Task<ActionResult> Index()
        {
            var reservations = db.Reservations.Include(r => r.Flight).Include(r => r.Payment);
            return View(await reservations.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }


        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.flightId = new SelectList(db.Flights, "Id", "FlightCode");
            ViewBag.paymentId = new SelectList(db.Payments, "Id", "Mode");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,flightId,paymentId,Price,FlightClassNumber")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,flightId,paymentId,Price,FlightClassNumber")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reservation reservation = await db.Reservations.FindAsync(id);
            db.Reservations.Remove(reservation);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetDepartureCity(string search)
        {
            
            return Json(search, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> GetArrivalCity(string search)
        {

            return Json(search, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> GetFromDateTime(DateTime fromDate)
        {
           // List<Flight> flights = await db.Flights.ToListAsync();
        //    var flightsFromDate = flights.Where(f => f.DepartureDate.CompareTo(fromDate) >= 0);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetReturnDateTime(DateTime returnDate)
        {
           // List<Flight> flights = await db.Flights.ToListAsync();
          //  var flightsBeforeDate = flights.Where(f => f.ArrivalDate.CompareTo(returnDate) <= 0);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
