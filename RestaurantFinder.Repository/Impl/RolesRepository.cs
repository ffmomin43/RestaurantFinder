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
   public class RolesRepository: GenericRepository<RestaurantContext, Role>,IRolesRepository
    {
        public RolesRepository(RestaurantContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}
   