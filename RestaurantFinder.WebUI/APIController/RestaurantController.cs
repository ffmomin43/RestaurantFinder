using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
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
        private readonly Lazy<IRestaurantsImagesService> restaurantsImages;
        private readonly Lazy<ICategoryMasterService> categoryMasterService;
        private readonly Lazy<ILoggerFacade<RestaurantController>> logger;
        
        public RestaurantController(
            Lazy<IRestaurantService> restaurantService, 
            Lazy<ILoggerFacade<RestaurantController>> logger,
            Lazy<ICategoryMasterService> categoryMasterService
            )
        {
            this.restaurantService = restaurantService;
            this.categoryMasterService = categoryMasterService;
            this.logger = logger;
        }

        // GET: api/Restaurant
        public IEnumerable<Restaurant> Get()
        {
            
            return restaurantService.Value.GetAll();
        }

        // GET: api/Restaurant/5
        public Restaurant Get(Guid id)
        {
           
            return restaurantService.Value.GetAll().Where(x => x.UniqueId == id).Single();

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
    }
}
