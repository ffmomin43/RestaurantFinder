namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestaurantsImages", "RestaurantimagesVm_ID", "dbo.Restaurants");
            DropIndex("dbo.RestaurantsImages", new[] { "RestaurantimagesVm_ID" });
            DropColumn("dbo.RestaurantsImages", "RestaurantimagesVm_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantsImages", "RestaurantimagesVm_ID", c => c.Int());
            CreateIndex("dbo.RestaurantsImages", "RestaurantimagesVm_ID");
            AddForeignKey("dbo.RestaurantsImages", "RestaurantimagesVm_ID", "dbo.Restaurants", "ID");
        }
    }
}
