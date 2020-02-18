using RestaurantFinder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Impl
{
   public class RestaurantSlotService
    {

        private readonly Lazy<IRestaurantSlotRepository> restaurantSlotRepository;

        public RestaurantSlotService(Lazy<IRestaurantSlotRepository> restaurantSlotRepository)
        {
            this.restaurantSlotRepository = restaurantSlotRepository;
        }

        public void Add(Models.RestaurantSlot entity)
        {

            restaurantSlotRepository.Value.Add(entity);
        }

        public void Delete(Models.RestaurantSlot entity)
        {
            restaurantSlotRepository.Value.Delete(entity);
        }

        public void Edit(Models.RestaurantSlot entity)
        {
            restaurantSlotRepository.Value.Edit(entity);
        }

        public IQueryable<Models.RestaurantSlot> FindBy(Expression<Func<Models.RestaurantSlot, bool>> predicate)
        {
            return restaurantSlotRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.RestaurantSlot> GetAll()
        {
            return restaurantSlotRepository.Value.GetAll();
        }


        public void Save()
        {
            restaurantSlotRepository.Value.Save();
        }
    }
}
