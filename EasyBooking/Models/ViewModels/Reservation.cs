using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyBooking.Models.ViewModels
{

    public class Reservation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Price { get; set; }
        public int FlightClassNumber { get; set;  }
        public virtual ScheduleFlight Flight { get; set; }
        public virtual RyanairSchedule Schedule { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual User User { get; set; }
    }
}