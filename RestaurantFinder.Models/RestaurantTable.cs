using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
    public class RestaurantTable: BaseModel
    {
        public int RestaurantId { get; set; }

        public int TableNumber { get; set; }
        public int TableCapacity { get; set; }

        public string TableName { get; set; }
        //public int userid { get; set; }
    }
}
