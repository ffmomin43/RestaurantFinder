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
        [DataType(DataType.Time)]
       
        public String  StartTime { get; set; }
       
        [DataType(DataType.Time)]
        public String EndTime { get; set; }
    }
}
