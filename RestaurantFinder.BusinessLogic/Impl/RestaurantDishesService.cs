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
  public  class RestaurantDishesService : IRestaurantDishesService
    {
        private readonly Lazy<IRestaurantDishesRepository> restaurantDishesRepository;

        public RestaurantDishesService(Lazy<IRestaurantDishesRepository> restaurantDishesRepository)
        {
            this.restaurantDishesRepository = restaurantDishesRepository;
        }

        public void Add(Models.RestaurantDishes entity)
        {

            restaurantDishesRepository.Value.Add(entity);
        }

        public void Delete(Models.RestaurantDishes entity)
        {
            restaurantDishesRepository.Value.Delete(entity);
        }
        public int insert(Models.RestaurantDishes entity)
        {
            return 1;
        }

        public void Edit(Models.RestaurantDishes entity)
        {
            restaurantDishesRepository.Value.Edit(entity);
        }

        public IQueryable<Models.RestaurantDishes> FindBy(Expression<Func<Models.RestaurantDishes, bool>> predicate)
        {
            return restaurantDishesRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.RestaurantDishes> GetAll()
        {
            return restaurantDishesRepository.Value.GetAll();
        }

        public bool IsExist(string name)
        {
            return restaurantDishesRepository.Value.GetAll().Where(x => x.Name == name).Any();
        }

        public void Save()
        {
            restaurantDishesRepository.Value.Save();
        }

        public bool Checklogin(string name, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
