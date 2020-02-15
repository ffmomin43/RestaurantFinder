namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantCategoryMappingupdates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RestaurantCategoryMappings", "IsCheck");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantCategoryMappings", "IsCheck", c => c.Boolean(nullable: false));
        }
    }
}
