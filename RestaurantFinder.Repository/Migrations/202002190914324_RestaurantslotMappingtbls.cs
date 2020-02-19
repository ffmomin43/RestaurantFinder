namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantslotMappingtbls : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantSlotMappings", "TableId", c => c.Int(nullable: false));
            DropColumn("dbo.RestaurantSlotMappings", "RestaurantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantSlotMappings", "RestaurantId", c => c.Int(nullable: false));
            DropColumn("dbo.RestaurantSlotMappings", "TableId");
        }
    }
}
