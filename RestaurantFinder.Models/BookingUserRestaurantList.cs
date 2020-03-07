using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
 public   class BookingUserRestaurantList
    {
        public int RestaurantId { get; set; }
        public int  Tableid { get; set; }

        public DateTime BookingDate { get; set; }
        public string UserId { get; set; }
       
        public string RestaurantName { get; set; }
        public string Restaurantimage { get; set; }
        public int NoOfPerson { get; set; }
        public string slotname { get; set; }
        public int Bookingid { get; set; }
    }
}
