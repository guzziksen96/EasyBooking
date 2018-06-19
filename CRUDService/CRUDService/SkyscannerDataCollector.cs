using EasyBooking.Data;
using EasyBooking.Models;
using EasyBooking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CRUDService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class SkyscannerDataCollector : ISkyscannerDataCollector
    {
        public List<FlightS> GetFromSkyscanner(DateTime ArrivalDate, DateTime DepartureTime, string fromCity, string toCity, string UserId)
        {
            List<FlightS> flightS = new List<FlightS>();
            GetSchedule(ArrivalDate, DepartureTime, fromCity, toCity);
            return flightS;
        }

        private List<ScheduleFlight> GetSchedule(DateTime ArrivalDate, DateTime DepartureDate, string fromCity, string toCity)
        {
            string departureCity = fromCity == null ? "KRAKÓW" : fromCity.ToUpper();
            string destinationCity = toCity == null ? "DUBLIN" : toCity.ToUpper();
            if (CityMaping.AiportsDictionary.ContainsKey(departureCity) && CityMaping.AiportsDictionary.ContainsKey(destinationCity))
            {
                string scheduleAddress = string.Format(
                 "https://skyscanner-skyscanner-flight-search-v1.p.mashape.com/apiservices/browseroutes/v1.0/PL/USD/en-US/" +
                 "{0}/" +
                 "{1}/" +
                 "2018-06-20/" +
                 "2018-06-25",
                 Uri.EscapeDataString(CityMaping.AiportsDictionary[departureCity]),
                 Uri.EscapeDataString(CityMaping.AiportsDictionary[destinationCity]),
                 Uri.EscapeDataString(ArrivalDate.ToString("yyyy-MM-dd")),
                 Uri.EscapeDataString(DepartureDate.ToString("yyyy-MM-dd"))
               );
                string text;
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("X-Mashape-Key", "4h0jviR2sumshn3fr2uiPTKmOoEJp1r4uhOjsnuePGI7ZrRzra");
                    client.Headers.Add("X-Mashape-Host", "skyscanner-skyscanner-flight-search-v1.p.mashape.com");
                    try
                    {
                        text = client.DownloadString(scheduleAddress);
                        Console.Write(text);
                        //RyanairSchedule rr = DeserializeRyanairScheduleResponseConverter.FromJson(text);
                        //var v = rr.Days.Where(d => d.DayDay.Equals(ArrivalDate.Day));
                        //List<ScheduleFlight> result = new List<ScheduleFlight>();
                        //if (v.Count() > 0)
                        //{
                        //    result = rr.Days.Where(d => d.DayDay.Equals(ArrivalDate.Day)).First().ScheduleFlights;
                        //}
                        //return result;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return new List<ScheduleFlight>();
                    }
                }
            }
            return new List<ScheduleFlight>();

        }
    }
}


