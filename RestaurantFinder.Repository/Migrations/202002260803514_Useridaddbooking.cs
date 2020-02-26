namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Useridaddbooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantBookings", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantBookings", "UserId");
        }
    }
}
