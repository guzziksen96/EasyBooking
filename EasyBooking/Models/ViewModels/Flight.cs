using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyBooking.Models.ViewModels
{
    [Table("flights")]
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string FlightCode { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public String DepartureCity { get; set; }
        public String ArrivalCity { get; set; }
        public int AvailableSeats { get; set; }
        public int Price { get; set; }
    }
}