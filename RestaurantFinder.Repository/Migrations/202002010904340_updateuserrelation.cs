namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuserrelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_ID" });
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Role_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Role_ID })
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_ID, cascadeDelete: true)
                .Index(t => t.User_ID)
                .Index(t => t.Role_ID);
            
            DropColumn("dbo.Users", "Role_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role_ID", c => c.Int());
            DropForeignKey("dbo.UserRoles", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_ID", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "Role_ID" });
            DropIndex("dbo.UserRoles", new[] { "User_ID" });
            DropTable("dbo.UserRoles");
            CreateIndex("dbo.Users", "Role_ID");
            AddForeignKey("dbo.Users", "Role_ID", "dbo.Roles", "ID");
        }
    }
}
