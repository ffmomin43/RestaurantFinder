using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using RestaurantFinder.WebUI.Common.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class RestaurantDishesController : Controller
    {
        private readonly Lazy<IRestaurantDishesService> restaurantDishesService;
        private readonly Lazy<IRestaurantService> restaurantService;

        private readonly Lazy<ILoggerFacade<RestaurantDishesController>> logger;

        public RestaurantDishesController(Lazy<IRestaurantDishesService> restaurantDishesService, Lazy<IRestaurantService> restaurantService, Lazy<ILoggerFacade<RestaurantDishesController>> logger)
        {
            this.restaurantDishesService = restaurantDishesService;
            this.restaurantService = restaurantService;

            this.logger = logger;
        }

        public ActionResult Index()
        {
            var dishes = from res in restaurantDishesService.Value.GetAll()
                         join r in restaurantService.Value.GetAll() on res.RestaurantId equals r.ID
                         select new RestaurantDishesvm
                         {
                             RestaurantID = r.ID,
                             DishID = res.ID,
                             Dishname = res.Name,
                             Name = r.Name


                         };
            return View(dishes);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}