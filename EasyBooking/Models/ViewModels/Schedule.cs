using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyBooking.Models.ViewModels
{
    [Table("schedules")]
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public int FirstClassRemainingSeats { get; set; }
        public int EconomyClassRemainingSeats { get; set; }
        public double FirstClassPrice { get; set; }
        public double EconomyClassPrice { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}