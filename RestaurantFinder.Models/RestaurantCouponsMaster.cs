using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
    public class RestaurantCouponsMaster: BaseModel
    {
        public int RestaurantId { get; set; }

        public string CouponName { get; set; }
        
        
        public string CouponCode { get; set; }
        [DisplayFormat( ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat( ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Discount { get; set; }

        public bool IsPublished { get; set; }



    }
}
