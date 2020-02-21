using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
 public   class TableSlotVm
    {
        public List<RestaurantTable> restaurantTable { get; set; }
        public List<RestaurantSlot> RestaurantSlot { get; set; }
    }
}
