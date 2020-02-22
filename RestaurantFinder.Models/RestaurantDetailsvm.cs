using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
    public class RestaurantDetailsvm
    {

        public int Number { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public string CategoryName { get; set; }
        public string Email { get; set; }
        public string openingTime { get; set; }
        public string closingTime { get; set; }

    }
}

