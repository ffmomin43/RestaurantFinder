using RestaurantFinder.BusinessLogic.Common;
using RestaurantFinder.Models;
using RestaurantFinder.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Interface
{
   public interface IRestaurantTablesService: IGenericService<RestaurantTable>
    {
        bool IsExist(string name);
    }
}
