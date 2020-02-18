using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class RestaurantSlotController : Controller
    {
        private readonly Lazy<IRestaurantSlotService> restaurantSlotService;

        public RestaurantSlotController(
            Lazy<IRestaurantSlotService> restaurantSlotService
            )
        {
            this.restaurantSlotService = restaurantSlotService;
        }

        // GET: RestaurantSlot
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create( RestaurantSlot restaurantSlot)
        {
            restaurantSlotService.Value.Add(restaurantSlot);
            restaurantSlotService.Value.Save();
            return View();

        }
    }

}