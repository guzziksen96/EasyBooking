namespace EasyBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userId_fight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "UserId", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "UserId");
        }
    }
}
