namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changevisitingstbl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserVisitings", "qrcode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserVisitings", "qrcode", c => c.Guid(nullable: false));
        }
    }
}
