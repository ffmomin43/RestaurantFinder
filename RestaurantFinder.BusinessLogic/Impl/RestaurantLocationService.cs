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
    class RestaurantLocationService: IRestaurantLocationService
    {
        private readonly Lazy<IRestaurantLocationRepository> restaurantLocationRepository;

        public RestaurantLocationService(Lazy<IRestaurantLocationRepository> restaurantLocationRepository)
        {
            this.restaurantLocationRepository = restaurantLocationRepository;
        }

        public void Add(Models.RestaurantLocation entity)
        {

            restaurantLocationRepository.Value.Add(entity);
        }

        public void Delete(Models.RestaurantLocation entity)
        {
            restaurantLocationRepository.Value.Delete(entity);
        }

        public void Edit(Models.RestaurantLocation entity)
        {
            restaurantLocationRepository.Value.Edit(entity);
        }

        public IQueryable<Models.RestaurantLocation> FindBy(Expression<Func<Models.RestaurantLocation, bool>> predicate)
        {
            return restaurantLocationRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.RestaurantLocation> GetAll()
        {
            return restaurantLocationRepository.Value.GetAll();
        }

        public bool IsExist(string name)
        {
          return  restaurantLocationRepository.Value.GetAll().Where(x => x.LocationName == name).Any();
        }

        public void Save()
        {
            restaurantLocationRepository.Value.Save();
        }
    }
}
    