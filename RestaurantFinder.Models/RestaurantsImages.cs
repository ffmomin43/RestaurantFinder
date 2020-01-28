using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
 public class RestaurantsImages : BaseModel
    {
        public int RestaurantId { get; set; }

        public string listImageUrl { get; set; }
    }
}
