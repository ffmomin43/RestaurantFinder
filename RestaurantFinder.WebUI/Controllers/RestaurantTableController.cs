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
    [Authorize]
    public class RestaurantTableController : Controller
    {
        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<IRestaurantTablesService> restaurantTablesService;
        private readonly Lazy<ILoggerFacade<RestaurantTableController>> logger;

        public RestaurantTableController(Lazy<IRestaurantTablesService> restaurantTablesService,Lazy<IRestaurantService>restaurantService, Lazy<ILoggerFacade<RestaurantTableController>> logger)
        {
            this.restaurantTablesService =restaurantTablesService;
            this.restaurantService = restaurantService;
            this.logger = logger;
        }

        // GET: Restaurant
       
        public ActionResult Index()

        {
            
            var model = restaurantTablesService.Value.GetAll();
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
            ViewBag.resturant = restaurantService.Value.GetAll();
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(RestaurantTable restaurantTable)


        {
            try
            {
                string name = User.Identity.Name;
                //int id = usersService.Value.userid(name);
                restaurantTable.UniqueId = Guid.NewGuid();
                //restaurant.UserId = id;
                this.restaurantTablesService.Value.Add(restaurantTable);
                this.restaurantTablesService.Value.Save();
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
            var resturanttable = restaurantTablesService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(resturanttable);
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(RestaurantTable restaurantTable)
        {
            try
            {
                this.restaurantTablesService.Value.Edit(restaurantTable);
                this.restaurantTablesService.Value.Save();
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
            var resturanttable = restaurantTablesService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();

            return View(resturanttable);
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(RestaurantTable restaurantTable)
        {
            try
            {
                this.restaurantTablesService.Value.Delete(restaurantTable);
                this.restaurantTablesService.Value.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}