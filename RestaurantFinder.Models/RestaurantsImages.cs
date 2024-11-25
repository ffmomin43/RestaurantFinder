﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
 public class RestaurantsImages : BaseModel
    {
        public int RestaurantId { get; set; }

        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
