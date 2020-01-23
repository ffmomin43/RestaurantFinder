using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using RestaurantFinder.WebUI.Common.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantFinder.WebUI.APIController
{
    
    public class RestaurantController : ApiController
    {

        private readonly Lazy<IRestaurantService> restaurantService;
        
        private readonly Lazy<ILoggerFacade<RestaurantController>> logger;
        
        public RestaurantController(Lazy<IRestaurantService> restaurantService, Lazy<ILoggerFacade<RestaurantController>> logger)
        {
            this.restaurantService = restaurantService;
            this.logger = logger;
        }
        // GET: api/Restaurant
        public IEnumerable<Restaurant> Get()
        {
            return this.restaurantService.Value.GetAll();
        }

        // GET: api/Restaurant/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Restaurant
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Restaurant/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Restaurant/5
        public void Delete(int id)
        {
        }
    }
}
