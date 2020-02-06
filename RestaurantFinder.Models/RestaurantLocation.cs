using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
    public class RestaurantLocation: BaseModel
    {
        public int RestaurantId { get; set; }

        public string LocationName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }


    }
}
