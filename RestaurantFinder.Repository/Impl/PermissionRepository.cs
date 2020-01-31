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
  public  class PermissionRepository: GenericRepository<RestaurantContext, Permission>, IPermissionRepository
    {
        public PermissionRepository(RestaurantContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}

