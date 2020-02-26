using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
 public   class BookingResponseViewmodel
    {
        public int TableId { get; set; }
        public bool Status { get; set; }
        public string BookingId { get; set; }
       
    }
}
