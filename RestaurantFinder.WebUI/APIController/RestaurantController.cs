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

namespace RestaurantFinder.WebUI.APIController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RestaurantController : ApiController
    {

        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<IUsersService> usersService;
        private readonly Lazy<IRestaurantsImagesService> restaurantsImage;
        private readonly Lazy<ICategoryMasterService> categoryMasterService;
        private readonly Lazy<IPictureService> pictureService;
        private readonly Lazy<IRestaurantLocationService> restaurantLocationService;
        private readonly Lazy<ILoggerFacade<RestaurantController>> logger;

        public RestaurantController(
            Lazy<IRestaurantService> restaurantService,
            Lazy<ILoggerFacade<RestaurantController>> logger,
            Lazy<ICategoryMasterService> categoryMasterService,
            Lazy<IRestaurantsImagesService> restaurantsImage,
            Lazy<IPictureService> pictureService,
            Lazy<IRestaurantLocationService> restaurantLocationService,
            Lazy<IUsersService> usersService
            )
        {
            this.restaurantService = restaurantService;
            this.categoryMasterService = categoryMasterService;
            this.restaurantsImage = restaurantsImage;
            this.usersService = usersService;
            this.pictureService = pictureService;
            this.restaurantLocationService = restaurantLocationService;
            this.logger = logger;
        }

        // GET: api/Restaurant
        [Route("api/Restaurant")]
        public IEnumerable<RestaurantimagesVm> Get()
        {

            {
                var get = from n in restaurantService.Value.GetAll()
                          join s in restaurantsImage.Value.GetAll() on n.ID equals s.RestaurantId
                          join p in pictureService.Value.GetAll() on s.PictureId equals p.ID
                          select new RestaurantimagesVm
                          {
                              Name = n.Name,
                              AddressLine1 = n.AddressLine1,
                              AddressLine2 = n.AddressLine2,
                              Area=n.Area,
                              City=n.City,
                              PinCode=n.PinCode,
                              State=n.State,
                              id = n.ID,
                              RestaurantsImages ="/Images/Restaurant/" + p.url,


                          };
                return get;
            }
        }
        // GET: api/Restaurant/5
        public IEnumerable<RestaurantimagesVm> get(int id)
        {

            {
                var get = from n in restaurantService.Value.GetAll().Where(x=>x.ID==id)
                          join s in restaurantsImage.Value.GetAll() on n.ID equals s.RestaurantId
                          join p in pictureService.Value.GetAll() on s.PictureId equals p.ID
                          select new RestaurantimagesVm
                          {
                              Name = n.Name,
                              AddressLine1 = n.AddressLine1,
                              AddressLine2 = n.AddressLine2,
                              Area = n.Area,
                              City = n.City,
                              PinCode = n.PinCode,
                              State = n.State,
                              id = n.ID,
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
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        // PUT: api/Restaurant/5
        public void Put(int id, [FromBody]string value)
        {
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
        public bool Get(string user,string pass)
        {
           if( usersService.Value.Checklogin(user, pass))
            {

                return true;

            }
           else
            {

                return false;
            }
        }

        [Route("api/getbylocation")]
        public IEnumerable<Restaurantlocationvm> GetRestaurants(double restorantLat, double resturantLong)
        {

            var model = from res in restaurantService.Value.GetAll()
                        join loc in restaurantLocationService.Value.GetAll() on res.ID equals loc.RestaurantId
                        select new Restaurantlocationvm()
                        {
                            ID = loc.ID,
                            Latitude = loc.Latitude,
                            Longitude = loc.Latitude,
                            LocationName = loc.LocationName,
                            Distance = GeoLocation.GetDistanceBetweenPoints(loc.Latitude, loc.Longitude, restorantLat, resturantLong),

                        };

            return model.ToList().OrderBy(x => x.Distance).Take(5);
        }

    }


}
