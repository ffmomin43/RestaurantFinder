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
    public class CategoryMasterService : ICategoryMasterService
    {
        private readonly Lazy<ICategoryMasterRepository> categoryMasterRepository;

        public CategoryMasterService(Lazy<ICategoryMasterRepository> categoryMasterRepository)
        {
            this.categoryMasterRepository = categoryMasterRepository;
        }

        public void Add(Models.CategoryMaster entity)
        {

            categoryMasterRepository.Value.Add(entity);
        }

        public void Delete(Models.CategoryMaster entity)
        {
            categoryMasterRepository.Value.Delete(entity);
        }

        public void Edit(Models.CategoryMaster entity)
        {
            categoryMasterRepository.Value.Edit(entity);
        }

        public IQueryable<Models.CategoryMaster> FindBy(Expression<Func<Models.CategoryMaster, bool>> predicate)
        {
            return categoryMasterRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.CategoryMaster> GetAll()
        {
            return categoryMasterRepository.Value.GetAll();
        }

        public bool IsExist(string name)
        {
            return categoryMasterRepository.Value.GetAll().Where(x => x.Name == name).Any();
        }

        public void Save()
        {
            categoryMasterRepository.Value.Save();
        }
    }
}
