namespace EasyBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightCode = c.String(maxLength: 4000),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        DepartureCity = c.String(maxLength: 4000),
                        ArrivalCity = c.String(maxLength: 4000),
                        SeatsFirstclass = c.Int(nullable: false),
                        SeatsEconomyclass = c.Int(nullable: false),
                        UserId = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(maxLength: 4000),
                        TotalAmount = c.Double(nullable: false),
                        Details = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 4000),
                        Price = c.Int(nullable: false),
                        FlightClassNumber = c.Int(nullable: false),
                        Flight_Id = c.Int(),
                        Payment_Id = c.Int(),
                        Schedule_Id = c.Int(),
                        User_Id = c.Int(),
                        Schedule_Id1 = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScheduleFlights", t => t.Flight_Id)
                .ForeignKey("dbo.Payments", t => t.Payment_Id)
                .ForeignKey("dbo.RyanairSchedules", t => t.Schedule_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Schedules", t => t.Schedule_Id1)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Flight_Id)
                .Index(t => t.Payment_Id)
                .Index(t => t.Schedule_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Schedule_Id1)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ScheduleFlights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        DepartureTime = c.String(maxLength: 4000),
                        ArrivalTime = c.String(maxLength: 4000),
                        ScheduleDay_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScheduleDays", t => t.ScheduleDay_Id)
                .Index(t => t.ScheduleDay_Id);
            
            CreateTable(
                "dbo.RyanairSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayDay = c.Int(nullable: false),
                        RyanairSchedule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RyanairSchedules", t => t.RyanairSchedule_Id)
                .Index(t => t.RyanairSchedule_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 4000),
                        LastName = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4000),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 4000),
                        RoleId = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstClassRemainingSeats = c.Int(nullable: false),
                        EconomyClassRemainingSeats = c.Int(nullable: false),
                        FirstClassPrice = c.Double(nullable: false),
                        EconomyClassPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4000),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                        PhoneNumber = c.String(maxLength: 4000),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 4000),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 4000),
                        ProviderKey = c.String(nullable: false, maxLength: 4000),
                        UserId = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "Schedule_Id1", "dbo.Schedules");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reservations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Reservations", "Schedule_Id", "dbo.RyanairSchedules");
            DropForeignKey("dbo.ScheduleDays", "RyanairSchedule_Id", "dbo.RyanairSchedules");
            DropForeignKey("dbo.ScheduleFlights", "ScheduleDay_Id", "dbo.ScheduleDays");
            DropForeignKey("dbo.Reservations", "Payment_Id", "dbo.Payments");
            DropForeignKey("dbo.Reservations", "Flight_Id", "dbo.ScheduleFlights");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ScheduleDays", new[] { "RyanairSchedule_Id" });
            DropIndex("dbo.ScheduleFlights", new[] { "ScheduleDay_Id" });
            DropIndex("dbo.Reservations", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Reservations", new[] { "Schedule_Id1" });
            DropIndex("dbo.Reservations", new[] { "User_Id" });
            DropIndex("dbo.Reservations", new[] { "Schedule_Id" });
            DropIndex("dbo.Reservations", new[] { "Payment_Id" });
            DropIndex("dbo.Reservations", new[] { "Flight_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Schedules");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Users");
            DropTable("dbo.ScheduleDays");
            DropTable("dbo.RyanairSchedules");
            DropTable("dbo.ScheduleFlights");
            DropTable("dbo.Reservations");
            DropTable("dbo.Payments");
            DropTable("dbo.Flights");
        }
    }
}
