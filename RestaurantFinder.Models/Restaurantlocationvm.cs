﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
  public class Restaurantlocationvm
    {


        public string Name { get; set; }
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public string Thumbimageurl { get; set; }
        public double Longitude { get; set; }
        public int ID
        {
            get; set;
        }

        public int RestaurantId { get; set; }

        public double Distance { get; set; }
        public decimal Starting_Price { get; set; }
        public List<string> Categories { get; set; }


    }
}
