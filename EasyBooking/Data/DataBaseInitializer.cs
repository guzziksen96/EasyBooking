using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyBooking.Data
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EasyBookingDbContext>
    {
        protected override void Seed(EasyBookingDbContext context)
        {
        }
    }
}