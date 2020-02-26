namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantBookings", "TableID", c => c.Int(nullable: false));
            DropColumn("dbo.RestaurantBookings", "TableSlotMappingID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantBookings", "TableSlotMappingID", c => c.Int(nullable: false));
            DropColumn("dbo.RestaurantBookings", "TableID");
        }
    }
}
