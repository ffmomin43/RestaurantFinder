﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
   public class RestaurantSlotMapping:BaseModel
    {
        public int RestaurantId { get; set; }
        public int RestaurantSlotId { get; set; }

    }

}
