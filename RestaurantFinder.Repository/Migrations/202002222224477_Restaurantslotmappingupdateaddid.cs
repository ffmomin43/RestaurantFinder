namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restaurantslotmappingupdateaddid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantSlotMappings", "ResturantID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantSlotMappings", "ResturantID");
        }
    }
}
