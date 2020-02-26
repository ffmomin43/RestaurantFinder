using RestaurantFinder.BusinessLogic.Common;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Interface
{
    public interface ITableSlotMappingService : IGenericService<RestaurantSlotMapping>
    {
        IEnumerable<int> GetTablebySlot(int resturantId, int slotId);
        IEnumerable<int> GetTablebyRestaurant(int resturantId);

    }
}