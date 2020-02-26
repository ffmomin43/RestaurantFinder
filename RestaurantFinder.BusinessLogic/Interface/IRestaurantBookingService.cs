﻿using RestaurantFinder.BusinessLogic.Common;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Interface
{
   public interface IRestaurantBookingService : IGenericService<RestaurantBooking>
    {
        bool Added(Models.RestaurantBooking entity);
      List<int> GetBookTableonSpecificDate(DateTime date);
        List<int> GetBookTableonSpecificRestaurant(int Restaurantid);


    }

}
