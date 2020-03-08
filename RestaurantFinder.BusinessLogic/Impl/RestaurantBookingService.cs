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
   public class RestaurantBookingService : IRestaurantBookingService
    {
        private readonly Lazy<IRestaurantBookingRepository> restaurantBookingRepository;

        public RestaurantBookingService(Lazy<IRestaurantBookingRepository> restaurantBookingRepository)
        {
            this.restaurantBookingRepository = restaurantBookingRepository;
        }

        public void Add(Models.RestaurantBooking entity)
        {

            restaurantBookingRepository.Value.Add(entity);
        }
        public bool Added(Models.RestaurantBooking entity)
        {

            restaurantBookingRepository.Value.Add(entity);
            restaurantBookingRepository.Value.Save();
            return true;
        }

        public void Delete(Models.RestaurantBooking entity)
        {
            restaurantBookingRepository.Value.Delete(entity);
        }

        public void Edit(Models.RestaurantBooking entity)
        {
            restaurantBookingRepository.Value.Edit(entity);
        }

        public IQueryable<Models.RestaurantBooking> FindBy(Expression<Func<Models.RestaurantBooking, bool>> predicate)
        {
            return restaurantBookingRepository.Value.FindBy(predicate);
        }


        public IQueryable<Models.RestaurantBooking> GetAll()
        {
            return restaurantBookingRepository.Value.GetAll();
        }



        //public bool IsExist(int restaurantId, int categoryId)
        //{
        //    return restaurantBookingRepository.Value.GetAll().Where(x => x.CategoryId == categoryId && x.RestaurantId == restaurantId).Any();
        //}

        public void Save()
        {
            restaurantBookingRepository.Value.Save();
        }

        public IEnumerable<int> GetBookTableOnSpecificDate(DateTime date)
        {
           return restaurantBookingRepository.Value.GetAll()
                .Where(x => x.BookingDate == date)
                .Select(x => x.TableID);

        }
        
        public IEnumerable<int> GetBookTableonSpecificRestaurant(int rid)
        {
            return restaurantBookingRepository.Value.GetAll()
                .Where(x => x.RestaurantID == rid)
                .Select(x => x.TableID);
        }
        public bool CheckUserBooking(string userid, DateTime date)
        {
            bool isvalid;
            var res= restaurantBookingRepository.Value.GetAll()
                .Where(x => x.UserId == userid && x.BookingDate == date).Count();
            if (res > 0)
            {

                isvalid = true;
            }
            else
            {
                isvalid = false;

            }
            return isvalid;
        }
    }
}
