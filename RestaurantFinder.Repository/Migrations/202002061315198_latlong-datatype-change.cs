namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latlongdatatypechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RestaurantLocations", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.RestaurantLocations", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RestaurantLocations", "Longitude", c => c.Long(nullable: false));
            AlterColumn("dbo.RestaurantLocations", "Latitude", c => c.Long(nullable: false));
        }
    }
}
