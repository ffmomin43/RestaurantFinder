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
    public class RestaurantLocationController : Controller
    {
        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<IRestaurantLocationService> restaurantLocationService;
        private readonly Lazy<ILoggerFacade<RestaurantLocationController>> logger;

        public RestaurantLocationController(Lazy<IRestaurantLocationService> restaurantLocationService, Lazy<IRestaurantService> restaurantService, Lazy<ILoggerFacade<RestaurantLocationController>> logger)
        {
            this.restaurantService = restaurantService;
            this.restaurantLocationService = restaurantLocationService;
            this.logger = logger;
        }
        // GET: RestaurantLocation
        public ActionResult Index()
        {
            var  restaurantlocationvms = from restaurant in restaurantLocationService.Value.GetAll()
                           join res in restaurantService.Value.GetAll() on restaurant.RestaurantId equals res.ID
                           select new Restaurantlocationvm
                           {
                               LocationName = restaurant.LocationName,
                               Name = res.Name,
                               Latitude = restaurant.Latitude,
                               Longitude=restaurant.Longitude,
                               ID=restaurant.ID,
                              
                              
                                 
                              

                           };
            return View(restaurantlocationvms);
        }

        // GET: RestaurantLocation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestaurantLocation/Create
        public ActionResult Create()
        {
            ViewBag.resturant = restaurantService.Value.GetAll();
            return View();
        }

        // POST: RestaurantLocation/Create
        [HttpPost]
        public ActionResult Create(RestaurantLocation restaurantLocation )
        {
            try
            {
                restaurantLocationService.Value.Add(restaurantLocation);
                restaurantLocationService.Value.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantLocation/Edit/5
        public ActionResult Edit(int id)
        {
            var location = restaurantLocationService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(location);
        }

        // POST: RestaurantLocation/Edit/5
        [HttpPost]
        public ActionResult Edit(RestaurantLocation restaurantLocation)
        {
            try
            {
                restaurantLocationService.Value.Edit(restaurantLocation);
                restaurantLocationService.Value.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return ViewBag.error = "some wrong";
            }
        }

        // GET: RestaurantLocation/Delete/5
        public ActionResult Delete(int id)
        {
             var location=   restaurantLocationService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(location);
        }

        // POST: RestaurantLocation/Delete/5
        [HttpPost]
        public ActionResult Delete(RestaurantLocation restaurantLocation)
        {
            try
            {
                restaurantLocationService.Value.Delete(restaurantLocation);
                restaurantLocationService.Value.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
