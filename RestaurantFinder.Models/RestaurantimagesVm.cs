using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestaurantFinder.Models
{
    public class RestaurantImagesVm 
    {
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        
        public string Area { get; set; }

        public string PinCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public int RestaurantId { get; set; }

        public string RestaurantsImages { get; set; }

        public bool IsTrending { get; set; }
        public string Thumburl { get; set; }
        public string CategoryName { get; set; }

        //public IEnumerable<string> ImageUrls { get; set; }

        //public List<RestaurantsImages> restaurantsImage { get; set; }



    }
}
