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
 public class RestaurantCouponMasterService: IRestaurantCouponMasterService
    {

        private readonly Lazy<IRestaurantCouponMasterRepository> restaurantCouponMasterRepository;

        public RestaurantCouponMasterService(Lazy<IRestaurantCouponMasterRepository> restaurantCouponMasterRepository)
        {
            this.restaurantCouponMasterRepository = restaurantCouponMasterRepository;
        }

        public void Add(Models.RestaurantCouponsMaster entity)
        {

            restaurantCouponMasterRepository.Value.Add(entity);
        }

        public void Delete(Models.RestaurantCouponsMaster entity)
        {
            restaurantCouponMasterRepository.Value.Delete(entity);
        }

        public int insert(Models.RestaurantCouponsMaster entity)
        {
            return 1;
        }
        public void Edit(Models.RestaurantCouponsMaster entity)
        {
            restaurantCouponMasterRepository.Value.Edit(entity);
        }

        public IQueryable<Models.RestaurantCouponsMaster> FindBy(Expression<Func<Models.RestaurantCouponsMaster, bool>> predicate)
        {
            return restaurantCouponMasterRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.RestaurantCouponsMaster> GetAll()
        {
            return restaurantCouponMasterRepository.Value.GetAll();
        }

        public bool IsExist(string name)
        {
            return restaurantCouponMasterRepository.Value.GetAll().Where(x => x.CouponName == name).Any();
        }

        public void Save()
        {
            restaurantCouponMasterRepository.Value.Save();
        }

        public bool Checklogin(string name, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
