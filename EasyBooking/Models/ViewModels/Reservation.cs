using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyBooking.Models.ViewModels
{
    public enum FlightClass { Economy, First }
    [Table("reservations")]
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Flight")]
        public int flightId { get; set; }
        [ForeignKey("Payment")]
        public int paymentId { get; set; }
        public int Price { get; set; }
        public int FlightClassNumber { get; set;  }
        public virtual Flight Flight { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Payment Payment { get; set; }
    }
}