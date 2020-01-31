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
   public class RestaurantTablesService: IRestaurantTablesService
    { 
     private readonly Lazy<IRestaurantTableRepository> restaurantTableRepository;

        public RestaurantTablesService(Lazy<IRestaurantTableRepository>restaurantTableRepository)
    {
            this.restaurantTableRepository= restaurantTableRepository;
    }

    public void Add(Models.RestaurantTable entity)
    {

       restaurantTableRepository.Value.Add(entity);
    }

    public void Delete(Models.RestaurantTable entity)
    {
       restaurantTableRepository.Value.Delete(entity);
    }

    public void Edit(Models.RestaurantTable entity)
    {
       restaurantTableRepository.Value.Edit(entity);
    }

    public IQueryable<Models.RestaurantTable> FindBy(Expression<Func<Models.RestaurantTable, bool>> predicate)
    {
        return  restaurantTableRepository.Value.FindBy(predicate);
    }


    public IQueryable<Models.RestaurantTable> GetAll()
    {
         return   restaurantTableRepository.Value.GetAll();
    }

        public bool IsExist(string name)
        {
           return restaurantTableRepository.Value.GetAll().Where(x => x.TableName == name).Any();
        }

        public void Save()
    {
       restaurantTableRepository.Value.Save();
    }
}
}
