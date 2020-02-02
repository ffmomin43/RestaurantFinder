namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        url = c.String(),
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
            
            AddColumn("dbo.RestaurantsImages", "PictureId", c => c.Int(nullable: false));
            CreateIndex("dbo.RestaurantsImages", "RestaurantId");
            CreateIndex("dbo.RestaurantsImages", "PictureId");
            AddForeignKey("dbo.RestaurantsImages", "PictureId", "dbo.Pictures", "ID", cascadeDelete: true);
            AddForeignKey("dbo.RestaurantsImages", "RestaurantId", "dbo.Restaurants", "ID", cascadeDelete: true);
            DropColumn("dbo.RestaurantsImages", "listImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantsImages", "listImageUrl", c => c.String());
            DropForeignKey("dbo.RestaurantsImages", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantsImages", "PictureId", "dbo.Pictures");
            DropIndex("dbo.RestaurantsImages", new[] { "PictureId" });
            DropIndex("dbo.RestaurantsImages", new[] { "RestaurantId" });
            DropColumn("dbo.RestaurantsImages", "PictureId");
            DropTable("dbo.Pictures");
        }
    }
}
