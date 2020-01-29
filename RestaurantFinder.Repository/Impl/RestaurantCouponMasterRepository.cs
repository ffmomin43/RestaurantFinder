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
   public class RestaurantCouponMasterRepository : GenericRepository<RestaurantContext, RestaurantCouponsMaster>, IRestaurantCouponMasterRepository
    {
        public RestaurantCouponMasterRepository(RestaurantContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}

