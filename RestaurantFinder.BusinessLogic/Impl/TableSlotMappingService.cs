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
  public  class TableSlotMappingService : ITableSlotMappingService
    {
        private readonly Lazy<ITableSlotMappingRepository> tableSlotMappingRepository;

        public TableSlotMappingService(Lazy<ITableSlotMappingRepository> tableSlotMappingRepository)
        {
            this.tableSlotMappingRepository= tableSlotMappingRepository;
        }

        public void Add(Models.RestaurantSlotMapping entity)
        {

            tableSlotMappingRepository.Value.Add(entity);
        }

        public void Delete(Models.RestaurantSlotMapping entity)
        {
            tableSlotMappingRepository.Value.Delete(entity);
        }

        public void Edit(Models.RestaurantSlotMapping entity)
        {
            tableSlotMappingRepository.Value.Edit(entity);
        }

        public IQueryable<Models.RestaurantSlotMapping> FindBy(Expression<Func<Models.RestaurantSlotMapping, bool>> predicate)
        {
            return tableSlotMappingRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.RestaurantSlotMapping> GetAll()
        {
            return tableSlotMappingRepository.Value.GetAll();
        }

        public IEnumerable<int> GetTablebySlot(int resturantId, int slotId)
        {
         return   tableSlotMappingRepository.Value.GetAll()
                .Where(x => x.ResturantID == resturantId && x.RestaurantSlotId == slotId)
                .Select(x=>x.TableId);
        }


        //public bool IsExist(int restaurantId, int categoryId)
        //{
        //    return tableSlotMappingRepository.Value.GetAll().Where(x => x.CategoryId == categoryId && x.RestaurantId == restaurantId).Any();
        //}

        public void Save()
        {
            tableSlotMappingRepository.Value.Save();
        }
        public IEnumerable<int> GetTablebyRestaurant(int resturantId)
        {
            return tableSlotMappingRepository.Value.GetAll().Where(x => x.ResturantID == resturantId).Select(x => x.TableId);

        }

    }
}
