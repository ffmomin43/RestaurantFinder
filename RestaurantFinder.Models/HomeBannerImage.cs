using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
    public class HomeBannerImage: BaseModel
    {
        public string Url { get; set; }

        public string HeadingText { get; set; }

        public string Description { get; set; }

    }
}
