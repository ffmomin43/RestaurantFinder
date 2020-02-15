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
public    class UserRolesService: IUserRolesService
    {
        private readonly Lazy<IUserRolesRepository> userRolesRepository;

    public UserRolesService(Lazy<IUserRolesRepository> userRolesRepository)
    {
        this.userRolesRepository= userRolesRepository;
    }
        public void Add(Models.UserRole entity)
        {

            userRolesRepository.Value.Add(entity);
        }

        public void Delete(Models.UserRole entity)
        {
            userRolesRepository.Value.Delete(entity);
        }

        
        public void Edit(Models.UserRole entity)
        {
            userRolesRepository.Value.Edit(entity);
        }

        public IQueryable<Models.UserRole> FindBy(Expression<Func<Models.UserRole, bool>> predicate)
        {
            return userRolesRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.UserRole> GetAll()
        {
            return userRolesRepository.Value.GetAll();
        }

       

        public void Save()
        {
            userRolesRepository.Value.Save();
        }

       
    }

}
