using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
    public class RestaurantimagesVm : Restaurant
    {
        public IEnumerable<RestaurantsImages> RestaurantsImage { set; get; }


    }
}
