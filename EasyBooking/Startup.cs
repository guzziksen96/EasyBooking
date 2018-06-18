using EasyBooking.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(EasyBooking.Startup))]
namespace EasyBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            ConfigureAuth(app);
        }
    }
}
