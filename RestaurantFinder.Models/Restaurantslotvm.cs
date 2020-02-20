using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
   public class Restaurantslotvm
    {
       
       
        public string  StartTime { get; set; }
       
        
        public string EndTime { get; set; }
        public string RestaurantName { get; set; }
        public int tablenum { get; set; }
        public int RestauranrId { get; set; }
    }
}
