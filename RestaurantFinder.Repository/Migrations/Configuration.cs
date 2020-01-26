namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantFinder.Repository.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestaurantFinder.Repository.RestaurantContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Restaurant.Add(new Models.Restaurant()
            {
                AddressLine1 = "Test1",
                AddressLine2 = "test line 2",
                Area = "Auchit Pada",
                City = "Bhiwandi",
                CreatedBy = "Fahad",
                CreatedDate = DateTime.Now,
                IsActive = true,
                Name = "Fahad Resto",
                PinCode = "421302",
                State = "Maharashtra",
                UniqueId = Guid.NewGuid()
            });
            context.Restaurant.Add(new Models.Restaurant()
            {
                AddressLine1 = "Test2",
                AddressLine2 = "test line 2",
                Area = "Mumbra Devi",
                City = "Mumbra",
                CreatedBy = "Fahad",
                CreatedDate = DateTime.Now,
                IsActive = true,
                Name = "Fahad Resto Number 2",
                PinCode = "400807",
                State = "Maharashtra",
                UniqueId = Guid.NewGuid()
            });
        }
    }
}
