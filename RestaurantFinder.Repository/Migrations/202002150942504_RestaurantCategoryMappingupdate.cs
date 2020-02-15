namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantCategoryMappingupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantCategoryMappings", "IsCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantCategoryMappings", "IsCheck");
        }
    }
}
