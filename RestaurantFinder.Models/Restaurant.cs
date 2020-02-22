using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestaurantFinder.Models
{
    public class Restaurant: BaseModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        [NotMapped]
        public string restaurantPicture { get  ; set; }
        public string Area { get; set; }

        public string PinCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public bool IsTrending { get; set; }
        public int Number{ get; set; }
        public string Description { get; set; }

        public string ThumbnailImageUrl { get; set; }
        [NotMapped]
        public HttpPostedFileBase imagefile { get; set; }
        public decimal StartingPrice { get; set; }
        public string RestaurantEmail { get; set; }

        //public virtual List<RestaurantsImages> RestaurantsImages { get; set; }

    }
}
