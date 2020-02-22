﻿namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantBooking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantBookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        TableSlotMappingID = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RestaurantBookings");
        }
    }
}
