using RestaurantFinder.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class RestaurantCategoryMappingController : Controller
    {

        
        private readonly Lazy<ICategoryMasterService> categoryMasterService;
        private readonly Lazy<IRestaurantService> restaurantService;

        public RestaurantCategoryMappingController(
            Lazy<ICategoryMasterService> categoryMasterService,
             Lazy<IRestaurantService> restaurantService
            )
        {
            this.categoryMasterService = categoryMasterService;
            this.restaurantService = restaurantService;
        }

        // GET: RestaurantCategoryMapping
        public ActionResult Index()
        {
            
            return View();
        }
    }
}