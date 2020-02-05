using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestaurantFinder.Models
{
    public class RestaurantimagesVm 
    {
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        
        public string Area { get; set; }

        public string PinCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }
        public int id { get; set; }
        public string RestaurantsImages { get; set; }


        public List<RestaurantsImages> restaurantsImage { get; set; }



    }
}
