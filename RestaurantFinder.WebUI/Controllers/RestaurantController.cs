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
    public class RestaurantController : Controller
    {
        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<ILoggerFacade<RestaurantController>> logger;

        public RestaurantController(Lazy<IRestaurantService> restaurantService, Lazy<ILoggerFacade<RestaurantController>> logger)
        {
            this.restaurantService = restaurantService;
            this.logger = logger;
        }

        // GET: Restaurant
        public ActionResult checking()
        {
            return View();

        }
        public ActionResult Index()
        {
            var model = restaurantService.Value.GetAll();
            return View(model);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)


        {
            try
            {
                restaurant.UniqueId = Guid.NewGuid();

                this.restaurantService.Value.Add(restaurant);
                this.restaurantService.Value.Save();
                return RedirectToAction("");


            }
            catch (Exception ex)
            {
                return RedirectToAction("");

            }

        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            var resturant = restaurantService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(resturant);
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            try
            {
                this.restaurantService.Value.Edit(restaurant);
                this.restaurantService.Value.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        // GET: Restaurant/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var resturant = restaurantService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault() ;

            return View(resturant);
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(Restaurant restaurant)
        {
            try
            {
                this.restaurantService.Value.Delete(restaurant);
                this.restaurantService.Value.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}