namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restaurantslottblupdatestest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RestaurantSlots", "StartTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.RestaurantSlots", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RestaurantSlots", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RestaurantSlots", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
