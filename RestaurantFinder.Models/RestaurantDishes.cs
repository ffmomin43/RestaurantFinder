using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
   public class RestaurantDishes: BaseModel
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string ThumbnailImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
