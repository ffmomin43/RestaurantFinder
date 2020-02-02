using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
   public class RestaurantDishesvm
    {
        public string Name { get; set; }
        public string Dishname { get; set; }

        public int RestaurantID { get; set; }
        public int DishID { get; set; }

    }
}
