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
 public   class PictureService: IPictureService
    {
        private readonly Lazy<IPictureRepository> pictureRepository;

        public PictureService(Lazy<IPictureRepository> pictureRepository)
        {
            this.pictureRepository = pictureRepository;
        }
        public int insert(Models.Picture entity)
        {
            Models.Picture picture = new Models.Picture();
           
            

            pictureRepository.Value.Add(entity);
            pictureRepository.Value.Save();
            return picture.ID;
        }
        public void Add(Models.Picture entity)
        {
            pictureRepository.Value.Add(entity);
        }

        public void Delete(Models.Picture entity)
        {
            pictureRepository.Value.Delete(entity);
        }

        public void Edit(Models.Picture entity)
        {
            pictureRepository.Value.Edit(entity);
        }

        public IQueryable<Models.Picture> FindBy(Expression<Func<Models.Picture, bool>> predicate)
        {
            return pictureRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.Picture> GetAll()
        {
            return pictureRepository.Value.GetAll();
        }

       

        public void Save()
        {
            pictureRepository.Value.Save();
        }
    }
}
