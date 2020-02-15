using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
  public class UserRole:BaseModel
    {

        public int UserID { get; set; }
        public int RoleID { get; set; }
    }
}
  