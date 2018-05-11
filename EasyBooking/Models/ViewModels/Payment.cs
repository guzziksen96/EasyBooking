using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyBooking.Models.ViewModels
{
    public class Payment
    {
        public int Id { get; set; }
        public string Mode { get; set; }
        public double TotalAmount { get; set; }
        public string Details { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}