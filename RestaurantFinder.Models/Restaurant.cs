﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
    public class Restaurant: BaseModel
    {
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        [NotMapped]
        public string restaurantPicture { get  ; set; }
        public string Area { get; set; }

        public string PinCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }
        public virtual List<RestaurantsImages> RestaurantsImages { get; set; }

    }
}
