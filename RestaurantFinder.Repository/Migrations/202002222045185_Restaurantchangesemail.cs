namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restaurantchangesemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "RestaurantEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "RestaurantEmail");
        }
    }
}
