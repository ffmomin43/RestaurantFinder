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
  public  class RolesService : IRolesService
    { 
        private readonly Lazy<IRolesRepository> rolesRepository;

    public RolesService(Lazy<IRolesRepository> rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public void Add(Models.Role entity)
        {

            rolesRepository.Value.Add(entity);
        }

        public void Delete(Models.Role entity)
        {
            rolesRepository.Value.Delete(entity);
        }
        public int insert(Models.Role entity)
        {
            return 1;
        }

        public void Edit(Models.Role entity)
        {
            rolesRepository.Value.Edit(entity);
        }

        public IQueryable<Models.Role> FindBy(Expression<Func<Models.Role, bool>> predicate)
        {
            return rolesRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.Role> GetAll()
        {
            return rolesRepository.Value.GetAll();
        }

        public bool IsExist(string name)
        {
            return rolesRepository.Value.GetAll().Where(x => x.Name == name).Any();
        }

        public void Save()
        {
            rolesRepository.Value.Save();
        }

        public bool Checklogin(string name, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
  