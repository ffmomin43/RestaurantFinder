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
    public class HomeBannerImageService : IHomeBannerImageService
    {
        private readonly Lazy<IHomeBannerImagesRepository> homeBannerImageRepository;

        public HomeBannerImageService(Lazy<IHomeBannerImagesRepository> homeBannerImageRepository)
        {
            this.homeBannerImageRepository = homeBannerImageRepository;
        }

        public void Add(Models.HomeBannerImage entity)
        {

            homeBannerImageRepository.Value.Add(entity);
        }

        public void Delete(Models.HomeBannerImage entity)
        {
            homeBannerImageRepository.Value.Delete(entity);
        }

        public void Edit(Models.HomeBannerImage entity)
        {
            homeBannerImageRepository.Value.Edit(entity);
        }

        public IQueryable<Models.HomeBannerImage> FindBy(Expression<Func<Models.HomeBannerImage, bool>> predicate)
        {
            return homeBannerImageRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.HomeBannerImage> GetAll()
        {
            return homeBannerImageRepository.Value.GetAll();
        }


        public void Save()
        {
            homeBannerImageRepository.Value.Save();
        }
    }
}
