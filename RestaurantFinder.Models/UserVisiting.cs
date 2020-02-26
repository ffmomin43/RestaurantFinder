using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
   public class UserVisiting:BaseModel
    {
        public string Userid { get; set; }
        public string qrcode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int RestaurantID { get; set; }
    }
}
