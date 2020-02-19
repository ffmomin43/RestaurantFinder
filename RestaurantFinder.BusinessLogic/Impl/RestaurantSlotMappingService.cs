using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Impl
{
   public class RestaurantSlotMappingService : IRestaurantSlotMappingService
    {
        private readonly Lazy<IRestaurantSlotMappingRepository> restaurantSlotMappingRepository;

        public RestaurantSlotMappingService(Lazy<IRestaurantSlotMappingRepository> restaurantSlotMappingRepository)
        {
            this.restaurantSlotMappingRepository = restaurantSlotMappingRepository;
        }

        public void Add(Models.RestaurantSlotMapping entity)
        {

            restaurantSlotMappingRepository.Value.Add(entity);
        }

        public void Delete(Models.RestaurantSlotMapping entity)
        {
            restaurantSlotMappingRepository.Value.Delete(entity);
        }
        public int insert(Models.RestaurantSlotMapping entity)
        {
            return 1;
        }

        public void Edit(Models.RestaurantSlotMapping entity)
        {
            restaurantSlotMappingRepository.Value.Edit(entity);
        }

        public IQueryable<Models.RestaurantSlotMapping> FindBy(Expression<Func<Models.RestaurantSlotMapping, bool>> predicate)
        {
            return restaurantSlotMappingRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.RestaurantSlotMapping> GetAll()
        {
            return restaurantSlotMappingRepository.Value.GetAll();
        }

        //public bool IsExist(string name)
        //{
        //    return restaurantSlotMappingRepository.Value.GetAll().Where(x => x.res == name).Any();
        //}

        public void Save()
        {
            restaurantSlotMappingRepository.Value.Save();
        }

        public bool Checklogin(string name, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
