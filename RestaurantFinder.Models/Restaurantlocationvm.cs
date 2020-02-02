using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
  public class Restaurantlocationvm
    {


        public string Name { get; set; }
        public string LocationName { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public int ID
        {
            get; set;
        }



    }
}
