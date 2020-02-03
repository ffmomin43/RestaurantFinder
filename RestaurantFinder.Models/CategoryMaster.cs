using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestaurantFinder.Models
{
    public class CategoryMaster: BaseModel
    {
        public string Name { get; set; }

        public string ThumbnailImageUrl { get; set; }
        [NotMapped]
        public HttpPostedFileBase imagefile { get; set; }
    }
}
