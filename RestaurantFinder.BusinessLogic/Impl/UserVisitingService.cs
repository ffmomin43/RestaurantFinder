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
public    class UserVisitingService : IUserVisitingService
    {
        private readonly Lazy<IUserVisitingRepository> userVisitingRepository;

        public UserVisitingService(Lazy<IUserVisitingRepository> userVisitingRepository)
        {
            this.userVisitingRepository= userVisitingRepository;
        }
        public int inserted(Models.UserVisiting entity)
        {



            userVisitingRepository.Value.Add(entity);
            userVisitingRepository.Value.Save();
            return entity.ID;
        }
        public void Add(Models.UserVisiting entity)
        {
            userVisitingRepository.Value.Add(entity);
        }

        public void Delete(Models.UserVisiting entity)
        {
            userVisitingRepository.Value.Delete(entity);
        }

        public void Edit(Models.UserVisiting entity)
        {
            userVisitingRepository.Value.Edit(entity);
        }

        public IQueryable<Models.UserVisiting> FindBy(Expression<Func<Models.UserVisiting, bool>> predicate)
        {
            return userVisitingRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.UserVisiting> GetAll()
        {
            return userVisitingRepository.Value.GetAll();
        }



        public void Save()
        {
            userVisitingRepository.Value.Save();
        }

        public bool Checklogin(string name, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
