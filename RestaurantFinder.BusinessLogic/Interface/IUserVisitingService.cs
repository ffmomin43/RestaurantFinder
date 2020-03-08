using RestaurantFinder.BusinessLogic.Common;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Interface
{
  public  interface IUserVisitingService : IGenericService<UserVisiting>
    {
        void SaveUserVistingParameters(string userid, Guid guid,
            string qrcode,int ID,double Longitude,double Latitude);
    }
}
