using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using RestaurantFinder.WebUI.Common.helper;
using RestaurantFinder.WebUI.Common.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Configuration;
using System.Collections.Specialized;
namespace RestaurantFinder.WebUI.APIController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RestaurantController : ApiController
    {

        RestaurantBooking restaurantBooking;
        private readonly Lazy<IUsersService> usersService;

        private readonly Lazy<IRestaurantSlotService> restaurantSlotService;
        private readonly Lazy<IRestaurantCouponMasterService> couponMasterService;
        private readonly Lazy<IUserVisitingService> userVisitingService;

        private readonly Lazy<IRestaurantCategoryMappingService> categoryMappingService;
        private readonly Lazy<IRestaurantTablesService> restaurantTablesService;
        private readonly Lazy<ITableSlotMappingService> tableSlotMappingService;
        private readonly Lazy<IRestaurantsImagesService> restaurantsImage;
        private readonly Lazy<ICategoryMasterService> categoryMasterService;
        private readonly Lazy<IPictureService> pictureService;
        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<IRestaurantLocationService> restaurantLocationService;
        private readonly Lazy<IHomeBannerImageService> homeBannerImageService;
        private readonly Lazy<IRestaurantBookingService> restaurantBookingService;
        private readonly Lazy<ILoggerFacade<RestaurantController>> logger;

        public RestaurantController(
            Lazy<IRestaurantService> restaurantService,
            Lazy<ILoggerFacade<RestaurantController>> logger,
            Lazy<ICategoryMasterService> categoryMasterService,
            Lazy<IRestaurantCouponMasterService> couponMasterService,
            Lazy<IRestaurantTablesService> restaurantTablesService,
            Lazy<ITableSlotMappingService> tableSlotMappingService,
             Lazy<IUserVisitingService> userVisitingService,
            Lazy<IRestaurantSlotService> restaurantSlotService,
            Lazy<IRestaurantsImagesService> restaurantsImage,
            Lazy<IRestaurantCategoryMappingService> categoryMappingService,
            Lazy<IRestaurantBookingService> restaurantBookingService,
            Lazy<IPictureService> pictureService,
            Lazy<IRestaurantLocationService> restaurantLocationService,
            Lazy<IHomeBannerImageService> homeBannerImageService,
        Lazy<IUsersService> usersService
            )
        {
            this.restaurantService = restaurantService;
            this.categoryMasterService = categoryMasterService;
            this.restaurantsImage = restaurantsImage;
            this.restaurantBookingService = restaurantBookingService;
            this.usersService = usersService;
            this.restaurantSlotService = restaurantSlotService;
            this.couponMasterService = couponMasterService;
            this.pictureService = pictureService;
            this.restaurantLocationService = restaurantLocationService;
            this.categoryMappingService = categoryMappingService;
            this.homeBannerImageService = homeBannerImageService;
            this.tableSlotMappingService = tableSlotMappingService;
            this.restaurantTablesService = restaurantTablesService;
            this.userVisitingService = userVisitingService;
            this.logger = logger;
            this.restaurantBooking = new RestaurantBooking();
        }

        // GET: api/Restaurant
        [Route("api/Restaurant")]
        public IEnumerable<Restaurant> GetRestaurant()
        {


            return restaurantService.Value.GetAll();




        }
        [Route("api/RestaurantByUser")]
        public IEnumerable<Restaurant> GetRestaurantListbyuser(string name)
        {

            int id = usersService.Value.userid(name);
            return restaurantService.Value.GetAll().Where(x => x.UserId == id);




        }
        // GET: api/Restaurant/5
        public IEnumerable<RestaurantImagesVm> get(int id)
        {

            {
                var get = from n in restaurantService.Value.GetAll().Where(x => x.ID == id)
                          join s in restaurantsImage.Value.GetAll() on n.ID equals s.RestaurantId
                          join p in pictureService.Value.GetAll() on s.PictureId equals p.ID
                          select new RestaurantImagesVm
                          {
                              Name = n.Name,
                              AddressLine1 = n.AddressLine1,
                              AddressLine2 = n.AddressLine2,
                              Area = n.Area,
                              City = n.City,
                              PinCode = n.PinCode,
                              State = n.State,
                              RestaurantId = n.ID,
                              //RestaurantsImages = "/Images/Restaurant/" + p.url,


                          };
                return get;
            }

        }
        // POST: api/Restaurant
        public string Post([FromBody]Restaurant restaurant)
        {
            try
            {
                restaurant.UniqueId = Guid.NewGuid();

                this.restaurantService.Value.Add(restaurant);
                this.restaurantService.Value.Save();

                return "Record has been successfully Created.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        // PUT: api/Restaurant/5

        [Route("api/updatelocation")]
        public string Post(int RestoId, double Longitude, double Latitude)
        {
            try
            {
                var res = restaurantLocationService.Value.GetAll().Where(x => x.RestaurantId == RestoId).SingleOrDefault();

                res.Longitude = Longitude;
                res.Latitude = Latitude;

                restaurantLocationService.Value.Edit(res);
                restaurantLocationService.Value.Save();

                return "SUCCESS";

            }
            catch (Exception ex)
            {
                return "Please Enter Loction Restaurant Location does not Exist  " + ex.Message;
            }
        }

        // DELETE: api/Restaurant/5
        public void Delete(int id)
        {
        }

        [Route("api/categories")]
        public IEnumerable<CategoryMaster> GetCategoryMasters()
        {

            return (from n in categoryMasterService.Value.GetAll().ToList()
                    join categoryMappingService in categoryMappingService.Value.GetAll() on
                    n.ID equals categoryMappingService.CategoryId
                    select n).Distinct();
        }


        [Route("api/login")]
        public bool Get(string user, string pass)
        {
            return usersService.Value.Checklogin(user, pass);
        }


        [Route("api/getbylocation")]
        public IEnumerable<Restaurantlocationvm> GetRestaurants(double restorantLat, double resturantLong)
        {

            var model = from res in restaurantService.Value.GetAll().ToList()
                        join loc in restaurantLocationService.Value.GetAll().ToList() on res.ID equals loc.RestaurantId
                        select new Restaurantlocationvm()
                        {
                            ID = loc.ID,
                            Name = res.Name,
                            Latitude = loc.Latitude,
                            Longitude = loc.Longitude,
                            Thumbimageurl = res.ThumbnailImageUrl,
                            RestaurantId = res.ID,
                            Starting_Price = res.StartingPrice,

                            Categories = (from cm in categoryMappingService.Value.GetAll().ToList().Where(x => x.RestaurantId == res.ID)
                                          join c in categoryMasterService.Value.GetAll().ToList() on cm.CategoryId equals c.ID
                                          select c.Name).ToList(),




                            LocationName = loc.LocationName,
                            Distance = GeoLocation.GetDistanceBetweenPoints(loc.Latitude, loc.Longitude, restorantLat, resturantLong),

                        };

            return model.ToList().OrderBy(x => x.Distance).Take(5);
        }

        [Route("api/RestaurantbyCategory")]
        public IEnumerable<RestaurantCategorymappingVm> GetRestaurantbyCategory(int Categoryid)
        {
            var list = from catemapping in categoryMappingService.Value.GetAll().Where(x => x.CategoryId == Categoryid)
                       join catemaster in categoryMasterService.Value.GetAll()
                       on catemapping.CategoryId equals catemaster.ID
                       join Res in restaurantService.Value.GetAll() on catemapping.RestaurantId
                       equals Res.ID
                       select new RestaurantCategorymappingVm
                       {
                           RestaurantName = Res.Name,
                           categoryName = catemaster.Name,
                           ResMappingid = catemapping.ID,
                           CreateDate = catemapping.CreatedDate,
                           Url = Res.ThumbnailImageUrl,
                           Resid = Res.ID,
                           RestaurantAddress = Res.AddressLine1


                       };

            return list;
        }

        [Route("api/banner")]
        public IEnumerable<HomeBannerImage> GetHomeBannerImages()
        {
            string bannerImageCountString = ConfigurationManager.AppSettings.Get("homepage:banner-image-count");
            int bannerImageCount = !string.IsNullOrEmpty(bannerImageCountString) ? Convert.ToInt32(bannerImageCountString) : 0;

            return homeBannerImageService.Value.GetAll().OrderByDescending(x => x.CreatedDate).Take(bannerImageCount);
        }

        [Route("api/trending")]
        public IEnumerable<RestaurantImagesVm> GetTrendingRestaurants()
        {
            string trendingCountString = ConfigurationManager.AppSettings.Get("homepage:trending-count");
            int trendingCount = !string.IsNullOrEmpty(trendingCountString) ? Convert.ToInt32(trendingCountString) : 0;

            return
               from n in restaurantService.Value.GetAll().Where(x => x.IsTrending == true).Take(trendingCount)
               select new RestaurantImagesVm
               {
                   AddressLine1 = n.AddressLine1,
                   AddressLine2 = n.AddressLine2,
                   Area = n.Area,
                   RestaurantId = n.ID,
                   City = n.City,
                   Name = n.Name,
                   Thumburl = n.ThumbnailImageUrl,

                   PinCode = n.PinCode,
                   State = n.State,
                   IsTrending = n.IsTrending,



               };

        }
        [Route("api/RestaurantBySlot")]
        public IEnumerable<Restaurantslotvm> GetRestaurantBySlot(int id)
        {
            var list = from rs in restaurantSlotService.Value.GetAll().Where(x=>x.Restaurantid==id)


                       select new Restaurantslotvm
                       {

                           SlotName = rs.SlotName,
                           RestauranrId = rs.Restaurantid,
                           // tableSlotMappingID
                           SlotID = rs.ID,



                       };
            return list;
        }


        [Route("api/CouponAvailable")]
        public IEnumerable<couponsvm>  GetCouponsList()
            {
            var list = from c in couponMasterService.Value.GetAll()
                       join r in this.restaurantService.Value.GetAll() on c.RestaurantId equals r.ID
                       select new couponsvm
                       {
                           CouponsCode = c.CouponCode,
                           Discount=c.Discount,
                           Restaurant=r.Name,
                           ValidUntil=c.EndDate,
                          
              

                       };
            return list;


}


        [Route("api/scan")]
        public string PostQR(string qrcode,string userid,double Latitude, double Longitude)
        {
            DateTime date = DateTime.Now.Date;
            if (restaurantBookingService.Value.CheckUserBooking(userid, date))
            {
                var res = restaurantService.Value.GetAll().Where(x => x.UniqueId.ToString() == qrcode).Single();
                if (!res.Name.Any())
                {
                    return "Res Not Found";
                }
                var loc = restaurantLocationService.Value.GetAll().Where(x => x.RestaurantId == res.ID).SingleOrDefault();
                if (!loc.LocationName.Any())
                {
                    return "Not Found";
                }
                var Distance = GeoLocation.GetDistanceBetweenPoints(loc.Latitude, loc.Longitude, Latitude, Longitude);

                if (res.ID != 0)
                {
                    userVisitingService.Value.SaveUserVistingParameters(
                     userid,
                     Guid.NewGuid(),
                     qrcode,
                     res.ID,
                     loc.Longitude,
                      loc.Latitude
                        );
                    var restaurant = restaurantBookingService.Value.GetAll().Where(x => x.RestaurantID == res.ID && x.UserId == userid).Single();
                    restaurant.BookingStatus = "Visited";
                    restaurantBookingService.Value.Edit(restaurant);
                    restaurantBookingService.Value.Save();
                    return "save";
                }
            }
           

            else
            {

                return "Booking Not found";
            }
            return "Booking not found";
        }
        [Route("api/UserRestaurantcount")]
        public IEnumerable<object> GetUserRestaurantcount(string userid)
        {

            var list = from u in userVisitingService.Value.GetAll().Where(x => x.Userid == userid)

                       join r in restaurantService.Value.GetAll() on u.RestaurantID equals r.ID
                       group r by new {r.Name, r.ID,r.ThumbnailImageUrl } into cg
                       select new 
                       {
                        Restaurantname = cg.Key.Name,
                           TotalCount = cg.Count(),
                           thumbUrl=cg.Key.ThumbnailImageUrl,
                          
                          
                           
                            
                          

                       };

            return list;


        //    var list = userVisitingService.Value.GetAll().Where(x => x.Userid == userid)

        //               .GroupBy(x => new { x.RestaurantID })
        //.Select(group => new { Restaurantid = group.Key, Count = group.Count() })
        //.OrderByDescending(x => x.Count);
        //    return list;


        }

        [Route("api/UserVistingList")]
        public IEnumerable<UserVisiting> GetUserVistingList()

        {
           return userVisitingService.Value.GetAll();

        }
        [Route("api/Cancelbooking")]
        public string PostCancelBooking(string userid,int resid,string bookingid)

        {
            var res = restaurantBookingService.Value.GetAll().ToList().
                 Where(x => x.UserId == userid & x.RestaurantID == resid &
                 x.UniqueId.ToString() == bookingid);
            if (!res.Any())
            {
                return "Some Error Plese Contact Restaurant";

            }
            else
            {
                res.Single().IsCancel = false;
                res.Single().UpdatedDate = DateTime.Now;
                res.Single().BookingStatus = "Cancel";
                restaurantBookingService.Value.Edit(res.Single());
                restaurantBookingService.Value.Save();

                return "Cancel booking";

            }
        }
        [Route("api/CancelbookingList")]
        public IEnumerable<BookingUserRestaurantList> GetCancellist(string userid)

        {
            var list = from bookingres in restaurantBookingService.Value.GetAll().ToList().Where(x => x.UserId == userid && x.IsCancel == false)
                       join r in restaurantService.Value.GetAll().ToList() on bookingres.RestaurantID equals r.ID
                       join rtable in restaurantTablesService.Value.GetAll().ToList() on bookingres.TableID equals rtable.ID
                       join slot in restaurantSlotService.Value.GetAll().ToList() on bookingres.Slotid equals slot.ID
                       select new BookingUserRestaurantList

                       {
                           RestaurantId = bookingres.RestaurantID,
                           Tableid = bookingres.TableID,
                           BookingDate = bookingres.BookingDate,
                           UserId = bookingres.UserId,
                           RestaurantName = r.Name,
                          
                           Restaurantimage = r.ThumbnailImageUrl,
                           NoOfPerson = rtable.TableCapacity,
                           slotname = slot.SlotName,
                           Bookingid = bookingres.UniqueId.ToString().Split('-')[0]




                       };
            return list;



        }





        [Route("api/autocomplete")]
        public IEnumerable<KeyValuePair<int, string>> GetAutocomplete(string searchTerm)
        {

            return restaurantService.Value.GetAll().Where(x => x.Name.Contains(searchTerm)).ToList().Select(n => new KeyValuePair<int, string>(n.ID, n.Name));
        }
        [Route("api/RestaurantDetails")]
        public IEnumerable<RestaurantDetailsvm> GetRestaurantDeatails(int id)
        {

            var list = from r in restaurantService.Value.GetAll().ToList().Where(x => x.ID == id)

                           //join c in categoryMappingService.Value.GetAll() on r.ID equals c.RestaurantId
                           ////join cs in categoryMasterService.Value.GetAll().ToArray() on c.CategoryId equals cs.ID
                       select new RestaurantDetailsvm
                       {
                           Email = r.RestaurantEmail,
                           Description = r.Description,
                           Number = r.Number,
                           Price = r.StartingPrice,
                           openingTime = r.openingTime,
                           closingTime = r.closingTime,
                           UniqueID = r.UniqueId,
                           RestaurantName = r.Name,

                           CategoryName = (from cm in categoryMappingService.Value.GetAll().ToList().Where(x => x.RestaurantId == id)
                                           join c in categoryMasterService.Value.GetAll().ToList() on cm.CategoryId equals c.ID
                                           select c.Name).ToList()



                       ,
                           //categories = cs.Name[],
                           Url = r.ThumbnailImageUrl

                       };
            return list;





        }

        [Route("api/Reservation")]
        public bool GetAvailabletable(int personCount, int resturantId)
        {

            var tablebyresrtraunt = tableSlotMappingService.Value.GetTablebyRestaurant(resturantId);
            if (!tablebyresrtraunt.Any())
            {
                return false;
            }
            var bookingTableid = restaurantBookingService.Value.GetBookTableonSpecificRestaurant(resturantId);
            if(!bookingTableid.Any())
            {
                return false;

            }
            var AvailabeTablelist = tablebyresrtraunt.Except(bookingTableid);
            if(!AvailabeTablelist.Any())
            {
                return false;

            }

            var availableTableObjects = restaurantTablesService.Value.GetAll().ToList().Where(x => AvailabeTablelist.Contains(x.ID));
                               
            //get final table
            var finaltable = availableTableObjects.ToList().Where(x => x.TableCapacity >= personCount).OrderBy(x => x.TableCapacity).FirstOrDefault();

            if (finaltable !=null)
            {

                return true;

            }
            else
            {


                return false;
            }


        }
        [Route("api/Reservationbydate")]
        public bool GetAvailabletablebydate(DateTime date, int resturantId, int slotId, int personcount)
        {

            var tableids = tableSlotMappingService.Value.GetTablebySlot(resturantId, slotId);

            if (!tableids.Any())
            {
                return false ;
            }

            //get all table id book already
            var bookingTableid = restaurantBookingService.Value.GetBookTableOnSpecificDate(date);

            var AvailabeTablelist = tableids.Except(bookingTableid);
            if (!AvailabeTablelist.Any())
            {
                return false;
            }


            var availableTableObjects = restaurantTablesService.Value.GetAll().Where(x => AvailabeTablelist.Contains(x.ID));

            if (!availableTableObjects.Any())
            {
                return true;
            }
            //get final table
            var finaltable = availableTableObjects.Where(x => x.TableCapacity >= personcount).OrderBy(x => x.TableCapacity).FirstOrDefault();
            if (finaltable!=null)
            {
                return true;
            }
            else
            {

                return false;
            }

        }





        [Route("api/RestaurantBookingByUser")]
        public IEnumerable<BookingUserRestaurantList> GetRestaurantBookingByUser(string userid)
        {
            var list = from bookingres in restaurantBookingService.Value.GetAll().ToList().Where(x => x.UserId == userid )
                       join r in restaurantService.Value.GetAll().ToList() on bookingres.RestaurantID equals r.ID
                       join rtable in restaurantTablesService.Value.GetAll().ToList() on bookingres.TableID equals rtable.ID
                       join slot in restaurantSlotService.Value.GetAll().ToList() on bookingres.Slotid equals slot.ID
                       select new BookingUserRestaurantList

                       {
                           RestaurantId = bookingres.RestaurantID,
                           Tableid = bookingres.TableID,
                           BookingDate = bookingres.BookingDate,
                           UserId = bookingres.UserId,
                           RestaurantName = r.Name,
                           Restaurantimage = r.ThumbnailImageUrl,
                           NoOfPerson = rtable.TableCapacity,
                           slotname = slot.SlotName,
                           Bookingid=bookingres.UniqueId.ToString().Split('-')[0]




                       };
            return list;

        }

        [Route("api/ConformationBooking")]
        public BookingResponseViewmodel PostAvailabletablebydate(DateTime date, string Userid, int resturantId, int slotId, int personcount)
        {
            BookingResponseViewmodel bookingViewmodel = new BookingResponseViewmodel();

            var tableids = tableSlotMappingService.Value.GetTablebySlot(resturantId, slotId);

            if (!tableids.Any())
            {
                return GetEmptyBookingViewmodel();
            }

            //get all table id book already
            var bookingTableid = restaurantBookingService.Value.GetBookTableOnSpecificDate(date);

            // availabe table list
            var AvailabeTablelist = tableids.Except(bookingTableid);

            if (!AvailabeTablelist.Any())
            {
                return GetEmptyBookingViewmodel();
            }
            
            var availableTableObjects = restaurantTablesService.Value.GetAll()
                .Where(x => AvailabeTablelist.Contains(x.ID));

            if(!availableTableObjects.Any())
            {
                return GetEmptyBookingViewmodel();
            }

            //get final table
            var finaltable = availableTableObjects
                .Where(x => x.TableCapacity >= personcount)
                .OrderBy(x=>x.TableCapacity).FirstOrDefault();

            // table id is greater then 0 then record insert
            if (finaltable != null)
            {
                restaurantBooking.BookingDate = date;
                restaurantBooking.TableID = finaltable.ID;
                restaurantBooking.Slotid = slotId;
                restaurantBooking.UserId = Userid;
                restaurantBooking.RestaurantID = resturantId;
                restaurantBooking.UniqueId = Guid.NewGuid();
                restaurantBooking.BookingStatus = "Not Visiting";
                restaurantBookingService.Value.Add(restaurantBooking);

                restaurantBookingService.Value.Save();

                
                return GetBookingViewmodel(finaltable.ID);
            }
            else
            {
                return GetEmptyBookingViewmodel();
            }
        }

        private BookingResponseViewmodel GetEmptyBookingViewmodel()
        {
            return new BookingResponseViewmodel()
            {
                BookingId = Guid.Empty.ToString().Split('-')[0],
                Status = false,
                TableId = 0
            };
        }

        private BookingResponseViewmodel GetBookingViewmodel(int tableId)
        {   
            return new BookingResponseViewmodel()
            {
                BookingId = Guid.NewGuid().ToString().Split('-')[0],
                Status = true,
                TableId = tableId
            };

        }
    }







    //[Route("api/Availabletable")]
    //public IEnumerable<RestaurantBooking> GetAvailabletable(DateTime date, int resid)
    //{
    //    var id = restaurantBookingService.Value.GetAll().Where(x => x.RestaurantID == resid && x.BookingDate == date).Select(x => x.TableSlotMappingID);
    //    return id;

    //   ;
    //}

    public class LocationRestoRequest
    {

        public int RestoId { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }


}