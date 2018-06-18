namespace EasyBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m_v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "Schedule_Id", "dbo.Schedules");
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
            
            AddColumn("dbo.Reservations", "Schedule_Id1", c => c.Int());
            CreateIndex("dbo.Reservations", "Schedule_Id1");
            AddForeignKey("dbo.Reservations", "Schedule_Id1", "dbo.Schedules", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Schedule_Id1", "dbo.Schedules");
            DropForeignKey("dbo.ScheduleDays", "RyanairSchedule_Id", "dbo.RyanairSchedules");
            DropForeignKey("dbo.ScheduleFlights", "ScheduleDay_Id", "dbo.ScheduleDays");
            DropIndex("dbo.ScheduleDays", new[] { "RyanairSchedule_Id" });
            DropIndex("dbo.ScheduleFlights", new[] { "ScheduleDay_Id" });
            DropIndex("dbo.Reservations", new[] { "Schedule_Id1" });
            DropColumn("dbo.Reservations", "Schedule_Id1");
            DropTable("dbo.ScheduleDays");
            DropTable("dbo.RyanairSchedules");
            DropTable("dbo.ScheduleFlights");
            AddForeignKey("dbo.Reservations", "Schedule_Id", "dbo.Schedules", "Id");
        }
    }
}
