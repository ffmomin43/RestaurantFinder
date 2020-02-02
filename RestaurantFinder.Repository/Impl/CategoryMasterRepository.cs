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
    public class CategoryMasterRepository : GenericRepository<RestaurantContext, CategoryMaster>, ICategoryMasterRepository
    {
        public CategoryMasterRepository(RestaurantContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}

