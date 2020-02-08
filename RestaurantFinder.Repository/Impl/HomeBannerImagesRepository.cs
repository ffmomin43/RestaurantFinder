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
    public class HomeBannerImagesRepository : GenericRepository<RestaurantContext, HomeBannerImage>, IHomeBannerImagesRepository
    {
        public HomeBannerImagesRepository(RestaurantContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}

