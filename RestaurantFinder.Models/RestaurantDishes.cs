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

        public string Url1 { get; set; }

        public string Url2 { get; set; }

        public string Url3 { get; set; }

        public string Url4 { get; set; }

        public string Url5 { get; set; }

        public decimal Price { get; set; }
    }
}
