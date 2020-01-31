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
 public   class PermissionService : IPermissionService
    {
        private readonly Lazy<IPermissionRepository> permissionRepository;

        public PermissionService(Lazy<IPermissionRepository> permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        public void Add(Models.Permission entity)
        {

             permissionRepository.Value.Add(entity);
        }

        public void Delete(Models.Permission entity)
        {
             permissionRepository.Value.Delete(entity);
        }

        public void Edit(Models.Permission entity)
        {
             permissionRepository.Value.Edit(entity);
        }

        public IQueryable<Models.Permission> FindBy(Expression<Func<Models.Permission, bool>> predicate)
        {
            return  permissionRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.Permission> GetAll()
        {
            return  permissionRepository.Value.GetAll();
        }

        public bool IsExist(string name)
        {
            return  permissionRepository.Value.GetAll().Where(x => x.Name == name).Any();
        }

        public void Save()
        {
             permissionRepository.Value.Save();
        }
    }
}
