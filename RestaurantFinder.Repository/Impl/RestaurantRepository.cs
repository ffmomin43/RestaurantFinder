using RestaurantFinder.Models;
using RestaurantFinder.Repository.Common;
using RestaurantFinder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Repository.Impl
{
    public class RestaurantRepository : GenericRepository<RestaurantContext, Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RestaurantContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}
