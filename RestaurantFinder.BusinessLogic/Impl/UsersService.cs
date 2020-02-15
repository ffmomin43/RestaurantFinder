using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Repository;
using RestaurantFinder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Impl
{
   public class UsersService : IUsersService
    {
        private readonly Lazy<IUsersRepository> usersRepository;

        public UsersService(Lazy<IUsersRepository> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public void Add(Models.User entity)
        {

            usersRepository.Value.Add(entity);
        }

        public int Insert(Models.User entity)
        {
            usersRepository.Value.Add(entity);
            usersRepository.Value.Save();
            return entity.ID;
        }
        public void Delete(Models.User entity)
        {
            usersRepository.Value.Delete(entity);
        }

        public void Edit(Models.User entity)
        {
            usersRepository.Value.Edit(entity);
        }

        public IQueryable<Models.User> FindBy(Expression<Func<Models.User, bool>> predicate)
        {
            return usersRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.User> GetAll()
        {
            return usersRepository.Value.GetAll();
        }

        public bool IsExist(string name)
        {
            return usersRepository.Value.GetAll().Where(x => x.Name== name).Any();
        }

        public void Save()
        {
            usersRepository.Value.Save();
        }

        public bool Checklogin(string name, string pass)
        {
            RestaurantContext restaurantContext = new RestaurantContext();
            bool isvalid;
            var count = restaurantContext.User.ToList<Models.User>().Where(x => x.Name == name && x.Password == pass).Count();
            if (count > 0)
            {
                isvalid = true;

            }
            else
            {

                isvalid = false;
            }
            return isvalid;
        }
        public int userid(string name)
        {

            return usersRepository.Value.GetAll().Where(y => y.Name == name).Select(x => x.ID).SingleOrDefault();
        }
    }
}

