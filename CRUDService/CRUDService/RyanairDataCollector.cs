﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EasyBooking.Data;
using EasyBooking.Models;
using EasyBooking.Models.ViewModels;
using ObjectsManager.Model;

namespace CRUDService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RyanairDataCollector : IRyanairDataCollector
    {
        public List<FlightS> GetFromRyanair(DateTime ArrivalDate, string fromCity, string toCity, string UserId)
        {

            List<ScheduleFlight> ScheduleFlights = GetSchedule(ArrivalDate, fromCity, toCity);

            List<RyanairFlight> rFlights = GetFlights(ScheduleFlights);


            return rFlights.Select(f => new FlightS(f, ArrivalDate, UserId)).ToList();

        }
        private List<RyanairFlight> GetFlights(List<ScheduleFlight> ScheduleFlights)
        {
            List<string> adresses = ScheduleFlights.Select(d =>
            {
                return string.Format(
                     "https://api.ryanair.com/flightinfo/3/flights/?" +
                     "number={0}",
                     Uri.EscapeDataString(d.Number.ToString()));
            }).ToList();

            using (WebClient client = new WebClient())
            {
                List<RyanairFlight> result = new List<RyanairFlight>();
                adresses.ForEach(a =>
                {
                    var f = DeserializeRyanairResponse.FromJson(client.DownloadString(a)).Flights;
                    if (f.Count() > 0)
                    {
                        result.Add(f.First());
                    }
                });
                return result;
            }
        }
        private List<ScheduleFlight> GetSchedule(DateTime ArrivalDate, string fromCity, string toCity)
        {

            if (CityMaping.AiportsDictionary.ContainsKey(fromCity.ToUpper()) && CityMaping.AiportsDictionary.ContainsKey(toCity.ToUpper()))
            {
                string scheduleAddress = string.Format(
                 "https://api.ryanair.com/timetable/3/schedules/" +
                 "{0}/" +
                 "{1}/" +
                 "years/{2}/" +
                 "months/{3}",
                 Uri.EscapeDataString(CityMaping.AiportsDictionary[fromCity.ToUpper()]),
                 Uri.EscapeDataString(CityMaping.AiportsDictionary[toCity.ToUpper()]),
                 Uri.EscapeDataString(ArrivalDate.Year.ToString()),
                 Uri.EscapeDataString(ArrivalDate.Month.ToString())
               );
                string text;
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        text = client.DownloadString(scheduleAddress);
                        RyanairSchedule rr = DeserializeRyanairScheduleResponseConverter.FromJson(text);
                        var v = rr.Days.Where(d => d.DayDay.Equals(ArrivalDate.Day));
                        List<ScheduleFlight> result = new List<ScheduleFlight>();
                        if (v.Count() > 0)
                        {
                            result = rr.Days.Where(d => d.DayDay.Equals(ArrivalDate.Day)).First().ScheduleFlights;
                        }
                        return result;
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
