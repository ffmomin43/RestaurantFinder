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
    public class RestaurantService : IRestaurantService
    {

        private readonly Lazy<IRestaurantRepository> restaurantRepository;

        public RestaurantService(Lazy<IRestaurantRepository> restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public void Add(Models.Restaurant entity)
        {

            restaurantRepository.Value.Add(entity);
        }

        public void Delete(Models.Restaurant entity)
        {
            restaurantRepository.Value.Delete(entity);
        }

        public int insert(Models.Restaurant entity)
        {
            return 1;
        }
        public void Edit(Models.Restaurant entity)
        {
            restaurantRepository.Value.Edit(entity);
        }

        public IQueryable<Models.Restaurant> FindBy(Expression<Func<Models.Restaurant, bool>> predicate)
        {
            return restaurantRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.Restaurant> GetAll()
        {
            return restaurantRepository.Value.GetAll();
        }

        public bool IsExist(string name)
        {
            return restaurantRepository.Value.GetAll().Where(x => x.Name == name).Any();
        }

        public void Save()
        {
            restaurantRepository.Value.Save();
        }
    }
}
