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
    class RestaurantsImagesService : IRestaurantsImagesService
    {
        private readonly Lazy<IRestaurantsImagesRepository>restaurantsImagesRepository;

        public RestaurantsImagesService(Lazy<IRestaurantsImagesRepository> restaurantsImagesRepository)
        {
            this.restaurantsImagesRepository = restaurantsImagesRepository;
        }

        public void Add(Models.RestaurantsImages entity)
        {

            restaurantsImagesRepository.Value.Add(entity);
        }

        public void Delete(Models.RestaurantsImages entity)
        {
            restaurantsImagesRepository.Value.Delete(entity);
        }

        public int insert(Models.RestaurantsImages entity)
        {
            return 1;
        }
        public void Edit(Models.RestaurantsImages entity)
        {
            restaurantsImagesRepository.Value.Edit(entity);
        }

        public IQueryable<Models.RestaurantsImages> FindBy(Expression<Func<Models.RestaurantsImages, bool>> predicate)
        {
            return restaurantsImagesRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.RestaurantsImages> GetAll()
        {
            return restaurantsImagesRepository.Value.GetAll();
        }

        //public bool IsExist(string name)
        //{
        //    return restaurantsImagesRepository.Value.GetAll().Where(x => x.id == name).Any();
        //}

        public void Save()
        {
            restaurantsImagesRepository.Value.Save();
        }

        public bool Checklogin(string name, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
