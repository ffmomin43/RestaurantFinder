using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
  public  class RestaurantSlot:BaseModel
    {
        public string SlotName { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]

        public string StartTime { get; set; }

        [DataType(DataType.Time)]
        public string EndTime { get; set; }

        public int Restaurantid { get; set; }
    }
}
