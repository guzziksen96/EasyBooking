using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyBooking.Models.ViewModels
{
    [Table("reservations")]
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Flight Flight { get; set; }
        public string TravelType { get; set; }
        public int FirstClassRemainingSeats { get; set; } 
        public int EconomyClassRemainingSeats { get; set; } 
        public double FirstClassPrice { get; set; }
        public double EconomyClassPrice { get; set; }
        

    }
}