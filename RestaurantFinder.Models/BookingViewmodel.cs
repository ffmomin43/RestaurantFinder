using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
 public   class BookingViewmodel
    {
        public int Tableid { get; set; }
        public bool Status { get; set; }
        public Guid bookingid { get; set; }
       
    }
}
