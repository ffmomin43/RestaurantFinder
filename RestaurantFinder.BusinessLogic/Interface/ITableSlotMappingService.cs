﻿using RestaurantFinder.BusinessLogic.Common;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Interface
{
  public  interface ITableSlotMappingService: IGenericService<RestaurantSlotMapping>
    {
     List<int> GetTablebySlot(int resturantId, int slotId);
        List<int> GetTablebyRestaurant(int resturantId);

    }
}