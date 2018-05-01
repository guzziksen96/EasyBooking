using EasyBooking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EasyBooking.Data
{
    public class EasyBookingDbContext : DbContext
    {
            public EasyBookingDbContext() : base("EasyBookingDbContext")
            {

            }
            public static EasyBookingDbContext Create()
            {
                return new EasyBookingDbContext();
            }
        
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}