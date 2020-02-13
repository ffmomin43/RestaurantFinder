using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
  public  class RestaurantSlot:BaseModel
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int RestaurantDayId { get; set; }
    }
}
