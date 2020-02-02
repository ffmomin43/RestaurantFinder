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
    public class RestaurantCategoryMappingService : IRestaurantCategoryMappingService
    {
        private readonly Lazy<IRestaurantCategoryMappingRepository> restaurantCategoryMappingRepository;

        public RestaurantCategoryMappingService(Lazy<IRestaurantCategoryMappingRepository> restaurantCategoryMappingRepository)
        {
            this.restaurantCategoryMappingRepository = restaurantCategoryMappingRepository;
        }

        public void Add(Models.RestaurantCategoryMapping entity)
        {

            restaurantCategoryMappingRepository.Value.Add(entity);
        }

        public void Delete(Models.RestaurantCategoryMapping entity)
        {
            restaurantCategoryMappingRepository.Value.Delete(entity);
        }

        public void Edit(Models.RestaurantCategoryMapping entity)
        {
            restaurantCategoryMappingRepository.Value.Edit(entity);
        }

        public IQueryable<Models.RestaurantCategoryMapping> FindBy(Expression<Func<Models.RestaurantCategoryMapping, bool>> predicate)
        {
            return restaurantCategoryMappingRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.RestaurantCategoryMapping> GetAll()
        {
            return restaurantCategoryMappingRepository.Value.GetAll();
        }

        public bool IsExist(int restaurantId, int categoryId)
        {
            return restaurantCategoryMappingRepository.Value.GetAll().Where(x => x.CategoryId == categoryId && x.RestaurantId == restaurantId).Any();
        }

        public void Save()
        {
            restaurantCategoryMappingRepository.Value.Save();
        }
    }
}
