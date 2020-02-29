using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
   public class couponsvm
    {
        public string Restaurant { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Discount { get; set; }
        public string CouponsCode { get; set; }
    }
}
