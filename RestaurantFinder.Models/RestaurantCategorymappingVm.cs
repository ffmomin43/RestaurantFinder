using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
   public  class RestaurantCategorymappingVm
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string RestaurantName { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
