using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Repository
{
    public class RestaurantContext:DbContext
    {
        public RestaurantContext(): base("RestaurantConnectionString")
        {

        }

        public DbSet<Role> Role { get; set; }

        public DbSet<Permission> Permission { get; set; }

        public DbSet<Models.Action> Actions { get; set; }

        public DbSet<User> User { get; set; }
        

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<RestaurantCouponsMaster> RestaurantCouponsMasters { get; set; }

        public DbSet<RestaurantLocation> RestaurantLocations { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }
        public DbSet<RestaurantDishes> RestaurantDishes { get; set; }
        public DbSet<RestaurantsImages> RestaurantsImages { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<CategoryMaster> CategoryMasters { get; set; }
        public DbSet<RestaurantCategoryMapping> RestaurantCategoryMapping { get; set; }

        public DbSet<HomeBannerImage> HomeBannerImages { get; set; }
        public DbSet<DayMaster> DayMasters { get; set; }
        public DbSet<RestaruantDay> RestaruantDays { get; set; }
        public DbSet<RestaurantSlot> RestaurantSlot { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RestaurantSlotMapping> RestaurantSlotMappings { get; set; }
        public DbSet<RestaurantBooking> RestaurantBooking { get; set; }
    }
}
