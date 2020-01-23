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

        public DbSet<Models.Action> Action { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Restaurant> Restaurant { get; set; }
    }
}
