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

       
        private readonly Lazy<IUsersService> usersService;
        private readonly Lazy<IRestaurantCategoryMappingService> categoryMappingService;
        private readonly Lazy<IRestaurantsImagesService> restaurantsImage;
        private readonly Lazy<ICategoryMasterService> categoryMasterService;
        private readonly Lazy<IPictureService> pictureService;
        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<IRestaurantLocationService> restaurantLocationService;
        private readonly Lazy<IHomeBannerImageService> homeBannerImageService;
        private readonly Lazy<ILoggerFacade<RestaurantController>> logger;

        public RestaurantController(
            Lazy<IRestaurantService> restaurantService,
            Lazy<ILoggerFacade<RestaurantController>> logger,
            Lazy<ICategoryMasterService> categoryMasterService,
            Lazy<IRestaurantsImagesService> restaurantsImage,
            Lazy<IRestaurantCategoryMappingService> categoryMappingService,
            Lazy<IPictureService> pictureService,
            Lazy<IRestaurantLocationService> restaurantLocationService,
            Lazy<IHomeBannerImageService> homeBannerImageService,
        Lazy<IUsersService> usersService
            )
        {
            this.restaurantService = restaurantService;
            this.categoryMasterService = categoryMasterService;
            this.restaurantsImage = restaurantsImage;
            this.usersService = usersService;
            this.pictureService = pictureService;
            this.restaurantLocationService = restaurantLocationService;
            this.categoryMappingService = categoryMappingService;
            this.homeBannerImageService = homeBannerImageService;
            this.logger = logger;
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
            return restaurantService.Value.GetAll().Where(x=>x.UserId==id);




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
                              RestaurantsImages = "/Images/Restaurant/" + p.url,


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
        public string Post(int RestoId,double Longitude,double Latitude)
        {
            try
            {
                var res = restaurantLocationService.Value.GetAll().Where(x => x.RestaurantId == RestoId).SingleOrDefault();

                res.Longitude =Longitude;
                res.Latitude =Latitude;
                
                restaurantLocationService.Value.Edit(res);
                restaurantLocationService.Value.Save();

                return "SUCCESS";
                
            }
            catch (Exception ex)
            {
                return "Please Enter Loction Restaurant Location not Exist  " + ex.Message;
            }
        }

        // DELETE: api/Restaurant/5
        public void Delete(int id)
        {
        }

        [Route("api/categories")]
        public IEnumerable<CategoryMaster> GetCategoryMasters()
        {
            return categoryMasterService.Value.GetAll();
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

                            Latitude = loc.Latitude,
                            Longitude = loc.Longitude,
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
                           id = catemapping.ID,
                           CreateDate = catemapping.CreatedDate
                       };

            return list;
        }

        [Route("api/banner")]
        public IEnumerable<HomeBannerImage> GetHomeBannerImages()
        {
            string bannerImageCountString = ConfigurationManager.AppSettings.Get("homepage:banner-image-count");
            int bannerImageCount = !string.IsNullOrEmpty(bannerImageCountString)?Convert.ToInt32(bannerImageCountString) : 0; 
            
            return homeBannerImageService.Value.GetAll().OrderByDescending(x=>x.CreatedDate).Take(bannerImageCount);
        }

        [Route("api/trending")]
        public IEnumerable<RestaurantImagesVm> GetTrendingRestaurants()
        {
            string trendingCountString = ConfigurationManager.AppSettings.Get("homepage:trending-count");
            int trendingCount = !string.IsNullOrEmpty(trendingCountString) ? Convert.ToInt32(trendingCountString) : 0;

            return restaurantService.Value.GetAll().Where(x=>x.IsTrending==true).Take(trendingCount).Select(res => new RestaurantImagesVm()
            {
                AddressLine1 = res.AddressLine1,
                AddressLine2 = res.AddressLine2,
                Area = res.Area,
                RestaurantId = res.ID,
                City = res.City,
                Name = res.Name,
                PinCode = res.PinCode,                
                State = res.State,
                IsTrending = res.IsTrending
            });

        }

        [Route("api/scan")]
        public string PostQRCode(string userid, string qrcode)
        {
            return "SUCCESS";
        }
    }

    public class LocationRestoRequest
    {
      
        public int RestoId { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
