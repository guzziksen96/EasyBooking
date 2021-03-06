﻿using EasyBooking.Models;
using EasyBooking.Models.ViewModels;
using EasyBooking.RyanairDataCollectorService;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace EasyBooking.Data
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var randomGenerator = new RandomGenerator();

            var flights = Builder<Flight>.CreateListOfSize(100)
                    .All()
                    .With(f => f.FlightCode = Faker.Lorem.Paragraph())
                    .With(f => f.DepartureCity = Faker.Name.Last())
                    .With(f => f.ArrivalCity = Faker.Name.Last())
                  .With(f => f.DepartureDate = DateTime.Now.AddDays(-randomGenerator.Next(1, 100)))
                   .With(f => f.ArrivalDate = DateTime.Now.AddDays(-randomGenerator.Next(1, 100)))
                   .Build();

            context.Flights.AddOrUpdate(f => f.Id, flights.ToArray());
            context.SaveChanges();

            var schedules = Builder<Schedule>.CreateListOfSize(200)
                        .All()
                        .With(r => r.EconomyClassPrice = Faker.RandomNumber.Next(40, 500))
                        .With(r => r.EconomyClassRemainingSeats = Faker.RandomNumber.Next(1, 250))
                        .With(r => r.FirstClassRemainingSeats = Faker.RandomNumber.Next(1, 50))
                        .With(r => r.FirstClassPrice = Faker.RandomNumber.Next(200, 2500))
                        .With(r => r.FirstClassRemainingSeats = Faker.RandomNumber.Next(1, 50))
                        .Build();

            context.Schedules.AddOrUpdate(s => s.Id, schedules.ToArray());
            context.SaveChanges();
        }
    }
}