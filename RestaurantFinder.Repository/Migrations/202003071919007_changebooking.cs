namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changebooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantBookings", "BookingStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantBookings", "BookingStatus");
        }
    }
}
