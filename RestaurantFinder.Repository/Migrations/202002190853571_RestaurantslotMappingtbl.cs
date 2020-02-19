namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantslotMappingtbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantSlotMappings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        RestaurantSlotId = c.Int(nullable: false),
                        UniqueId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 1000),
                        DeletedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.RestaurantSlots", "StartTime", c => c.String());
            AlterColumn("dbo.RestaurantSlots", "EndTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RestaurantSlots", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RestaurantSlots", "StartTime", c => c.DateTime(nullable: false));
            DropTable("dbo.RestaurantSlotMappings");
        }
    }
}
