namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restaurantaddtimeslot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "openingTime", c => c.String());
            AddColumn("dbo.Restaurants", "closingTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "closingTime");
            DropColumn("dbo.Restaurants", "openingTime");
        }
    }
}
