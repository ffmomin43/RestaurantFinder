namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "User_ID", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "Role_ID", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "User_ID" });
            DropIndex("dbo.UserRoles", new[] { "Role_ID" });
            AddColumn("dbo.Users", "Role_ID", c => c.Int());
            CreateIndex("dbo.Users", "Role_ID");
            AddForeignKey("dbo.Users", "Role_ID", "dbo.Roles", "ID");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Role_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Role_ID });
            
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropColumn("dbo.Users", "Role_ID");
            CreateIndex("dbo.UserRoles", "Role_ID");
            CreateIndex("dbo.UserRoles", "User_ID");
            AddForeignKey("dbo.UserRoles", "Role_ID", "dbo.Roles", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "User_ID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
