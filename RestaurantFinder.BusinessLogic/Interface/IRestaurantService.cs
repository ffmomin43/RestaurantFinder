using RestaurantFinder.BusinessLogic.Common;
using RestaurantFinder.Models;

namespace RestaurantFinder.BusinessLogic.Interface
{
    public interface IRestaurantService : IGenericService<Restaurant>
    {
        bool IsExist(string name);
    }
}
