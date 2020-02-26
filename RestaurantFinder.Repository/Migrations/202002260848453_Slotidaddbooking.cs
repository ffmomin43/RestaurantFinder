namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slotidaddbooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantBookings", "Slotid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantBookings", "Slotid");
        }
    }
}
