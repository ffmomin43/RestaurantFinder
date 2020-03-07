using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
  public  class RestaurantBooking:BaseModel
    {

        public RestaurantBooking()
        {
            IsCancel = true;
            BookingStatus = "Pending";

        }
        public int RestaurantID { get; set; }
        public bool IsCancel{get; set; }
        public int TableID { get; set; }
        public DateTime BookingDate { get; set; }
        public string UserId { get; set; }
        public int Slotid { get; set; }
        public string BookingStatus { get; set; }
    }
}
