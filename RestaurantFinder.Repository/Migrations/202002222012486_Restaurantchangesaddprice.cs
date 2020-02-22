namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restaurantchangesaddprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "StartingPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "StartingPrice");
        }
    }
}
